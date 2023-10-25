using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Main;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Services.Settings.Interfaces;
using SZGC.Desktop.Views.Auth.Interfaces;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Exceptions;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Interfaces;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Auth
{
    public class AuthPresenter : BasePresenter<IAuthVIew>
    {
        private readonly IAuthRequestService _authRequestService;
        private readonly IDataUserSettingsService _dataUserService;
        private readonly IParamsService _paramsService;

        public AuthPresenter(
            IParamsService paramsService,
            IApplicationController controller,
            IAuthVIew view,
            IAuthRequestService authRequestService,
            IDataUserSettingsService dataUserService) : base(controller, view)
        {
            try
            {
                _paramsService = paramsService;
                _authRequestService = authRequestService;
                _dataUserService = dataUserService;

                View.Start += () => Start();
                View.Login += () => Login();
            }
            catch (Exception ex)
            {
                View.Error(ex.Message);
            }
        }

        private async void Start()
        {
            try
            {
                Constants.DesktopLogger.Info("Загрузка формы авторизации");

                View.WindowState = FormWindowState.Minimized;
                View.ShowInTaskbar = false;

                View.BlockFields(true);

                Constants.DesktopLogger.Info("Загрузка токенов");
                _paramsService.Load();
                Constants.DesktopLogger.Info("Токен успешно обновлен");


                Constants.DesktopLogger.Info("Автоматическая авторизация");
                await AutoLoginAsync();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);
                View.BlockFields(false);
                View.SetNameLogin_B("Войти");
                View.Error(ex.Message);

                View.WindowState = FormWindowState.Normal;
                View.ShowInTaskbar = true;
            }
        }

        private async Task AutoLoginAsync()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                load.SetStatus("Авторизация пользователя");

                await _authRequestService.UpdateRefreshTokensAsync(
                    new SessionBindingModel
                    {
                        RefreshToken = Params.RefreshToken,
                        ClientName = Environment.MachineName
                    });

                load.SetStatus("Пользователь авторизован");
                load.Finish();

                await flag;

                Constants.DesktopLogger.Info("Пользователь авторизован");
                Constants.DesktopLogger.Info("Загрузка главной формы");

                LoadMainForm();

                View.Close();

                Constants.DesktopLogger.Info("Закрываем окно авторизации");
            }
            catch (ServerConnectionFailedException)
            {
                View.Error("Невозможно соединиться с удаленным сервером");
                View.Close();
            }
            catch (NeedUpdatePasswordException ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                _dataUserService.DeleteDataUser();

                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadMainForm()
        {
            try
            {
                Controller.Create<MainPresenter>().Run();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                throw new Exception(ex.Message, ex);
            }
        }

        private async void Login()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Авторизация пользователя");

                load.SetStatus("Авторизация пользователя");

                await _authRequestService.GetTokens(new LoginBindingModel
                {
                    Login = View.UserName,
                    Password = View.Password,
                    ClientName = Environment.MachineName
                });

                Constants.DesktopLogger.Info("Сохранение данных");

                _dataUserService.SaveDataUser(View.RememberMe, View.UserName);

                Constants.DesktopLogger.Info("Данные успешно сохранены");

                load.SetStatus("Пользователь авторизован");
                load.Finish();

                await flag;

                LoadMainForm();

                View.Close();
            }
            catch (OutOfRangeSessionsException ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);

                View.Password = "";
            }
            catch (NeedUpdatePasswordException ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);
            }
        }
    }
}
