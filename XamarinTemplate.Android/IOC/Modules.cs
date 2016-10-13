using GalaSoft.MvvmLight.Ioc;

namespace XamarinTemplate.Android.IOC
{
    public sealed class Modules : Base.IOC.Modules
    {
        private static Modules Instance => SimpleIoc.Default.GetInstance<Modules>();
    }
}