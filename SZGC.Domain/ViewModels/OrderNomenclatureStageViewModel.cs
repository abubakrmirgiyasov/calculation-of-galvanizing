using Newtonsoft.Json;
using System;

namespace SZGC.Domain.ViewModels
{
    public class OrderNomenclatureStageViewModel
    {
        public Guid Id { get; set; }

        public int Time { get; set; }

        public StageViewModel Stage { get; set; }

        [JsonIgnore]
        public string StageView => Stage.Name;
    }
}
