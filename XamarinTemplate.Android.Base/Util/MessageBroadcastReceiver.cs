using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Support.V4.Content;
using Android.Util;
using Java.Lang;
using Newtonsoft.Json;
using XamarinTemplate.Android.Base.Containers;
using XamarinTemplate.Android.Base.Util.Constants;
using XamarinTemplate.Core.Base.Enum;
using XamarinTemplate.Core.Base.Models;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Android.Base.Util
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { ParameterConstants.BROADCAST_RECEIVED_KEY })]
    public class MessageBroadcastReceiver : WakefulBroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                var messageString = intent.GetStringExtra(ParameterConstants.MESSAGE_INTENT_KEY);
                var message = JsonConvert.DeserializeObject<AsyncMessage>(messageString);

                if (message == null)
                {
                    intent.AddFlags(ActivityFlags.TaskOnHome);
                    SetResult(Result.Canceled, null, intent.Extras);

                    return;
                }

                var navigationIntent = CreateNavigationIntent(message);
                PerformActivityNavigation(navigationIntent);

                Task.Delay(100).ConfigureAwait(false).GetAwaiter().OnCompleted(() =>
                {
                    HandleAction(message, intent);

                    intent.AddFlags(ActivityFlags.IncludeStoppedPackages);
                    SetResult(Result.Ok, null, intent.Extras);
                });
            }
            catch (Exception ex)
            {
                if (App.IsAppInitialized)
                {
                    CoreServices.LoggingService.LogException<MessageBroadcastReceiver>(ex);
                }
                else
                {
                    Log.Info(App.Instance.AppName, ex.Message);
                }

                intent.AddFlags(ActivityFlags.TaskOnHome);
                SetResult(Result.Canceled, null, intent.Extras);
            }
        }

        private void HandleAction(AsyncMessage message, Intent intent)
        {
            var notificationId = intent.GetIntExtra(ParameterConstants.NOTIFICATION_ID_INTENT_KEY, -1);
            CoreServices.NotificationService.CloseNotification(notificationId);

            switch (message.Action)
            {
                case MessageAction.BasicTestMainAction:
                    OnMainAction();
                    break;
                case MessageAction.BasicTestSecondaryAction:
                    OnSecondAction();
                    break;
                case MessageAction.BasicTestExtraAction:
                    OnExtraAction();
                    break;
            }
        }

        #region Private helper methods

        private static void PerformActivityNavigation(Intent navigationIntent)
        {
            try
            {
                Application.Context.StartActivity(navigationIntent);
            }
            catch (AndroidRuntimeException)
            {
                navigationIntent.SetFlags(ActivityFlags.NewTask);
                Application.Context.StartActivity(navigationIntent);
            }
        }

        private static Intent CreateNavigationIntent(AsyncMessage message)
        {
            Intent navigationIntent;
            if (!string.IsNullOrEmpty(message.TargetViewModel))
            {
                var view = CoreServices.NavigationService.Views[message.TargetViewModel];
                navigationIntent = new Intent(Application.Context, view);
            }
            else
            {
                var mainView = CoreServices.NavigationService.Views[nameof(MainViewModel)];
                navigationIntent = new Intent(Application.Context, mainView);
            }

            var paramsString = JsonConvert.SerializeObject(message.Parameters);
            navigationIntent.PutExtra(ParameterConstants.PARAMETERS_INTENT_KEY, paramsString);

            return navigationIntent;
        }

        #endregion

        #region Actions

        private void OnMainAction()
        {
            CoreServices.NotificationService.CreateNotification(NotificationIcon.AppIcon, "BAM", "MAIN ACTION COMPLETED");
            CoreServices.NotificationMessageService.ShowInfo("MAIN ACTION COMPLETED");
        }

        private void OnSecondAction()
        {
            CoreServices.NotificationService.CreateNotification(NotificationIcon.AppIcon, "BAM", "SECONDARY ACTION COMPLETED");
            CoreServices.NotificationMessageService.ShowInfo("SECONDARY ACTION COMPLETED");
        }

        private void OnExtraAction()
        {
            CoreServices.NotificationService.CreateNotification(NotificationIcon.AppIcon, "BAM", "EXTRA ACTION COMPLETED");
            CoreServices.NotificationMessageService.ShowInfo("EXTRA ACTION COMPLETED");
        }

        #endregion
    }
}