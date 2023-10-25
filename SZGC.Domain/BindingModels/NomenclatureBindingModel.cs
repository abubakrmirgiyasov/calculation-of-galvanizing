using System;
using System.Collections.Generic;

namespace SZGC.Domain.BindingModels
{
    public class NomenclatureBindingModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double MaxWeightTraverse { get; set; }

        public int MaxCountTraverse { get; set; }

        public List<NomenclatureStageBindingModel> NomenclatureStages { get; set; }
    }
}
