using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SZGC.Domain.Models
{
    public class NomenclatureStage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public Guid NomenclatureId { get; set; }

        [Required]
        public Guid StageId { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Stage Stage { get; set; }
    }
}
