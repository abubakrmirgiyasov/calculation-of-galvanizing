using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SZGC.Api.Constants;
using SZGC.Api.Filters;
using SZGC.Api.Services;
using SZGC.Domain.BindingModels;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Controllers
{
    [JwtAuthentication]
    public class StageController : ApiController
    {
        [HttpGet]
        [Route("api/stage/all")]
        public async Task<HttpResponseMessage> GetStages()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение всех этапов");

                var list = await new StageRequests().GetStages();

                LoggerConstant.ApiLogger.Info("Все этапы успешно получены");

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/stage/add")]
        public async Task<HttpResponseMessage> AddStage([FromBody] StageBindingModel stage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Добавление этапа");

                    var request = Request.Headers.Authorization.Parameter;
                    var user = await new UserRequests().GetByLogin(JwtManager.GetPrincipal(request).Identity.Name);

                    await new StageRequests().AddStage(stage, user);

                    LoggerConstant.ApiLogger.Info("Добавлено успешно");

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

        [HttpPost]
        [Route("api/stage/edit")]
        public async Task<HttpResponseMessage> EditStage([FromBody] StageBindingModel stage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Изменение этапа");

                    await new StageRequests().EditStage(stage);

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

        [HttpPost]
        [Route("api/stage/delete")]
        public async Task<HttpResponseMessage> RemoveStage(StageBindingModel stageModel)
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Удаление этапа");

                await new StageRequests().RemoveStage(stageModel);

                LoggerConstant.ApiLogger.Info("Удалено успешно");

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}