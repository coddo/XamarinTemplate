using System;
using System.Collections.Generic;
using System.Globalization;
using Android.App;
using Android.Content;
using Newtonsoft.Json;
using XamarinTemplate.Core.IOC;
using XamarinTemplate.Core.Services.Interfaces;

namespace XamarinTemplate.Android.Base.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly ISharedPreferences mPreferences;

        public AppSettingsService()
        {
            mPreferences = Application.Context.GetSharedPreferences(App.Instance.AppName, FileCreationMode.Private);
        }

        public void Set(string key, string value)
        {
            var editor = mPreferences.Edit();

            editor.PutString(key, value);

            CommitChanges(editor);
        }

        public void Set(IDictionary<string, string> data)
        {
            var editor = mPreferences.Edit();

            foreach (var entry in data)
            {
                editor.PutString(entry.Key, entry.Value);
            }

            CommitChanges(editor);
        }

        public void Set<T>(string key, T entity) where T : class
        {
            var editor = mPreferences.Edit();

            var serializedObject = JsonConvert.SerializeObject(entity);
            editor.PutString(key, serializedObject);

            CommitChanges(editor);
        }

        public void Set(string key, Guid value)
        {
            var editor = mPreferences.Edit();

            editor.PutString(key, value.ToString());

            CommitChanges(editor);
        }

        public void SetInt(string key, int value)
        {
            var editor = mPreferences.Edit();

            editor.PutInt(key, value);

            CommitChanges(editor);
        }

        public void SetLong(string key, long value)
        {
            var editor = mPreferences.Edit();

            editor.PutLong(key, value);

            CommitChanges(editor);
        }

        public void SetFloat(string key, float value)
        {
            var editor = mPreferences.Edit();

            editor.PutFloat(key, value);

            CommitChanges(editor);
        }

        public void SetDouble(string key, double value)
        {
            var editor = mPreferences.Edit();

            editor.PutString(key, value.ToString(CultureInfo.InvariantCulture));

            CommitChanges(editor);
        }

        public void SetBool(string key, bool value)
        {
            var editor = mPreferences.Edit();

            editor.PutBoolean(key, value);

            CommitChanges(editor);
        }

        public string Get(string key, string defaultValue = null)
        {
            return mPreferences.GetString(key, defaultValue);
        }

        public T Get<T>(string key, T defaultValue = default(T)) where T : class
        {
            var serializedEntity = mPreferences.GetString(key, null);

            return string.IsNullOrEmpty(serializedEntity) ? defaultValue : JsonConvert.DeserializeObject<T>(serializedEntity);
        }

        public Guid GetGuid(string key, Guid defaultValue = new Guid())
        {
            var stringValue = mPreferences.GetString(key, null);
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            Guid value;
            return !Guid.TryParse(stringValue, out value) ? defaultValue : value;
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            return mPreferences.GetInt(key, defaultValue);
        }

        public long GetLong(string key, long defaultValue = 0)
        {
            return mPreferences.GetLong(key, defaultValue);
        }

        public float GetFloat(string key, float defaultValue = 0)
        {
            return mPreferences.GetFloat(key, defaultValue);
        }

        public double GetDouble(string key, double defaultValue = 0)
        {
            var stringValue = mPreferences.GetString(key, null);
            if (string.IsNullOrEmpty(stringValue))
            {
                return defaultValue;
            }

            double value;
            return !double.TryParse(stringValue, out value) ? defaultValue : value;
        }

        public bool GetBool(string key, bool defaultValue = false)
        {
            return mPreferences.GetBoolean(key, defaultValue);
        }

        public void Delete(string key)
        {
            var editor = mPreferences.Edit();

            editor.Remove(key);

            CommitChanges(editor);
        }

        #region Private methods

        private static void CommitChanges(ISharedPreferencesEditor editor)
        {
            var isSuccessful = editor.Commit();
            if (!isSuccessful)
            {
                Modules.LoggingService.LogInfo("Saving the application preferences failed");
            }
        }

        #endregion
    }
}