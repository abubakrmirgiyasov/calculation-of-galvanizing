using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SZGC.Domain.ViewModels
{
    public class OrderNomenclatureViewModel
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public int CountTraverse { get; set; }

        public double AllWeight { get; set; }

        public NomenclatureViewModel Nomenclature { get; set; }

        public List<OrderNomenclatureStageViewModel> OrderNomenclatureStages { get; set; }

        [JsonIgnore]
        public string NomenclatureName => Nomenclature.Name;
    }
}
