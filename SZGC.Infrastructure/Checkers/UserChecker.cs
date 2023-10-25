using System;
using SZGC.Domain.BindingModels;
using SZGC.Infrastructure.Checkers;

namespace SZGC.IntegrationDatabase.Checkers
{
    public class UserChecker
    {
        public void CheckedBadFieldsPreAdd(UserBindingModel userBindingModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userBindingModel.SurName))
                {
                    throw new Exception("Необходимо заполнить фамилию");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.SurName))
                {
                    throw new Exception("При заполнеии фамилии нельзя использовать (_\\/*:?|\"<> )");
                }
                if (string.IsNullOrWhiteSpace(userBindingModel.Name))
                {
                    throw new Exception("Необходимо заполнить имя");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.Name))
                {
                    throw new Exception("При заполнеии имени нельзя использовать (_\\/*:?|\"<> )");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.MiddleName))
                {
                    throw new Exception("При заполнеии отчества нельзя использовать (_\\/*:?|\"<> )");
                }
                if (string.IsNullOrWhiteSpace(userBindingModel.Login))
                {
                    throw new Exception("Необходимо заполнить логин");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.Login))
                {
                    throw new Exception("При заполнеии логина нельзя использовать (_\\/*:?|\"<> )");
                }
                if (string.IsNullOrWhiteSpace(userBindingModel.Password))
                {
                    throw new Exception("Необходимо заполнить пароль");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.Password))
                {
                    throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<> )");
                }
                if (userBindingModel.Password.Trim().Length < 4)
                {
                    throw new Exception("В пароле минимум 4 символа");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public void CheckedBadFieldsPreEdit(UserBindingModel userBindingModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userBindingModel.SurName))
                {
                    throw new Exception("Необходимо заполнить фамилию");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.SurName))
                {
                    throw new Exception("При заполнеии фамилии нельзя использовать (_\\/*:?|\"<> )");
                }
                if (string.IsNullOrWhiteSpace(userBindingModel.Name))
                {
                    throw new Exception("Необходимо заполнить имя");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.Name))
                {
                    throw new Exception("При заполнеии имени нельзя использовать (_\\/*:?|\"<> )");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.MiddleName))
                {
                    throw new Exception("При заполнеии отчества нельзя использовать (_\\/*:?|\"<> )");
                }
                if (string.IsNullOrWhiteSpace(userBindingModel.Login))
                {
                    throw new Exception("Необходимо заполнить логин");
                }
                if (new ShareChecker().CheckBadSymbol(userBindingModel.Login))
                {
                    throw new Exception("При заполнеии логина нельзя использовать (_\\/*:?|\"<> )");
                }
                if (!string.IsNullOrEmpty(userBindingModel.Password))
                {
                    if (string.IsNullOrWhiteSpace(userBindingModel.Password))
                    {
                        throw new Exception("Необходимо заполнить пароль");
                    }
                    if (new ShareChecker().CheckBadSymbol(userBindingModel.Password))
                    {
                        throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<> )");
                    }
                    if (userBindingModel.Password.Trim().Length < 4)
                    {
                        throw new Exception("В пароле минимум 4 символа");
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public void CheckedBadFieldsPreDelete(UserBindingModel userBindingModel)
        {
            try
            {
                if (userBindingModel.Id.ToString().Length != 32)
                {
                    throw new Exception("Не корректный id пользователя для удаления");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public void CheckFieldPreUpdatePassword(UpdatePasswordBindingModel passwordBindingModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(passwordBindingModel.NewPassword))
                {
                    throw new Exception("Необходимо заполнить пароль");
                }
                if (new ShareChecker().CheckBadSymbol(passwordBindingModel.NewPassword))
                {
                    throw new Exception("При заполнеии пароля нельзя использовать (_\\/*:?|\"<> )");
                }
                if (passwordBindingModel.NewPassword.Trim().Length < 4)
                {
                    throw new Exception("В пароле минимум 4 символа");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
