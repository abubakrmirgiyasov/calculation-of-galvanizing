using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SZGC.Api.Constants;
using SZGC.Api.Filters;
using SZGC.Domain.BindingModels;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Controllers
{
    [JwtAuthentication]
    public class SettingsController : ApiController
    {
        [HttpGet]
        [Route("api/setting/all")]
        public async Task<HttpResponseMessage> GetSettings()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение настроек");

                var list = await new SettingRequests().GetSettings();

                LoggerConstant.ApiLogger.Info("Настройки успешно получены");

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/setting/edit")]
        public async Task<HttpResponseMessage> EditStage([FromBody] SettingBindingModel setting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Изменение настройки");

                    await new SettingRequests().EditSetting(setting);

                    LoggerConstant.ApiLogger.Info("Изменено успешно");

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    throw new Exception("Заполните все поля корректно!");
                }
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}