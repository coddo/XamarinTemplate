using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Core.REST.Interfaces;
using XamarinTemplate.Core.Services.Interfaces;

namespace XamarinTemplate.Core.IOC
{
    public abstract class Modules
    {
        private static Modules Instance => SimpleIoc.Default.GetInstance<Modules>();

        #region Fields

        private INavigationService mNavigationService;
        private ILoggingService mLoggingService;
        private INetworkService mNetworkService;
        private IHttpClientService mHttpClientService;
        private IRestClient mRestClient;
        private INotificationMessageService mNotificationMessageService;
        private INotificationService mNotificationService;
        private IDialogService mDialogService;
        private IAppSettingsService mSettingsService;
        private IStorageService mStorageService;

        #endregion

        #region Properties

        public static INavigationService NavigationService => Instance.mNavigationService 
            ?? (Instance.mNavigationService = SimpleIoc.Default.GetInstance<INavigationService>());

        public static ILoggingService LoggingService => Instance.mLoggingService 
            ?? (Instance.mLoggingService = SimpleIoc.Default.GetInstance<ILoggingService>());

        public static INetworkService NetworkService => Instance.mNetworkService 
            ?? (Instance.mNetworkService = SimpleIoc.Default.GetInstance<INetworkService>());

        public static IHttpClientService HtppClientService => Instance.mHttpClientService 
            ?? (Instance.mHttpClientService = SimpleIoc.Default.GetInstance<IHttpClientService>());

        public static IRestClient RestClient => Instance.mRestClient 
            ?? (Instance.mRestClient = SimpleIoc.Default.GetInstance<IRestClient>());

        public static INotificationMessageService NotificationMessageService => Instance.mNotificationMessageService 
            ?? (Instance.mNotificationMessageService = SimpleIoc.Default.GetInstance<INotificationMessageService>());

        public static INotificationService NotificationService => Instance.mNotificationService
            ?? (Instance.mNotificationService = SimpleIoc.Default.GetInstance<INotificationService>());

        public static IDialogService DialogService => Instance.mDialogService
            ?? (Instance.mDialogService = SimpleIoc.Default.GetInstance<IDialogService>());

        public static IAppSettingsService SettingsService => Instance.mSettingsService
            ?? (Instance.mSettingsService = SimpleIoc.Default.GetInstance<IAppSettingsService>());

        public static IStorageService StorageService => Instance.mStorageService
            ?? (Instance.mStorageService = SimpleIoc.Default.GetInstance<IStorageService>());

        #endregion
    }
}
