using System;
using SZGC.Desktop.Services.Settings.Interfaces;

namespace SZGC.Desktop.Services.Settings
{
    public class DataUserSettingsService : IDataUserSettingsService
    {
        public void DeleteDataUser()
        {
            try
            {
                Properties.Authentication.Default.Login = "";
                Properties.Authentication.Default.RememberMe = false;
                Properties.Authentication.Default.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void SaveDataUser(bool remember, string login)
        {
            try
            {
                Properties.Authentication.Default.RememberMe = remember;
                Properties.Authentication.Default.Login = login;
                Properties.Authentication.Default.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
