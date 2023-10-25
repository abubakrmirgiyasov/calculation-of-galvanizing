using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Main.Interfaces
{
    public interface IMainView : IView, IMessage
    {
        event Action Start;

        event Action Finish;

        event Action Settings;

        event Action Nomenclature;

        event Action Order;

        event Action Stage;

        event Action Add;

        event Action Edit;

        event Action Remove;

        event Action Search;

        event Action Reset;

        event Action DoubleClickToDataGrid;

        event Action AdvancedSearch;

        event Action AddBasedOn;

        string ButtonTag { get; set; }

        string SearchText { get; set; }

        bool Cancel { get; set; }

        bool SelectedRow { get; }

        int SelectedRowPosition { get; set; }

        StageViewModel SelectedRowStage { get; set; }

        Guid SelectedRowId { get; set; }

        T DataBoundItem<T>() where T : class;

        void ShowData<T>(List<T> items);
    }
}
