using System;
using System.Collections.Generic;
using SZGC.Domain.Models;

namespace SZGC.Domain.BindingModels
{
    public class OrderNomenclatureBindingModel
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public int CountTraverse { get; set; }

        public double AllWeight { get; set; }

        public Guid NomenclatureId { get; set; }

        public List<OrderNomenclatureStageBindingModel> OrderNomenclatureStages { get; set; }
    }
}
