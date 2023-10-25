using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SZGC.Api.Filters;
using SZGC.Api.Services;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Constants;
using SZGC.Domain.Models.Response;
using SZGC.Infrastructure.Cryptography;
using SZGC.Infrastructure.Data;
using SZGC.Api.Constants;

namespace SZGC.Api.Controllers
{
    [JwtAuthentication]
    public class AuthController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/tokens")]
        public async Task<HttpResponseMessage> GetToken([FromBody] LoginBindingModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Авторизация");

                    await CheckUserBeforeAuth(loginModel.Login, loginModel.Password);

                    var token = JwtManager.GenerateToken(loginModel.Login, loginModel.Salt);

                    var isAdded = await new RefreshSessionManager().AddSession(token, loginModel, GetClientIp());

                    if (isAdded)
                    {
                        LoggerConstant.ApiLogger.Info("Токен получен");
                        return Request.CreateResponse(HttpStatusCode.OK, token);
                    }
                    else
                    {
                        LoggerConstant.ApiLogger.Error("Ошибка -------> " + ExceptionConstants.ErrorAddingUserSession);
                        throw new Exception(ExceptionConstants.ErrorAddingUserSession);
                    }
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }

            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/refreshTokens")]
        public async Task<HttpResponseMessage> GetToken([FromBody] SessionBindingModel sessionModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Обновление токена");

                    var token = await new RefreshSessionManager().UpdateRefreshSession(sessionModel, GetClientIp());

                    if (token != null)
                    {
                        LoggerConstant.ApiLogger.Info("Токен обновлен");

                        return Request.CreateResponse(HttpStatusCode.OK, token);
                    }
                    else
                    {
                        LoggerConstant.ApiLogger.Error("Ошибка -------> " + ExceptionConstants.ErrorUpdatingUserToken);

                        throw new Exception(ExceptionConstants.ErrorUpdatingUserToken);
                    }
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/Logout")]
        public async Task<HttpResponseMessage> Logout([FromBody] SessionBindingModel sessionModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Выход из учетки");

                    var isDeleted = await new RefreshSessionManager().DeleteSession(sessionModel);

                    if (isDeleted)
                    {
                        LoggerConstant.ApiLogger.Info("Успешный выход");

                        return Request.CreateResponse(HttpStatusCode.OK, isDeleted);
                    }
                    else
                    {
                        LoggerConstant.ApiLogger.Error("Ошибка -------> " + ExceptionConstants.ErrorDeletingSession);

                        throw new Exception(ExceptionConstants.ErrorDeletingSession);
                    }
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/logoutSession")]
        public async Task<HttpResponseMessage> Logout([FromBody] InfoSessionBindingModel infoSessionModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Удаления сессии");

                    await CheckUserBeforeAuth(infoSessionModel.Login, infoSessionModel.Password);

                    var isDeleted = await new RefreshSessionManager().DeleteUsersSession(infoSessionModel);

                    if (isDeleted)
                    {
                        LoggerConstant.ApiLogger.Info("Сессия успешно удалено");

                        return Request.CreateResponse(HttpStatusCode.OK,
                            await new RefreshSessionManager().GetSessions(infoSessionModel.Login));
                    }
                    else
                    {
                        LoggerConstant.ApiLogger.Error("Ошибка -------> " + ExceptionConstants.ErrorDeletingSession);

                        throw new Exception(ExceptionConstants.ErrorDeletingSession);
                    }
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost()]
        [Route("api/auth/sessions")]
        public async Task<HttpResponseMessage> GetSessions([FromBody] LoginBindingModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Получение всех сессий");

                    await CheckUserBeforeAuth(loginModel.Login, loginModel.Password);
                    return Request.CreateResponse(HttpStatusCode.OK,
                        await new RefreshSessionManager().GetSessions(loginModel.Login));
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private string GetClientIp(HttpRequestMessage request = null)
        {
            try
            {
                request = request ?? Request;

                if (request.Properties.ContainsKey("MS_HttpContext"))
                {
                    return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
                }
                else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
                {
                    RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                    return prop.Address;
                }
                else if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Request.UserHostAddress;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task CheckUserBeforeAuth(string login, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);

                if (user == null)
                {
                    throw new Exception(UserExceptions.StringNotFoundUser);
                }

                if (!user.Active)
                {
                    throw new Exception(UserExceptions.StringInactive);
                }

                if (user.CountFailEnter < 5)
                {
                    if (user.Password == new Hasher().GetHash(password, user.Salt))
                    {
                        if (user.UpdatePassword)
                        {
                            throw new Exception(UserExceptions.StringNeedUpdatePassword);
                        }

                        user.CountFailEnter = 0;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        user.CountFailEnter++;
                        await _context.SaveChangesAsync();
                        throw new Exception(UserExceptions.StringBadPassword);
                    }
                }
                else
                {
                    user.Active = false;
                    await _context.SaveChangesAsync();
                    throw new Exception(UserExceptions.StringOutOfRangeEnter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}