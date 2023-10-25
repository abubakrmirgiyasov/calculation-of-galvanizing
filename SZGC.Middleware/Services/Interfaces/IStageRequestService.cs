using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Middleware.Services.Interfaces
{
    public interface IStageRequestService
    {
        Task<StageBindingModel> AddStageAsync(StageBindingModel stage);

        Task<StageBindingModel> EditStageAsync(StageBindingModel stage);

        Task<List<StageViewModel>> GetStagesAsync();

        Task<StageBindingModel> RemoveStageAsync(StageBindingModel stage);
    }
}
