using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;

namespace SZGC.Middleware.Interfaces
{
    public interface IAuthRequestService
    {
        Task GetTokens(LoginBindingModel loginModel);
        
        Task UpdateRefreshTokensAsync(SessionBindingModel sessionModel);
        
        Task<List<InfoSessionBindingModel>> LogoutSessionAsync(InfoSessionBindingModel infoSessionModel);
        
        Task<List<InfoSessionBindingModel>> GetSessionsAsync(LoginBindingModel loginModel);
        
        Task<bool> LogoutAsync(SessionBindingModel sessionModel);
    }
}
