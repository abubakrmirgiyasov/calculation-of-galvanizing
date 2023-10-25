using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
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
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/order/all")]
        public async Task<HttpResponseMessage> GetOrders()
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Получение всех заказов");

                var list = (await new OrderRequests().GetOrders()).Select(p => new OrderManager().FormingViewModel(p));

                LoggerConstant.ApiLogger.Info("Заказы успешно получены");

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch (Exception ex)
            {
                LoggerConstant.ApiLogger.Error("Ошибка -------> " + ex.Message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/order/add")]
        public async Task<HttpResponseMessage> AddOrder([FromBody] OrderBindingModel order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Добавление заказа");

                    var request = Request.Headers.Authorization.Parameter;
                    var user = await new UserRequests().GetByLogin(JwtManager.GetPrincipal(request).Identity.Name);

                    await new OrderRequests().AddOrder(order, user);

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
        [Route("api/order/edit")]
        public async Task<HttpResponseMessage> EditOrder([FromBody] OrderBindingModel order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoggerConstant.ApiLogger.Info("Изменение заказа");

                    await new OrderRequests().EditOrder(order);

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
        [Route("api/order/delete")]
        public async Task<HttpResponseMessage> RemoveOrder([FromBody] OrderBindingModel order)
        {
            try
            {
                LoggerConstant.ApiLogger.Info("Удаление заказа");

                await new OrderRequests().RemoveOrder(order);

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