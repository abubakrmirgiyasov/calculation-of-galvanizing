using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Stage.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Presenters.Stage
{
    public class StagePresenter : BasePresenter<IStageView, StageViewModel>
    {
        private StageViewModel _stageViewModel;

        public StagePresenter(IApplicationController controller, IStageView view) : base(controller, view)
        {
            View.Start += () => Start();
            View.Finish += () => Finish();
        }

        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Открыто диалоговое окно этапа");

                View.StageName = _stageViewModel.Name;
                View.StageNum = _stageViewModel.SortedBy.ToString();
                View.IsSumming = _stageViewModel.IsSumming;

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

        public override void Run(StageViewModel argument)
        {
            try
            {
                _stageViewModel = argument;
                View.Show();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        public override DialogResult RunDialog(StageViewModel argument, Form owner)
        {
            _stageViewModel = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public override async Task<DialogResult> RunDialogAsync(StageViewModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                _stageViewModel = argument;
                SetOwner(owner);
                return View.ShowDialog();
            }
        }

        public override void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }

        public override void Finish()
        {
            try
            {
                if (string.IsNullOrEmpty(View.StageName))
                {
                    throw new Exception("Заполните поле корректно");
                }

                Constants.DesktopLogger.Info("Закрытые диалогового окно этапа");

                _stageViewModel.Name = View.StageName;
                _stageViewModel.SortedBy = int.Parse(View.StageNum);
                _stageViewModel.IsSumming = View.IsSumming;

                View.Cancel = false;
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Cancel = true;

                View.Error(ex.Message);
            }
        }
    }
}
