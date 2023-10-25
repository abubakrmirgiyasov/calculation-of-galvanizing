using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class NomenclatureRequestService : INomenclatureRequestService
    {
        public async Task<NomenclatureBindingModel> AddNomenclatureAsync(NomenclatureBindingModel nomenclature)
        {
            var baseRequestService = new RequestService<NomenclatureBindingModel>(true);
            var content = new JsonContent<NomenclatureBindingModel>().GetContent(nomenclature);
            return await baseRequestService.PostRequestAsync(content, NomenclatureRoute.NOMENCLATURE_ADD);
        }

        public async Task<NomenclatureBindingModel> EditNomenclatureAsync(NomenclatureBindingModel nomenclature)
        {
            var baseRequestService = new RequestService<NomenclatureBindingModel>(true);
            var content = new JsonContent<NomenclatureBindingModel>().GetContent(nomenclature);
            return await baseRequestService.PostRequestAsync(content, NomenclatureRoute.NOMENCLATURE_EDIT);
        }

        public async Task<List<NomenclatureViewModel>> GetNomenclaturesAsync()
        {
            var baseRequestService = new RequestService<List<NomenclatureViewModel>>(true);
            return await baseRequestService.GetRequestAsync(NomenclatureRoute.NOMENCLATURE_ALL);
        }

        public async Task<NomenclatureBindingModel> RemoveNomenclatureAsync(NomenclatureBindingModel nomenclature)
        {
            var baseRequestService = new RequestService<NomenclatureBindingModel>(true);
            var content = new JsonContent<NomenclatureBindingModel>().GetContent(nomenclature);
            return await baseRequestService.PostRequestAsync(content, NomenclatureRoute.NOMENCLATURE_DELETE);
        }
    }
}
