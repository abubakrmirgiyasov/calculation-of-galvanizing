using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class RefreshSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string RefreshToken { get; set; }

        public string Salt { get; set; }

        public string Ip { get; set; }

        public string ClientName { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime TimeExpired { get; set; }

        public User User { get; set; }
    }
}
