using System;

namespace XamarinTemplate.Core.Services.Interfaces
{
    public interface INotificationMessageService
    {
        void ShowInfo(string message);

        void ShowInfo(string message, string actionText, Action action);

        void ShowError(string message);

        void ShowError(string message, string actionText, Action action);
    }
}
