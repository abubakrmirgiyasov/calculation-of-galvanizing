using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class StageRequestService : IStageRequestService
    {
        public async Task<StageBindingModel> AddStageAsync(StageBindingModel stage)
        {
            var baseRequestService = new RequestService<StageBindingModel>(true);
            var content = new JsonContent<StageBindingModel>().GetContent(stage);
            return await baseRequestService.PostRequestAsync(content, StageRoute.STAGE_ADD);
        }

        public async Task<StageBindingModel> EditStageAsync(StageBindingModel stage)
        {
            var baseRequestService = new RequestService<StageBindingModel>(true);
            var content = new JsonContent<StageBindingModel>().GetContent(stage);
            return await baseRequestService.PostRequestAsync(content, StageRoute.STAGE_EDIT);
        }

        public async Task<List<StageViewModel>> GetStagesAsync()
        {
            var baseRequestService = new RequestService<List<StageViewModel>>(true);
            return await baseRequestService.GetRequestAsync(StageRoute.STAGE_ALL);
        }

        public async Task<StageBindingModel> RemoveStageAsync(StageBindingModel stage)
        {
            var baseRequestService = new RequestService<StageBindingModel>(true);
            var content = new JsonContent<StageBindingModel>().GetContent(stage);
            return await baseRequestService.PostRequestAsync(content, StageRoute.STAGE_DELETE);
        }
    }
}
