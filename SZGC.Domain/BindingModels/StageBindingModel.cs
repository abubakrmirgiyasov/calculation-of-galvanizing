using System;

namespace SZGC.Domain.BindingModels
{
    public class StageBindingModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int SortedBy { get; set; }

        public bool IsSumming { get; set; }
    }
}
