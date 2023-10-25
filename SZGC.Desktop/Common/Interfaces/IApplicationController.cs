namespace SZGC.Desktop.Common.Interfaces
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        TPresenter Create<TPresenter>()
            where TPresenter : class, IPresenter;

        TPresenter Create<TPresenter, TArgument>()
            where TPresenter : class, IPresenter<TArgument>;
    }
}
