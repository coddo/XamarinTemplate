using System;
using System.Collections.Generic;

namespace XamarinTemplate.Core.Base.Modules.Interfaces
{
    public interface IAppSettingsService
    {
        /// <summary>
        /// Sets a value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void Set(string key, string value);

        /// <summary>
        /// Sets all the values to the corresponding keys from the given dictionary of data
        /// </summary>
        /// <param name="data">The Dictionary containing keys and values to be stored in the app settings</param>
        void Set(IDictionary<string, string> data);

        /// <summary>
        /// Sets all the values to the corresponding keys from the given dictionary of data
        /// </summary>
        /// <typeparam name="T">The type of the entity that needs to be stored</typeparam>
        /// <param name="key">The key where to save the data</param>
        /// <param name="entity">The entity of type T that needs to be stored</param>
        void Set<T>(string key, T entity) where T : class;

        /// <summary>
        /// Sets a value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void Set(string key, Guid value);

        /// <summary>
        /// Sets an Integer value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void SetInt(string key, int value);

        /// <summary>
        /// Sets an Long Integer value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void SetLong(string key, long value);

        /// <summary>
        /// Sets a Float value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void SetFloat(string key, float value);

        /// <summary>
        /// Sets a Double value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void SetDouble(string key, double value);

        /// <summary>
        /// Sets a Bool value to the given key in the application settings. If the key already exists, its value will be replaced
        /// </summary>
        /// <param name="key">The key where to save the data</param>
        /// <param name="value">The data that needs to be stored</param>
        void SetBool(string key, bool value);

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as String</returns>
        string Get(string key, string defaultValue = null);

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <typeparam name="T">The type of object that is stored at the given key</typeparam>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value casted to the specified type</returns>
        T Get<T>(string key, T defaultValue = null) where T : class;

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as Guid</returns>
        Guid GetGuid(string key, Guid defaultValue = default(Guid));

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as Integer</returns>
        int GetInt(string key, int defaultValue = default(int));

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as Long Integer</returns>
        long GetLong(string key, long defaultValue = default(long));

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as Float</returns>
        float GetFloat(string key, float defaultValue = default(float));

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as Double</returns>
        double GetDouble(string key, double defaultValue = default(double));

        /// <summary>
        /// Get the value from a specified key stored in the application settings
        /// </summary>
        /// <param name="key">The key at which the value is stored</param>
        /// <param name="defaultValue">The default value to be returned if the key is not found</param>
        /// <returns>The stored value as Bool</returns>
        bool GetBool(string key, bool defaultValue = default(bool));

        /// <summary>
        /// Deletes a value that is stored at the given key
        /// </summary>
        /// <param name="key">The key at which to delete the data</param>
        void Delete(string key);
    }
}
