using System;
using System.Linq.Expressions;

namespace SZGC.Desktop.Common.Interfaces
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : TService;

        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);

        void RegisterInstance<T>(T instance);

        void Register<TService>();

        bool IsRegistered<TService>();

        TService Resolve<TService>();
    }
}
