using System;
using System.Collections.Generic;
using System.Text;
using SZGC.Domain.Models;

namespace SZGC.Domain.Constants
{
    public class UserChangeTypeConstants
    {
        public const string ADD_USER = "Добавление пользователя";
        public const string CHANGE_USER = "Изменение пользователя";
        public const string DELETE_USE = "Удаление пользователя";

        public readonly UserChangeType[] userChangeTypes =
        {
            new UserChangeType{Id = Guid.NewGuid(), Name = ADD_USER, DateCreate = DateTime.Now},
            new UserChangeType{Id = Guid.NewGuid(), Name = CHANGE_USER, DateCreate = DateTime.Now},
            new UserChangeType{Id = Guid.NewGuid(), Name = DELETE_USE, DateCreate = DateTime.Now},
        };
    }
}
