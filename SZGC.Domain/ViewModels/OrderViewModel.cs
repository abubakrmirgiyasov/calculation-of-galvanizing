using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SZGC.Domain.Settings;

namespace SZGC.Domain.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumOfHitchStation { get; set; }

        public int CountTraverse { get; set; }

        public int Time { get; set; }

        public DateTime DateCreated { get; set; }

        public List<OrderNomenclatureViewModel> OrderNomenclatures { get; set; }

        [JsonIgnore]
        public string TimeFormat
        {
            get
            {
                double hours = Math.Truncate(Time / 60.0);
                int minutes = Time % 60;
                if (hours > 0)
                {
                    double days = Math.Truncate(hours / Shared.WorkingShift);
                    if (days > 0)
                    {
                        if (days < 2)
                        {
                            return $"{days} смена {hours - days * Shared.WorkingShift} ч {minutes} мин";
                        }
                        else if (days < 5)
                        {
                            return $"{days} смены {hours - days * Shared.WorkingShift} ч {minutes} мин";
                        }
                        else
                        {
                            return $"{days} смен {hours - days * Shared.WorkingShift} ч {minutes} мин";
                        }
                    }
                    else
                    {
                        return $"{hours} ч {minutes} мин";
                    }
                }
                else
                {
                    return $"{minutes} мин";
                }
            }
        }

        public string ToSearchString()
        {
            return $"{Name}{Time}{DateCreated}";
        }
    }
}
