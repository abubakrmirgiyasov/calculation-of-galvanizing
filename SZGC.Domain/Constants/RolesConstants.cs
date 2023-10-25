using System;
using SZGC.Domain.Models;

namespace SZGC.Domain.Constants
{
    public class RolesConstants
    {
        public const string ADMIN = "Root";
        public const string DEFAULT_USER = "User";

        public readonly Role[] roles =
        {
            new Role{Id = Guid.NewGuid(), Name = ADMIN, DateCreate = DateTime.Now},
            new Role{Id = Guid.NewGuid(), Name = DEFAULT_USER, DateCreate = DateTime.Now},
        };
    }
}
