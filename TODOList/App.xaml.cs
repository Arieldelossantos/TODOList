using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using TODOList.Helpers;
using TODOList.Services;
using TODOList.ViewModels;
using TODOList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TODOList
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
          
            await NavigationService.NavigateAsync(new Uri(NavigationPages.TODOsPage, UriKind.Absolute));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Services & Instances
            containerRegistry.Register<ITODODb, TODODb>();
            //Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TODOsPage,TODOsViewModel>();
            containerRegistry.RegisterForNavigation<CreateTaskPage, CreateTaskViewModel>();


        }
    }
}
