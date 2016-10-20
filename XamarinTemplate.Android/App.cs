using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Android.Containers;
using XamarinTemplate.Android.Modules;
using XamarinTemplate.Android.UI.Activities;
using XamarinTemplate.Core.Modules.Interfaces;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Android
{
    public sealed class App : Base.App
    {
        private static App mInstance;

        internal static App Instance => mInstance ?? (mInstance = SimpleIoc.Default.GetInstance<App>());

        public static void Initialize()
        {
            InitializeServices();
            InitializeApp();
        }

        #region Overrides

        public override void InitializeInstance()
        {
            base.InitializeInstance();

            InitializeNavigationBindings();
        }

        protected override void RegisterCoreServices()
        {
            base.RegisterCoreServices();

            SimpleIoc.Default.Register<INotificationIconService, NotificationIconService>();
        }

        protected override void RegisterServices()
        {
            base.RegisterServices();
        }

        #endregion

        #region App initialization methods

        private static void InitializeApp()
        {
            mInstance = new App();
            mInstance.InitializeInstance();

            SimpleIoc.Default.Register(() => mInstance);
            SimpleIoc.Default.Register<Base.App>(() => mInstance);
            SimpleIoc.Default.Register<Core.App>(() => mInstance);
        }

        private static void InitializeServices()
        {
            // App Core services
            var coreServices = new CoreServices();

            SimpleIoc.Default.Register(() => coreServices);
            SimpleIoc.Default.Register<Base.Containers.CoreServices>(() => coreServices);
            SimpleIoc.Default.Register<Core.Containers.CoreServices>(() => coreServices);

            // App services
            var services = new Services();

            SimpleIoc.Default.Register(() => services);
            SimpleIoc.Default.Register<Base.Containers.Services>(() => services);
            SimpleIoc.Default.Register<Core.Containers.Services>(() => services);
        }

        private void InitializeNavigationBindings()
        {
            CoreServices.NavigationService.Configure(nameof(SplashScreenViewModel), typeof(SplashScreenActivity));
            CoreServices.NavigationService.Configure(nameof(MainViewModel), typeof(MainActivity));
            CoreServices.NavigationService.Configure(nameof(SecondViewModel), typeof(SecondActivity));
        }

        #endregion
    }
}