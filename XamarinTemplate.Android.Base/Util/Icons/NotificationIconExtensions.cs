using XamarinTemplate.Android.Base.IOC;
using XamarinTemplate.Core.Enum;

namespace XamarinTemplate.Android.Base.Util.Icons
{
    public static class NotificationIconExtensions
    {
        public static int GetResourceId(this NotificationIcon icon)
        {
            return Modules.NotificationIconService.GetValue(icon);
        }
    }
}