using System.Collections.Generic;
using XamarinTemplate.Core.Base.Enum;
using XamarinTemplate.Core.Base.Models;

namespace XamarinTemplate.Core.Base.Modules.Interfaces
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
