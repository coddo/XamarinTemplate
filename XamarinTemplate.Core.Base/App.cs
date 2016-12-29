using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using PortableRestClient.Http;
using PortableRestClient.Interfaces;
using XamarinTemplate.Core.Base.Modules;
using XamarinTemplate.Core.Base.Modules.Interfaces;
using XamarinTemplate.Core.Base.ViewModels.Base;

namespace XamarinTemplate.Core.Base
{
    public abstract class App
    {
        public abstract string AppName { get; }

        public BaseViewModel CurrentViewModel { get; set; }

        public bool IsAppInForeground { get; set; }

        public virtual void InitializeInstance()
        {
            DispatcherHelper.Initialize();

            InitializeIocContainer();
        }

        public virtual void CleanupInstance()
        {
            DispatcherHelper.Reset();

            CleanupIocContainer();
        }

        private void InitializeIocContainer()
        {
            RegisterCoreServices();
            RegisterServices();
        }

        private void CleanupIocContainer()
        {
            SimpleIoc.Default.Reset();
        }

        #region Service registration

        protected virtual void RegisterCoreServices()
        {
            SimpleIoc.Default.Register<IRestClient, RestClient>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
        }

        protected virtual void RegisterServices()
        {

        }

        #endregion
    }
}
