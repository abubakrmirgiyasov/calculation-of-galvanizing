﻿using LightInject;
using System;
using System.Linq.Expressions;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop
{
    public class LightInjectAdapter : IContainer
    {
        private readonly ServiceContainer _container = new ServiceContainer();

        public bool IsRegistered<TService>()
        {
            return _container.CanGetInstance(typeof(TService), string.Empty);
        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>();
        }

        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.Register(f => factory);
        }

        public void Register<TService>()
        {
            _container.Register<TService>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }

        public TService Resolve<TService>()
        {
            return _container.GetInstance<TService>();
        }
    }
}
