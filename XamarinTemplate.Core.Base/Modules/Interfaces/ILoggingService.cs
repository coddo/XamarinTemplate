using System;

namespace XamarinTemplate.Core.Base.Modules.Interfaces
{
    public interface ILoggingService
    {
        string Tag { get; }

        void LogInfo(string message);

        void LogInfo<T>(string message) where T : class;

        void LogWarning(string message);

        void LogWarning<T>(string message) where T : class;

        void LogException(Exception exception, bool printStackTrace = false);

        void LogException<T>(Exception exception, bool printStackTrace = false) where T : class;

        void LogException(string message);

        void LogException<T>(string message) where T : class;
    }
}
