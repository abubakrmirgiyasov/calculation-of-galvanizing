using System;
using System.Collections.Generic;

namespace SZGC.Domain.BindingModels
{
    public class OrderNomenclatureStageBindingModel
    {
        public Guid Id { get; set; }

        public int Time { get; set; }

        public Guid StageId { get; set; }
    }
}
