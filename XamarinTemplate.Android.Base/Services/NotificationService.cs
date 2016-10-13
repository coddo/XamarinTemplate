using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Newtonsoft.Json;
using XamarinTemplate.Android.Base.Util.Constants;
using XamarinTemplate.Android.Base.Util.Icons;
using XamarinTemplate.Core.Enum;
using XamarinTemplate.Core.Models;
using XamarinTemplate.Core.Services.Interfaces;
using XamarinTemplate.Models.Extensions;

namespace XamarinTemplate.Android.Base.Services
{
    public class NotificationService : INotificationService
    {
        private const string ARGUMENT_OUT_OF_RANGE_EXCEPTION_MESSAGE = "The message collection for local notifications with actions must contain " 
            + "at least one element and no more than three. Local notifications support a maximum number of 3 secondary actions";

        private int mIntentCount;
        private NotificationManager mNotificationManager;

        public NotificationService()
        {
            mIntentCount = 1;
        }

        private NotificationManager NotificationManager => mNotificationManager
            ?? (mNotificationManager = Application.Context.GetSystemService(Context.NotificationService) as NotificationManager);

        public void CreateNotification(NotificationIcon smallIcon, string title, string text)
        {
            var builder = CreateBasicNotificationBuilder(smallIcon, title, text);

            NotificationManager.Notify(mIntentCount++, builder.Build());
        }

        public void CreateNotification(NotificationIcon smallIcon, string title, string text, AsyncMessage mainMessage)
        {
            var intentId = mIntentCount;

            var builder = CreateBasicNotificationBuilder(mainMessage.Icon, title, text);
            builder.SetContentIntent(GetIntentFromMessage(mainMessage, mIntentCount));

            NotificationManager.Notify(intentId, builder.Build());
        }

        public void CreateNotification(NotificationIcon smallIcon, string title, string text, IList<AsyncMessage> messages)
        {
            if (!messages.Any() || messages.Count() > 3)
            {
                throw new ArgumentOutOfRangeException(ARGUMENT_OUT_OF_RANGE_EXCEPTION_MESSAGE);
            }

            var intentId = mIntentCount;

            var builder = CreateBasicNotificationBuilder(smallIcon, title, text);

            foreach (var message in messages)
            {
                builder.AddAction(global::Android.Resource.Drawable.IcMenuInfoDetails, message.Title, GetIntentFromMessage(message, intentId));
            }

            NotificationManager.Notify(intentId, builder.Build());
        }

        public void CreateNotification(NotificationIcon smallIcon, string title, string text, AsyncMessage mainMessage, IList<AsyncMessage> messages)
        {
            if (!messages.Any() || messages.Count() > 3)
            {
                throw new ArgumentOutOfRangeException(ARGUMENT_OUT_OF_RANGE_EXCEPTION_MESSAGE);
            }

            var intentId = mIntentCount;

            var builder = CreateBasicNotificationBuilder(smallIcon, title, text);
            builder.SetContentIntent(GetIntentFromMessage(mainMessage, mIntentCount));

            foreach (var message in messages)
            {
                builder.AddAction(global::Android.Resource.Drawable.IcMenuInfoDetails, message.Title, GetIntentFromMessage(message, intentId));
            }

            NotificationManager.Notify(intentId, builder.Build());
        }

        public void CloseNotification(int id)
        {
            if (id <= 0)
            {
                return;
            }

            NotificationManager.Cancel(id);
        }

        #region Private methods

        private static NotificationCompat.Builder CreateBasicNotificationBuilder(NotificationIcon smallIcon, string title, string text)
        {
            var builder = new NotificationCompat.Builder(Application.Context);
            builder.SetSmallIcon(smallIcon.GetResourceId());
            builder.SetContentTitle(title);
            builder.SetContentText(text);
            builder.SetDefaults(NotificationDefaults.All.ToInt());
            builder.SetStyle(new NotificationCompat.BigTextStyle().BigText(text));
            builder.SetAutoCancel(true);

            return builder;
        }

        private PendingIntent GetIntentFromMessage(AsyncMessage message, int notificationId)
        {
            var messageString = JsonConvert.SerializeObject(message);

            var intent = new Intent(ParameterConstants.BROADCAST_RECEIVED_KEY);

            intent.PutExtra(ParameterConstants.MESSAGE_INTENT_KEY, messageString);
            intent.PutExtra(ParameterConstants.NOTIFICATION_ID_INTENT_KEY, notificationId);

            return PendingIntent.GetBroadcast(Application.Context, mIntentCount++, intent, PendingIntentFlags.OneShot);
        }

        #endregion
    }
}