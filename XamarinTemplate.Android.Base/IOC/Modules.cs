using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Android.Base.Services.Interfaces;
using XamarinTemplate.Core.Services;

namespace XamarinTemplate.Android.Base.IOC
{
    public abstract class Modules : Core.IOC.Modules
    {
        private static Modules Instance => SimpleIoc.Default.GetInstance<Modules>();

        #region Fields

        private NavigationService mConcreteNavigationService;
        private INotificationIconService mNotificationIconService;

        #endregion

        #region Properties

        public static INotificationIconService NotificationIconService => Instance.mNotificationIconService
            ?? (Instance.mNotificationIconService = SimpleIoc.Default.GetInstance<INotificationIconService>());

        public static NavigationService ConcreteNavigationService => Instance.mConcreteNavigationService
            ?? (Instance.mConcreteNavigationService = SimpleIoc.Default.GetInstance<NavigationService>());

        #endregion
    }
}