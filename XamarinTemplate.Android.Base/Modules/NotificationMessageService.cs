using System;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Widget;
using XamarinTemplate.Android.Base.Containers;
using XamarinTemplate.Android.Base.Util.Extensions;
using XamarinTemplate.Core.Base.Constants;
using XamarinTemplate.Core.Base.Modules.Interfaces;

namespace XamarinTemplate.Android.Base.Modules
{
    public class NotificationMessageService : INotificationMessageService
    {
        public void ShowInfo(string message)
        {
            if (App.Instance.CurrentActivity == null)
            {
                CoreServices.LoggingService.LogException<NotificationMessageService>("The current activity is not set!");
                return;
            }

            App.Instance.CurrentActivity.RunOnUiThread(() =>
            {
                var snackBar = Snackbar.Make(App.Instance.CurrentView, message.ToCharSequence(), Snackbar.LengthLong);
                SetSnackbarStyle(snackBar, NotificationConstants.NOTIFICATION_MESSAGE_INFO_BG_COLOR, NotificationConstants.NOTIFICATION_MESSAGE_INFO_TEXT_COLOR);

                snackBar.Show();
            });
        }

        public void ShowInfo(string message, string actionText, Action action)
        {
            if (App.Instance.CurrentActivity == null)
            {
                CoreServices.LoggingService.LogException<NotificationMessageService>("The current activity is not set!");
                return;
            }

            App.Instance.CurrentActivity.RunOnUiThread(() =>
            {
                var snackBar = Snackbar.Make(App.Instance.CurrentView, message.ToCharSequence(), Snackbar.LengthLong);
                snackBar.SetAction(actionText, (view) => action.Invoke());

                SetSnackbarStyle(snackBar, NotificationConstants.NOTIFICATION_MESSAGE_INFO_BG_COLOR, NotificationConstants.NOTIFICATION_MESSAGE_INFO_TEXT_COLOR,
                    NotificationConstants.NOTIFICATION_MESSAGE_INFO_ACTION_TEXT_COLOR);

                snackBar.Show();
            });
        }

        public void ShowError(string message)
        {
            if (App.Instance.CurrentActivity == null)
            {
                CoreServices.LoggingService.LogException<NotificationMessageService>("The current activity is not set!");
                return;
            }

            App.Instance.CurrentActivity.RunOnUiThread(() =>
            {
                var snackBar = Snackbar.Make(App.Instance.CurrentView, message.ToCharSequence(), Snackbar.LengthLong);
                SetSnackbarStyle(snackBar, NotificationConstants.NOTIFICATION_MESSAGE_ERROR_BG_COLOR, NotificationConstants.NOTIFICATION_MESSAGE_ERROR_TEXT_COLOR);

                snackBar.Show();
            });
        }

        public void ShowError(string message, string actionText, Action action)
        {
            if (App.Instance.CurrentActivity == null)
            {
                CoreServices.LoggingService.LogException<NotificationMessageService>("The current activity is not set!");
                return;
            }

            App.Instance.CurrentActivity.RunOnUiThread(() =>
            {
                var snackBar = Snackbar.Make(App.Instance.CurrentView, message.ToCharSequence(), Snackbar.LengthLong);
                snackBar.SetAction(actionText, (view) => action.Invoke());

                SetSnackbarStyle(snackBar, NotificationConstants.NOTIFICATION_MESSAGE_ERROR_BG_COLOR, NotificationConstants.NOTIFICATION_MESSAGE_ERROR_TEXT_COLOR,
                    NotificationConstants.NOTIFICATION_MESSAGE_ERROR_ACTION_TEXT_COLOR);

                snackBar.Show();
            });
        }

        #region private methods

        private static void SetSnackbarStyle(Snackbar snackbar, string backGroundColor, string textColor, string actionTextColor = null)
        {
            if (snackbar == null || string.IsNullOrWhiteSpace(backGroundColor))
            {
                throw new Exception("invalid params");
            }

            snackbar.View.SetBackgroundColor(Color.ParseColor(backGroundColor));
            snackbar.View.FindViewById<TextView>(Resource.Id.snackbar_text)?.SetTextColor(Color.ParseColor(textColor));

            if (actionTextColor != null)
            {
                snackbar.SetActionTextColor(Color.ParseColor(actionTextColor));
            }
        }

        #endregion
    }
}