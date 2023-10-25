using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class Nomenclature
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double MaxWeightTraverse { get; set; }

        [Required]
        public int MaxCountTraverse { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderNomenclature> OrderNomenclatures { get; set; }

        public ICollection<NomenclatureStage> NomenclatureStages { get; set; }
    }
}
