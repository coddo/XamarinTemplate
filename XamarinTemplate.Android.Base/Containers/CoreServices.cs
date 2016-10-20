using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Core.Base.Modules;

namespace XamarinTemplate.Android.Base.Containers
{
    public abstract class CoreServices : Core.Base.Containers.CoreServices
    {
        private static CoreServices Instance => SimpleIoc.Default.GetInstance<CoreServices>();

        #region Fields

        private NavigationService mConcreteNavigationService;

        #endregion

        #region Properties

        public static NavigationService ConcreteNavigationService => Instance.mConcreteNavigationService
            ?? (Instance.mConcreteNavigationService = SimpleIoc.Default.GetInstance<NavigationService>());

        #endregion
    }
}