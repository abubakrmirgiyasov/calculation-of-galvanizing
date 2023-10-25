using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class OrderNomenclature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public Guid NomenclatureId { get; set; }

        [Required]
        public int CountTraverse { get; set; }

        [Required]
        public double AllWeight { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Order Order { get; set; }

        public ICollection<OrderNomenclatureStage> OrderNomenclatureStages { get; set; }
    }
}
