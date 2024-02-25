﻿using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using VisualApp.Views;

namespace VisualApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {
            containerRegistry.Register<Services.IHeroService, Services.HeroService>();
        }
    }
}
