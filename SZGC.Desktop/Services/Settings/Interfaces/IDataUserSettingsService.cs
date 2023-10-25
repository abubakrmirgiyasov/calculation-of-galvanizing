namespace SZGC.Desktop.Services.Settings.Interfaces
{
    public interface IDataUserSettingsService
    {
        void SaveDataUser(bool remember, string login);

        void DeleteDataUser();
    }
}
