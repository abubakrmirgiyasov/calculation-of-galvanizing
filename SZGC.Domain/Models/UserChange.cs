using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class UserChange
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Login { get; set; }

        public byte[] Salt { get; set; }

        public string Password { get; set; }

        public bool UpdatePassword { get; set; }

        public bool Active { get; set; }

        public Guid TypeId { get; set; }
        public UserChangeType Type { get; set; }

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
