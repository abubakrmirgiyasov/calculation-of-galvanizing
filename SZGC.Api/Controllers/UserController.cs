using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SZGC.Api.Constants;
using SZGC.Api.Filters;
using SZGC.Api.Services;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Constants;
using SZGC.Domain.Models.Response;
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Cryptography;
using SZGC.Infrastructure.Data;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Controllers
{
    [JwtAuthentication]
    public class UserController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        [Route("api/user/me")]
        public async Task<HttpResponseMessage> GetMe()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение пользователя");

                var request = Request.Headers.Authorization.Parameter;
                var user = await new UserRequests().GetByLogin(JwtManager.GetPrincipal(request).Identity.Name);

                LoggerConstant.ApiLogger.Info("Пользователь получен");

                return Request.CreateResponse(HttpStatusCode.OK, await new UserManager().FormingViewModel(user));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/user/all")]
        [JwtAuthentication(Roles = RolesConstants.ADMIN)]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение всех пользователей");

                var userModels = new List<UserViewModel>();

                var users = new UserRequests().GetAll();

                for (int i = 0; i < users.Count; i++)
                {
                    userModels.Add(await new UserManager().FormingViewModel(users[i]));
                }

                LoggerConstant.ApiLogger.Info("Пользователи успешно получены");

                return Request.CreateResponse(HttpStatusCode.OK, userModels);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        [HttpPost]
        [Route("api/user/add")]
        [JwtAuthentication(Roles = RolesConstants.ADMIN)]
        public async Task<HttpResponseMessage> Add([FromBody] UserBindingModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Добавление пользоваетля");

                    await new UserRequests().Add(userModel);

                    LoggerConstant.ApiLogger.Info("Добавлено успешно");

                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }

            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        [HttpPost]
        [Route("api/user/edit")]
        [JwtAuthentication(Roles = RolesConstants.ADMIN)]
        public async Task<HttpResponseMessage> Edit([FromBody] UserBindingModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Изменение пользователя");

                    await new UserRequests().Edit(userModel);

                    LoggerConstant.ApiLogger.Info("Изменено успешно");

                    return Request.CreateResponse(HttpStatusCode.OK, true);
                }
                else
                {
                    throw new Exception("Некорретно заполнены данные");
                }
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/user/updatePassword")]
        public async Task<HttpResponseMessage> UpdatePassword([FromBody] UpdatePasswordBindingModel updatePasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Обновление пользователя");

                    await CheckUser(updatePasswordModel.Login, updatePasswordModel.OldPassword);
                    await new UserRequests().UpdatePassword(updatePasswordModel);

                    LoggerConstant.ApiLogger.Info("Пользователь обновлен");

                    return Request.CreateResponse(HttpStatusCode.OK, true);
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

        [HttpPost]
        [Route("api/user/delete")]
        [JwtAuthentication(Roles = RolesConstants.ADMIN)]
        public async Task<HttpResponseMessage> Delete([FromBody] UserBindingModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Удаление пользователя");

                    await new UserRequests().Delete(userModel);

                    LoggerConstant.ApiLogger.Info("Удалено успешно");

                    return Request.CreateResponse(HttpStatusCode.OK, true);
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

        public async Task CheckUser(string login, string password)
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
                        user.CountFailEnter = 0;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        user.CountFailEnter++;
                        await _context.SaveChangesAsync();
                        throw new Exception(UserExceptions.StringOutOfRangeEnter);
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