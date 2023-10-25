using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Middleware.Services.Interfaces
{
    public interface INomenclatureRequestService
    {
        Task<List<NomenclatureViewModel>> GetNomenclaturesAsync();

        Task<NomenclatureBindingModel> AddNomenclatureAsync(NomenclatureBindingModel nomenclature);

        Task<NomenclatureBindingModel> EditNomenclatureAsync(NomenclatureBindingModel nomenclature);

        Task<NomenclatureBindingModel> RemoveNomenclatureAsync(NomenclatureBindingModel nomenclature);
    }
}
