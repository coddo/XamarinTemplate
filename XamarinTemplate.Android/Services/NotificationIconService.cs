using System.Collections.Generic;
using XamarinTemplate.Android.Base.Services.Interfaces;
using XamarinTemplate.Core.Enum;

namespace XamarinTemplate.Android.Services
{
    public class NotificationIconService : INotificationIconService
    {
        private IDictionary<NotificationIcon, int> Map { get; set; }

        public NotificationIconService()
        {
            InitMap();
        }

        public int GetValue(NotificationIcon icon)
        {
            return Map[icon];
        }

        private void InitMap()
        {
            Map = new Dictionary<NotificationIcon, int>
            {
                {NotificationIcon.AppIcon, Resource.Drawable.app_icon}
            };
        }
    }
}