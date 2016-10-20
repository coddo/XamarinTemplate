using GalaSoft.MvvmLight.Ioc;

namespace XamarinTemplate.Android.Containers
{
    public sealed class CoreServices : Base.Containers.CoreServices
    {
        private static CoreServices Instance => SimpleIoc.Default.GetInstance<CoreServices>();
    }
}