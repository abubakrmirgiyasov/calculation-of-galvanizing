using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Services.Interfaces
{
    public interface INomenclatureManagerService
    {
        NomenclatureBindingModel FormingBindingModel(NomenclatureViewModel nomenclatureModel);
    }
}
