using Newtonsoft.Json;

namespace SZGC.Middleware.Services.Requests
{
    public class JsonContent<T>
    {
        public string GetContent(T entity)
        {
            return JsonConvert.SerializeObject(
                entity,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }
    }
}