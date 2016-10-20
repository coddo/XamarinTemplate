using XamarinTemplate.Android.Base.Containers;
using XamarinTemplate.Core.Enum;

namespace XamarinTemplate.Android.Base.Util.Icons
{
    public static class NotificationIconExtensions
    {
        public static int GetResourceId(this NotificationIcon icon)
        {
            return CoreServices.NotificationIconService.GetValue(icon);
        }
    }
}