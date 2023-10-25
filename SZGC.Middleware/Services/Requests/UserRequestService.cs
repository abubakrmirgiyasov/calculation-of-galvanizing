using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class UserRequestService : IUserRequestService
    {
        public async Task<bool> AddAsync(UserBindingModel userModel)
        {
            var baseRequestService = new RequestService<bool>(true);
            var content = new JsonContent<UserBindingModel>().GetContent(userModel);
            return await baseRequestService.PostRequestAsync(content, UserRoute.ADD);
        }

        public async Task<bool> DeleteAsync(UserBindingModel userModel)
        {
            var baseRequestService = new RequestService<bool>(true);
            var content = new JsonContent<UserBindingModel>().GetContent(userModel);
            return await baseRequestService.PostRequestAsync(content, UserRoute.DELETE);
        }

        public async Task<bool> EditAsync(UserBindingModel userModel)
        {
            var baseRequestService = new RequestService<bool>(true);
            var content = new JsonContent<UserBindingModel>().GetContent(userModel);
            return await baseRequestService.PostRequestAsync(content, UserRoute.EDIT);
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var baseRequestService = new RequestService<List<UserViewModel>>(true);
            return await baseRequestService.GetRequestAsync(UserRoute.ALL);
        }

        public async Task<UserViewModel> GetMeAsync()
        {
            var baseRequestService = new RequestService<UserViewModel>(true);
            return await baseRequestService.GetRequestAsync(UserRoute.ME);
        }

        public async Task<bool> UpdatePasswordAsync(UpdatePasswordBindingModel updatePasswordModel)
        {
            var baseRequestAsync = new RequestService<bool>(false);
            var content = new JsonContent<UpdatePasswordBindingModel>().GetContent(updatePasswordModel);
            return await baseRequestAsync.PostRequestAsync(content, UserRoute.UPDATE_PASSWORD);
        }
    }
}
