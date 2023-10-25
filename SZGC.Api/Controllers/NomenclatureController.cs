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
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Controllers
{
    [JwtAuthentication]
    public class NomenclatureController : ApiController
    {
        [HttpGet]
        [Route("api/nomenclature/all")]
        public async Task<HttpResponseMessage> GetNomenclatures()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение всех номенклатур");

                var models = new List<NomenclatureViewModel>();

                var list = await new NomenclatureRequests().GetNomenclatures();

                for (int i = 0; i < list.Count; i++)
                {
                    models.Add(new NomenclatureManager().FormingViewModel(list[i]));
                }

                LoggerConstant.ApiLogger.Info("Номенклатуры успешно получены");

                return Request.CreateResponse(HttpStatusCode.OK, models);
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/nomenclature/add")]
        public async Task<HttpResponseMessage> AddNomenclature([FromBody] NomenclatureBindingModel nomenclature)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Добавление номенклатуры");

                    var request = Request.Headers.Authorization.Parameter;
                    var user = await new UserRequests().GetByLogin(JwtManager.GetPrincipal(request).Identity.Name);

                    await new NomenclatureRequests().AddNomenclature(nomenclature, user);

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
        [Route("api/nomenclature/edit")]
        public async Task<HttpResponseMessage> EditNomenclature([FromBody] NomenclatureBindingModel nomenclature)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Изменение номенклатуры");

                    await new NomenclatureRequests().EditNomenclature(nomenclature);

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
        [Route("api/nomenclature/delete")]
        public async Task<HttpResponseMessage> RemoveNomenclature([FromBody] NomenclatureBindingModel nomenclature)
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Удаление номенклатуры");

                await new NomenclatureRequests().RemoveNomenclature(nomenclature);

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