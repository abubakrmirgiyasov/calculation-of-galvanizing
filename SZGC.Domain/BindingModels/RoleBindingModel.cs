using System;
using System.ComponentModel.DataAnnotations;

namespace SZGC.Domain.BindingModels
{
    public class RoleBindingModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
