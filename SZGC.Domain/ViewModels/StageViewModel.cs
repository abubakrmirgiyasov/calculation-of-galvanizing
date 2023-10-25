using System;

namespace SZGC.Domain.ViewModels
{
    public class StageViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortedBy { get; set; }

        public bool IsSumming { get; set; }

        public Guid UserId { get; set; }

        public override string ToString() => Name;

        public string ToSearchString()
        {
            return $"{Name}{DateCreated}";
        }
    }
}
