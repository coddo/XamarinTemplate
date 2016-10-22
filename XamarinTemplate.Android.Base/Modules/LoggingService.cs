using System;
using Android.Util;
using XamarinTemplate.Core.Base.Modules.Interfaces;

namespace XamarinTemplate.Android.Base.Modules
{
    public class LoggingService : ILoggingService
    {
        public string Tag => App.Instance.AppName;

        public void LogInfo(string message)
        {
            Log.Info(Tag, message);
        }

        public void LogInfo<T>(string message) where T : class
        {
            Log.Info(Tag, GetMessage<T>(message));
        }

        public void LogWarning(string message)
        {
            Log.Warn(Tag, message);
        }

        public void LogWarning<T>(string message) where T : class
        {
            Log.Warn(Tag, GetMessage<T>(message));
        }

        public void LogException(Exception exception, bool printStackTrace = false)
        {
            var message = printStackTrace ? GetMessage(exception.Source, exception.Message) : exception.Message;

            Log.Error(Tag, message);
        }

        public void LogException<T>(Exception exception, bool printStackTrace = false) where T : class
        {
            var message = printStackTrace ? GetMessage<T>(exception.Source, exception.Message) : exception.Message;

            Log.Error(Tag, message);
        }

        public void LogException(string message)
        {
            Log.Error(Tag, message);
        }

        public void LogException<T>(string message) where T : class
        {
            Log.Error(Tag, GetMessage<T>(message));
        }

        #region Private methods

        private static string GetMessage<T>(string message) where T : class
        {
            return $"[{typeof(T).FullName}] ********* {message}";
        }

        private static string GetMessage<T>(string source, string message) where T : class
        {
            return $"[{typeof(T).FullName}] ********* {source} ----> {message}";
        }

        private static string GetMessage(string source, string message)
        {
            return $"{source} ----> {message}";
        }

        #endregion
    }
}