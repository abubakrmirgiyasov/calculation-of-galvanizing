using System;
using System.Collections.Generic;

namespace SZGC.Domain.ViewModels
{
    public class NomenclatureViewModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double MaxWeightTraverse { get; set; }

        public int MaxCountTraverse { get; set; }


        public List<NomenclatureStageViewModel> NomenclatureStages { get; set; }
        
        public override string ToString() => Name;

        public string ToSearchString()
        {
            return $"{Name}{DateCreated}{Weight}{MaxWeightTraverse}{MaxCountTraverse}";
        }
    }
}
