using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class OrderNomenclatureStage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public Guid OrderNomenclatureId { get; set; }

        [Required]
        public Guid StageId { get; set; }

        public Stage Stage { get; set; }

        public OrderNomenclature OrderNomenclature { get; set; }
    }
}
