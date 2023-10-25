using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Nomenclature.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Nomenclature
{
    internal class StageChoosePresenter : BasePresenter<IChooseStageView, NomenclatureStageViewModel>
    {
        private List<StageViewModel> _stageViewModels;
        private NomenclatureStageViewModel _nomenclatureStage;

        private readonly IStageRequestService _stageRequestService;

        public StageChoosePresenter(
            IStageRequestService stageRequestService,
            IApplicationController controller,
            IChooseStageView view) : base(controller, view)
        {
            _stageRequestService = stageRequestService;

            View.Start += () => Start();
            View.Finish += () => Finish();
        }

        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Открыто диалоговое окно этапов");

                _stageViewModels = await _stageRequestService.GetStagesAsync();

                View.ShowStages(_stageViewModels);

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

        public override void Run(NomenclatureStageViewModel argument)
        {
            try
            {
                _nomenclatureStage = argument;
                View.Show();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        public override DialogResult RunDialog(NomenclatureStageViewModel argument, Form owner)
        {
            _nomenclatureStage = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public async override Task<DialogResult> RunDialogAsync(NomenclatureStageViewModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                _nomenclatureStage = argument;
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
                if (View.DialogResult == DialogResult.OK)
                {
                    Constants.DesktopLogger.Info("Закрытые диалогового окна");

                    _nomenclatureStage.Stage = View.Choosed;

                    View.Cancel = false;
                }
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
