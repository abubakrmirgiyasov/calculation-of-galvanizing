using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Services.Interfaces
{
    public interface INomenclatureStageManagerService
    {
        NomenclatureStageBindingModel FormingBindingModel(NomenclatureStageViewModel orderModel);
    }
}
