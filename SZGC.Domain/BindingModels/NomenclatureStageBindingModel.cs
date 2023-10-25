using System;

namespace SZGC.Domain.BindingModels
{
    public class NomenclatureStageBindingModel
    {
        public Guid Id { get; set; }

        public int Time { get; set; }

        public Guid StageId { get; set; }
    }
}
