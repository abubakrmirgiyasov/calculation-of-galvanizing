using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZGC.Desktop.Common.Interfaces
{
    public interface IPresenter
    {
        void Run();

        void Finish();

        void SetOwner(Form owner);
        
        DialogResult RunDialog(Form owner);

        Task<DialogResult> RunDialogAsync(Form owner);
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argumnet);
        
        void SetOwner(Form owner);

        DialogResult RunDialog(TArg argument, Form owner);

        Task<DialogResult> RunDialogAsync(TArg argument, Form owner);

        void Finish();
    }
}