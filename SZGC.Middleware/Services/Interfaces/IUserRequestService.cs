using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Middleware.Services.Interfaces
{
    public interface IUserRequestService
    {
        Task<UserViewModel> GetMeAsync();

        Task<List<UserViewModel>> GetAllAsync();
        
        Task<bool> AddAsync(UserBindingModel userModel);
        
        Task<bool> EditAsync(UserBindingModel userModel);
        
        Task<bool> DeleteAsync(UserBindingModel userModel);
        
        Task<bool> UpdatePasswordAsync(UpdatePasswordBindingModel updatePasswordModel);
    }
}
