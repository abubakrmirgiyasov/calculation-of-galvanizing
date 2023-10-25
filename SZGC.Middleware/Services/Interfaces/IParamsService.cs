namespace SZGC.Middleware.Services.Interfaces
{
    public interface IParamsService
    {
        void Save(string token, string salt = null);

        void Load();
    }
}
