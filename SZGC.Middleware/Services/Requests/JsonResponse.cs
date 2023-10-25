using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace SZGC.Middleware.Services.Requests
{
    public class JsonResponse<T>
    {
        public T GetResponse(HttpResponseMessage response, string apiRespoonse)
        {
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(apiRespoonse);
            }

            throw new Exception(JsonConvert.DeserializeObject<string>(apiRespoonse));
        }
    }
}