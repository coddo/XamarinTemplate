using GalaSoft.MvvmLight.Ioc;
using XamarinTemplate.Core.ViewModels.Management;

namespace XamarinTemplate.Core
{
    public abstract class App : Base.App
    {
        private static App mInstance;

        internal static App Instance => mInstance ?? (mInstance = SimpleIoc.Default.GetInstance<App>());

        public override void InitializeInstance()
        {
            base.InitializeInstance();

            ViewModelIoc.Initialize();
        }

        public override void CleanupInstance()
        {
            base.CleanupInstance();

            ViewModelIoc.Cleanup();
        }
    }
}
