using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Orser;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Order.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Order
{
    public class OrderPresenter : BasePresenter<IOrderView, OrderViewModel>
    {
        private List<OrderNomenclatureViewModel> _nomenclatureViewModels;

        private OrderViewModel _orderViewModel;

        private readonly INomenclatureRequestService _nomenclatureRequestService;
        private readonly IStageRequestService _stageRequestService;

        public OrderPresenter(
            IStageRequestService stageRequestService,
            INomenclatureRequestService nomenclatureRequestService,
            IApplicationController controller,
            IOrderView view) : base(controller, view)
        {
            _nomenclatureRequestService = nomenclatureRequestService;
            _stageRequestService = stageRequestService;

            View.Start += () => Start();
            View.NomenclatureAdd += () => AddNomenclature();
            View.NomenclatureDelete += () => NomenclatureDelete();
            View.StageAdd += () => AddStage();
            View.StageDelete += () => StageDelete();
            View.ShowChoosesStages += () => View.ShowStages(View.ChoosedNomenclature != null ? View.ChoosedNomenclature.OrderNomenclatureStages : new List<OrderNomenclatureStageViewModel>());
            View.Finish += () => Finish();
        }

        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Открыто диалоговое окно заказа");

                load.SetStatus("Загузка данных...");

                View.OrderName = _orderViewModel.Name;
                View.NumOfHitchStation = _orderViewModel.NumOfHitchStation.ToString();

                _nomenclatureViewModels = _orderViewModel.OrderNomenclatures ?? new List<OrderNomenclatureViewModel>();

                View.ShowNomenclatures(_nomenclatureViewModels);

                load.SetStatus("Данные успешно получены");

                Constants.DesktopLogger.Info("Данные успешно получены");

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

        private void AddNomenclature()
        {
            Constants.DesktopLogger.Info("Добвыление номенклатуры");

            var orderNomencalture = new OrderNomenclatureViewModel();

            if (Controller.Create<ChooseNomenclaturePresenter, OrderNomenclatureViewModel>().RunDialog(orderNomencalture, View.Form) == DialogResult.OK)
            {
                _nomenclatureViewModels.Add(orderNomencalture);
                View.ShowNomenclatures(_nomenclatureViewModels);

                Constants.DesktopLogger.Info("Номенклатура успешно добавлено");
            }
        }

        private void AddStage()
        {
            Constants.DesktopLogger.Info("Добвыление этапа");

            var nomenclatureStage = new OrderNomenclatureStageViewModel();

            if (Controller.Create<ChooseStagePresenter, OrderNomenclatureStageViewModel>().RunDialog(nomenclatureStage, View.Form) == DialogResult.OK)
            {
                View.ChoosedNomenclature.OrderNomenclatureStages.Add(nomenclatureStage);
                View.ShowStages(View.ChoosedNomenclature.OrderNomenclatureStages);

                Constants.DesktopLogger.Info("Этап успешно добавлен");
            }
        }

        private void NomenclatureDelete()
        {
            Constants.DesktopLogger.Info("Удаление номенклатуры");

            _nomenclatureViewModels.Remove(View.ChoosedNomenclature);
            View.ShowNomenclatures(_nomenclatureViewModels);

            Constants.DesktopLogger.Info("Номенклатура успешно удалена");
        }

        private void StageDelete()
        {
            Constants.DesktopLogger.Info("Удаление этапа");

            View.ChoosedNomenclature.OrderNomenclatureStages.Remove(View.ChoosedNomenclatureStage);
            View.ShowStages(View.ChoosedNomenclature.OrderNomenclatureStages);

            Constants.DesktopLogger.Info("Удаление этапа");
        }

        public override void Run(OrderViewModel arg)
        {
            try
            {
                _orderViewModel = arg;
                View.Show();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }
        public override DialogResult RunDialog(OrderViewModel argument, Form owner)
        {
            _orderViewModel = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public override void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }

        public override async Task<DialogResult> RunDialogAsync(OrderViewModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                _orderViewModel = argument;
                SetOwner(owner);
                return View.ShowDialog();
            }
        }

        public override void Finish()
        {
            var load = Controller.Create<LoadPresenter>();

            try
            {
                if (string.IsNullOrEmpty(View.OrderName))
                {
                    throw new Exception("Заполните все поля корректно");
                }

                _ = load.RunDialogAsync(View.Form);

                Constants.DesktopLogger.Info("Добавление заказ в БД");

                load.SetStatus("Добавление данных в БД...");

                _orderViewModel.Name = View.OrderName;
                _orderViewModel.NumOfHitchStation = int.Parse(View.NumOfHitchStation);
                _orderViewModel.OrderNomenclatures = _nomenclatureViewModels;

                load.SetStatus("Добавлено успешно");

                Constants.DesktopLogger.Info("Закрытые диалогового окна заказа");

                load.Finish();

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
