using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int NumOfHitchStation { get; set; }

        [Required]
        public int CountTraverse { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderNomenclature> OrderNomenclatures { get; set; }
    }
}
