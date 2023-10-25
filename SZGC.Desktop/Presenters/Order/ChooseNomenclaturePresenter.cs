using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Presenters.Shared;
using SZGC.Desktop.Views.Order.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Orser
{
    public class ChooseNomenclaturePresenter : BasePresenter<IChooseNomenclatureView, OrderNomenclatureViewModel>
    {
        private List<NomenclatureViewModel> _nomenclatureViewModels;
        private OrderNomenclatureViewModel _orderNomenclatureModel;

        private readonly INomenclatureRequestService _nomenclatureRequestService;

        public ChooseNomenclaturePresenter(
            INomenclatureRequestService nomenclatureRequestService,
            IApplicationController controller,
            IChooseNomenclatureView view) : base(controller, view)
        {
            _nomenclatureRequestService = nomenclatureRequestService;

            View.Start += () => Start();
            View.Finish += () => Finish();
        }

        private async void Start()
        {
            var load = Controller.Create<LoadPresenter>();
            var flag = load.RunDialogAsync(View.Form);

            try
            {
                Constants.DesktopLogger.Info("Загрузка номенклатуры");

                _nomenclatureViewModels = await _nomenclatureRequestService.GetNomenclaturesAsync();

                View.ShowNomenclatures(_nomenclatureViewModels);

                Constants.DesktopLogger.Info("Номенклатуры успешно загружены");

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

        public override void Run(OrderNomenclatureViewModel argument)
        {
            try
            {
                _orderNomenclatureModel = argument;
                View.Show();
            }
            catch (Exception ex)
            {
                Constants.DesktopLogger.Error("Ошибка -------> " + ex.Message);

                View.Error(ex.Message);
            }
        }

        public override DialogResult RunDialog(OrderNomenclatureViewModel argument, Form owner)
        {
            _orderNomenclatureModel = argument;
            SetOwner(owner);
            return View.ShowDialog();
        }

        public async override Task<DialogResult> RunDialogAsync(OrderNomenclatureViewModel argument, Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                _orderNomenclatureModel = argument;
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
                    Constants.DesktopLogger.Info("Закрытые диалогового окно выбора номенклатуры");

                    _orderNomenclatureModel.Nomenclature = View.Choosed;
                    _orderNomenclatureModel.OrderNomenclatureStages = new List<OrderNomenclatureStageViewModel>();

                    for (int i = 0; i < View.Choosed.NomenclatureStages.Count; i++)
                    {
                        _orderNomenclatureModel.OrderNomenclatureStages.Add(new OrderNomenclatureStageViewModel
                        {
                            Stage = View.Choosed.NomenclatureStages[i].Stage,
                            Time = View.Choosed.NomenclatureStages[i].Time
                        });
                    }

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
