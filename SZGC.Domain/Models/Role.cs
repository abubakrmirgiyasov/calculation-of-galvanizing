using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
