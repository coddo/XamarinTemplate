using GalaSoft.MvvmLight.Ioc;

namespace XamarinTemplate.Android.Containers
{
    public class Services : Base.Containers.Services
    {
        private static CoreServices Instance => SimpleIoc.Default.GetInstance<CoreServices>();
    }
}