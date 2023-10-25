using System;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Order.Interfaces
{
    public interface IAdvancedOrderSearchView : IView, IMessage
    {
        event Action Finish;

        DateTime TopDate { get; set; }

        DateTime BottomDate { get; set; }

        bool IsEnabled { get; set; }

        string OrderName { get; set; }

        string Time { get; set; }

        bool Cancel { get; set; }
    }
}
