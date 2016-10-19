using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using XamarinTemplate.Core.REST.Http;
using XamarinTemplate.Core.REST.Interfaces;
using XamarinTemplate.Core.Services;
using XamarinTemplate.Core.Services.Interfaces;
using XamarinTemplate.Core.ViewModels.Base;
using XamarinTemplate.Core.ViewModels.Management;

namespace XamarinTemplate.Core
{
    public abstract class App
    {
        private static App mInstance;

        internal static App Instance => mInstance ?? (mInstance = SimpleIoc.Default.GetInstance<App>());

        public abstract string AppName { get; }

        public BaseViewModel CurrentViewModel { get; set; }

        public bool IsAppInForeground { get; set; }

        public virtual void InitializeInstance()
        {
            DispatcherHelper.Initialize();
            ViewModelIoc.Initialize();

            InitializeIocContainer();
        }

        public void CleanupInstance()
        {
            DispatcherHelper.Reset();
            ViewModelIoc.Cleanup();

            CleanupIocContainer();
        }

        protected virtual void InitializeIocContainer()
        {
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IHttpClientService, HttpClientService>();
            SimpleIoc.Default.Register<IRestClient, RestClient>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
        }

        protected virtual void CleanupIocContainer()
        {
            SimpleIoc.Default.Reset();
        }
    }
}
