using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using XamarinTemplate.Core.Base.ViewModels.Base;

namespace XamarinTemplate.Core.ViewModels.Management
{
    public static class ViewModelIoc
    {
        public static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<SplashScreenViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SecondViewModel>();
        }

        public static void Cleanup()
        {
            ServiceLocator.SetLocatorProvider(null);

            UnregisterViewModel<SplashScreenViewModel>();
            UnregisterViewModel<MainViewModel>();
            UnregisterViewModel<SecondViewModel>();
        }

        public static T GetViewModel<T>() where T : BaseViewModel
        {
            return ServiceLocator.Current.GetInstance<T>();
        }

        private static void UnregisterViewModel<T>() where T : BaseViewModel
        {
            if (SimpleIoc.Default.IsRegistered<T>())
            {
                SimpleIoc.Default.Unregister<T>();
            }
        }
    }
}