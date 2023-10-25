using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Middleware.Services.Interfaces
{
    public interface IOrderRequestService
    {
        Task<OrderBindingModel> AddOrderAsync(OrderBindingModel order);

        Task<OrderBindingModel> EditOrderAsync(OrderBindingModel order);

        Task<List<OrderViewModel>> GetOrdersAsync();

        Task<OrderBindingModel> RemoveOrderAsync(OrderBindingModel order);
    }
}
