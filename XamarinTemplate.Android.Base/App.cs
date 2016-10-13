using Android.App;
using Android.Views;
using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Android.Base.Services;
using XamarinTemplate.Android.Base.UI.Activities.Base;
using XamarinTemplate.Core.Services;
using XamarinTemplate.Core.Services.Interfaces;
using DialogService = XamarinTemplate.Android.Base.Services.DialogService;

namespace XamarinTemplate.Android.Base
{
    public abstract class App : Core.App
    {
        #region Private fields

        private static App mInstance;

        #endregion

        internal static App Instance => mInstance ?? (mInstance = SimpleIoc.Default.GetInstance<App>());

        public override string AppName => Application.Context.GetString(Resource.String.app_name);

        protected App()
        {
            IsAppInitialized = false;
            mInstance = null;
        }

        #region Properties

        public static bool IsAppInitialized { get; private set; }

        public RootViewBaseActivity CurrentActivity { get; set; }

        public View CurrentView => CurrentActivity?.RootView;

        #endregion

        #region Overrides

        public override void InitializeInstance()
        {
            base.InitializeInstance();

            IsAppInitialized = true;
        }

        protected override void InitializeIocContainer()
        {
            base.InitializeIocContainer();

            SimpleIoc.Default.Register(() => new NavigationService());
            SimpleIoc.Default.Register<ILoggingService, LoggingService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<INetworkService, NetworkService>();
            SimpleIoc.Default.Register<INotificationMessageService, NotificationMessageService>();
            SimpleIoc.Default.Register<INotificationService, NotificationService>();
        }

        #endregion
    }
}