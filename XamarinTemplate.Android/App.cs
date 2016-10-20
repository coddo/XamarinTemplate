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
            // App components
            var components = new CoreServices();

            SimpleIoc.Default.Register(() => components);
            SimpleIoc.Default.Register<Base.Containers.CoreServices>(() => components);
            SimpleIoc.Default.Register<Core.Containers.CoreServices>(() => components);

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
            CoreServices.NavigationService.Configure(nameof(SplashScreenViewModel), typeof(SplashScreenActivity));
            CoreServices.NavigationService.Configure(nameof(MainViewModel), typeof(MainActivity));
            CoreServices.NavigationService.Configure(nameof(SecondViewModel), typeof(SecondActivity));
        }

        #endregion
    }
}