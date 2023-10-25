using SZGC.Desktop.Common.Interfaces;
using SZGC.Desktop.Views.Shared.Interfaces;

namespace SZGC.Desktop.Presenters.Shared
{
    public class LoadPresenter : BasePresenter<ILoadView>
    {
        public LoadPresenter(IApplicationController controller, ILoadView view)
            : base(controller, view) { }

        public void SetStatus(string message)
        {
            View.Status = message;
        }
    }
}
