using System;
using System.Collections.Generic;

namespace SZGC.Domain.BindingModels
{
    public class OrderBindingModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumOfHitchStation { get; set; }

        public int CountTraverse { get; set; }

        public int Time { get; set; }

        public List<OrderNomenclatureBindingModel> OrderNomenclatures { get; set; } 
    }
}
