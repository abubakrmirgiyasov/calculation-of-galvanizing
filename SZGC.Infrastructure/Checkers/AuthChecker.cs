using System;
using SZGC.Domain.BindingModels;

namespace SZGC.Infrastructure.Checkers
{
    public class AuthChecker
    {
        public void CheckLogin(LoginBindingModel loginModel)
        {
            try
            {
                if (string.IsNullOrEmpty(loginModel.Login))
                {
                    throw new Exception("Заполните поле Логин");
                }
                else if (string.IsNullOrEmpty(loginModel.Password))
                {
                    throw new Exception("Заполните поле Пароль");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
