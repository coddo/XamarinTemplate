using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Android.Base.Services.Interfaces;
using XamarinTemplate.Android.IOC;
using XamarinTemplate.Android.Services;
using XamarinTemplate.Android.UI.Activities;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Android
{
    public sealed class App : Base.App
    {
        private static App mInstance;

        internal static App Instance => mInstance ?? (mInstance = SimpleIoc.Default.GetInstance<App>());

        public static void Initialize()
        {
            // App IOC
            var modules = new Modules();

            SimpleIoc.Default.Register(() => modules);
            SimpleIoc.Default.Register<Base.IOC.Modules>(() => modules);
            SimpleIoc.Default.Register<Core.IOC.Modules>(() => modules);

            // App
            mInstance = new App();
            mInstance.InitializeInstance();

            SimpleIoc.Default.Register(() => mInstance);
            SimpleIoc.Default.Register<Base.App>(() => mInstance);
            SimpleIoc.Default.Register<Core.App>(() => mInstance);
        }

        public override void InitializeInstance()
        {
            base.InitializeInstance();

            InitializeNavigationBindings();
        }

        protected override void InitializeIocContainer()
        {
            base.InitializeIocContainer();

            SimpleIoc.Default.Register<INotificationIconService, NotificationIconService>();
        }

        #region Private initialization methods

        private void InitializeNavigationBindings()
        {
            Modules.NavigationService.Configure(nameof(SplashScreenViewModel), typeof(SplashScreenActivity));
            Modules.NavigationService.Configure(nameof(MainViewModel), typeof(MainActivity));
            Modules.NavigationService.Configure(nameof(SecondViewModel), typeof(SecondActivity));
        }

        #endregion
    }
}