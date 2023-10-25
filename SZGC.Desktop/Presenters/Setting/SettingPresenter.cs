using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Setting;
using SZGC.Desktop.Views.Setting.Interfaces;
using SZGC.Domain.BindingModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Setting
{
    public class SettingPresenter : BasePresenter<ISettingView>
    {
        private readonly ISettingRequestService _settingRequestService;

        public SettingPresenter(IApplicationController controller, ISettingView view, ISettingRequestService settingRequestService) : base(controller, view)
        {
            _settingRequestService = settingRequestService;

            View.Start += () => Start();
            View.Save += () => Save();
        }
        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Открыто диалоговое окно настроек");

                View.WorkingShift = Domain.Settings.Shared.WorkingShift.ToString();

                load.Finish();

                await flag;
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                load.Finish();

                await flag;

                View.Error(ex.Message);
            }
        }

        private async void Save()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Сохранение настроек");

                if(int.TryParse(View.WorkingShift, out int value))
                {
                    await _settingRequestService.EditSettingAsync(new SettingBindingModel { Name = "WorkingShift", Value = View.WorkingShift });
                    Domain.Settings.Shared.WorkingShift = value;
                }
                else
                {
                    throw new Exception("Время должно быть целочисленным");
                }

                load.Finish();

                await flag;

                View.DialogResult = System.Windows.Forms.DialogResult.OK;
                Finish();
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
