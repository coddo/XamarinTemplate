using System.Collections.Generic;
using XamarinTemplate.Core.Enum;
using XamarinTemplate.Core.Models;

namespace XamarinTemplate.Core.Services.Interfaces
{
    public interface INotificationService
    {
        void CreateNotification(NotificationIcon smallIcon, string title, string text);

        void CreateNotification(NotificationIcon smallIcon, string title, string text, AsyncMessage mainMessage);

        void CreateNotification(NotificationIcon smallIcon, string title, string text, IList<AsyncMessage> messages);

        void CreateNotification(NotificationIcon smallIcon, string title, string text, AsyncMessage mainMessage, IList<AsyncMessage> messages);

        void CloseNotification(int id);
    }
}
