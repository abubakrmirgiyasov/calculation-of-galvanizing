using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class RoleRequestService : IRoleRequestService
    {
        public async Task<List<RoleViewModel>> GetAll()
        {
            var baseRequestService = new RequestService<List<RoleViewModel>>(true);
            return await baseRequestService.GetRequestAsync(RoleRoute.ALL);
        }
    }
}
