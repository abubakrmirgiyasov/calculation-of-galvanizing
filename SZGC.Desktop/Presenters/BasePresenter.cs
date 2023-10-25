using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Presenters
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }

        protected IApplicationController Controller { get; private set; }

        public BasePresenter(IApplicationController controller, TView view)
        {
            View = view;
            Controller = controller;
        }

        public void Run()
        {
            View.Show();
        }

        public void Finish()
        {
            View.Close();
        }

        public DialogResult RunDialog(Form owner)
        {
            SetOwner(owner);
            return View.ShowDialog();
        }

        public async Task<DialogResult> RunDialogAsync(Form owner)
        {
            await Task.Yield();

            if (View.IsDisposed)
            {
                return View.DialogResult;
            }
            else
            {
                SetOwner(owner);
                return View.ShowDialog();
            }
        }

        public void SetOwner(Form owner)
        {
            View.Owner = owner ?? throw new Exception("Владелец формы не установлен");
        }
    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }

        protected IApplicationController Controller { get; private set; }

        public BasePresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run(TArg argument);

        public abstract void Finish();

        public abstract DialogResult RunDialog(TArg argument, Form owner);

        public abstract void SetOwner(Form owner);

        public abstract Task<DialogResult> RunDialogAsync(TArg argument, Form owner);
    }
}
