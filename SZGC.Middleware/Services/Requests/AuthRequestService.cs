using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Cryptography;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class AuthRequestService : IAuthRequestService
    {
        public async Task<List<InfoSessionBindingModel>> GetSessionsAsync(LoginBindingModel loginModel)
        {
            var baseRequestService = new RequestService<List<InfoSessionBindingModel>>(false);
            var content = new JsonContent<LoginBindingModel>().GetContent(loginModel);
            return await baseRequestService.PostRequestAsync(content, AuthRoute.SESSIONS);
        }

        public async Task GetTokens(LoginBindingModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Salt))
            {
                loginModel.Salt = new RFC().GetSalt(6);
            }

            var baseRequestService = new RequestService<TokensViewModel>(false);
            var content = new JsonContent<LoginBindingModel>().GetContent(loginModel);
            var model = await baseRequestService.PostRequestAsync(content, AuthRoute.TOKEN);

            new ParamsService().Save(model.RefreshToken, loginModel.Salt);
            Params.AccessToken = model.AccessToken;
        }

        public async Task<List<InfoSessionBindingModel>> LogoutSessionAsync(InfoSessionBindingModel infoSessionModel)
        {
            var baseRequestService = new RequestService<List<InfoSessionBindingModel>>(false);
            var content = new JsonContent<InfoSessionBindingModel>().GetContent(infoSessionModel);
            return await baseRequestService.PostRequestAsync(content, AuthRoute.LOGOUT_SESSION);
        }

        public async Task<bool> LogoutAsync(SessionBindingModel sessionModel)
        {
            var baseRequestService = new RequestService<bool>(false);
            var content = new JsonContent<SessionBindingModel>().GetContent(sessionModel);
            return await baseRequestService.PostRequestAsync(content, AuthRoute.LOGOUT);
        }

        public async Task UpdateRefreshTokensAsync(SessionBindingModel sessionModel)
        {
            var baseRequestService = new RequestService<TokensViewModel>(false);
            var content = new JsonContent<SessionBindingModel>().GetContent(sessionModel);
            var model = await baseRequestService.PostRequestAsync(content, AuthRoute.REFRESH_TOKEN);
            new ParamsService().Save(model.RefreshToken);
            Params.AccessToken = model.AccessToken;
        }
    }
}
