using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SZGC.Domain.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Login { get; set; }

        public bool UpdatePassword { get; set; }

        public bool Active { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
