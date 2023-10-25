using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class Stage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SortedBy { get; set; }

        [Required]
        public bool IsSumming { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderNomenclatureStage> OrderNomenclatureStages { get; set; }

        public ICollection<NomenclatureStage> NomenclatureStages { get; set; }
    }
}
