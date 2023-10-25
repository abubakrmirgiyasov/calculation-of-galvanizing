using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.ViewModels;

namespace SZGC.Middleware.Services.Interfaces
{
    public interface IRoleRequestService
    {
        Task<List<RoleViewModel>> GetAll();
    }
}
