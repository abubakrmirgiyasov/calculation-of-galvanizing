using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SZGC.Api.Constants;
using SZGC.Api.Filters;
using SZGC.Api.Services;
using SZGC.Domain.Constants;
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Controllers
{
    [JwtAuthentication]
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/role/all")]
        [JwtAuthentication(Roles = RolesConstants.ADMIN)]
        public HttpResponseMessage GetAll()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение всех ролей");

                var roleModels = new List<RoleViewModel>();

                var roles = new RoleRequests().GetAll();

                for (int i = 0; i < roles.Count; i++)
                {
                    roleModels.Add(new RoleManager().FormingViewModel(roles[i]));
                }

                LoggerConstant.ApiLogger.Info("Роли успешно получены");

                return Request.CreateResponse(HttpStatusCode.OK, roleModels);
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
        }
    }
}