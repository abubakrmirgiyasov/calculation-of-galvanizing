using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class OrderRequestService : IOrderRequestService
    {
        public async Task<OrderBindingModel> AddOrderAsync(OrderBindingModel order)
        {
            var baseRequestService = new RequestService<OrderBindingModel>(true);
            var content = new JsonContent<OrderBindingModel>().GetContent(order);
            return await baseRequestService.PostRequestAsync(content, OrderRoute.ORDER_ADD);
        }

        public async Task<OrderBindingModel> EditOrderAsync(OrderBindingModel order)
        {
            var baseRequestService = new RequestService<OrderBindingModel>(true);
            var content = new JsonContent<OrderBindingModel>().GetContent(order);
            return await baseRequestService.PostRequestAsync(content, OrderRoute.ORDER_EDIT);
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync()
        {
            var baseRequestService = new RequestService<List<OrderViewModel>>(true);
            return await baseRequestService.GetRequestAsync(OrderRoute.ORDER_ALL);
        }

        public async Task<OrderBindingModel> RemoveOrderAsync(OrderBindingModel order)
        {
            var baseRequestService = new RequestService<OrderBindingModel>(true);
            var content = new JsonContent<OrderBindingModel>().GetContent(order);
            return await baseRequestService.PostRequestAsync(content, OrderRoute.ORDER_DELETE);
        }
    }
}
