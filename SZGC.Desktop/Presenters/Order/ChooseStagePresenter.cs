using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Order.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Order
{
    public class ChooseStagePresenter : BasePresenter<IChooseStageView, OrderNomenclatureStageViewModel>
    {
        private List<StageViewModel> _stageViewModels;
        private OrderNomenclatureStageViewModel _nomenclatureStage;

        private readonly IStageRequestService _stageRequestService;

        public ChooseStagePresenter(
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
                Constants.DesktopLogger.Info("Загрузка этапа");

                _stageViewModels = await _stageRequestService.GetStagesAsync();

                View.ShowStages(_stageViewModels);

                Constants.DesktopLogger.Info("Этапы успешно загружены");

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

        public override void Run(OrderNomenclatureStageViewModel argument)
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

        public override DialogResult RunDialog(OrderNomenclatureStageViewModel argument, Form owner)
        {
            _nomenclatureStage = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public async override Task<DialogResult> RunDialogAsync(OrderNomenclatureStageViewModel argument, Form owner)
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
                    Constants.DesktopLogger.Info("Закрытые диалогового окна выбора этапа");

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
