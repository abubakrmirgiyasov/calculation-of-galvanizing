using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZGC.Desktop.Common;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Views.Order.Interfaces;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Desktop.Presenters.Order
{
    public class AdvancedOrderSearchPresenter : BasePresenter<IAdvancedOrderSearchView>
    {
        private IOrderRequestService _orderRequestService;

        public List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

        public AdvancedOrderSearchPresenter(
            IOrderRequestService orderRequestService,
            IApplicationController controller,
            IAdvancedOrderSearchView view) : base(controller, view)
        {
            _orderRequestService = orderRequestService;

            View.Finish += () => Finish();
        }

        public async new void Finish()
        {
            try
            {
                Constants.DesktopLogger.Info("Проверка полей расширенного поиска");

                var orders = await _orderRequestService.GetOrdersAsync();

                if (View.OrderName != string.Empty)
                {
                    orders = orders.Where(x => x.Name.ToLower().IndexOf(View.OrderName.ToLower()) != -1).ToList();
                }

                if (View.Time != string.Empty && int.Parse(View.Time) >= 1)
                {
                    orders = orders.Where(x => x.Time.ToString().IndexOf(View.Time) != -1).ToList();
                }

                if (View.IsEnabled)
                {
                    orders = orders.Where(x => DateTime.Parse(x.DateCreated.ToShortDateString()) >= View.TopDate && DateTime.Parse(x.DateCreated.ToShortDateString()) <= View.BottomDate).ToList();
                }

                orderViewModels = orders;

                View.Cancel = false;
                View.DialogResult = DialogResult.OK;
                View.Close();

                Constants.DesktopLogger.Info("Закрытые формы расширенного поиска");
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
