using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLite.Net.Interop;
using XamarinTemplate.Models.Interfaces;

namespace XamarinTemplate.Core.Services.Interfaces
{
    public interface IStorageService
    {
        void InitializeDatabase(ISQLitePlatform platform, string storagePath, IEnumerable<Type> ormModelsCollection);

        int Count<T>(Expression<Func<T, bool>> @where) where T : class, IModel;

        bool Any<T>(Func<T, bool> @where) where T : class, IModel;

        bool All<T>(Func<T, bool> @where) where T : class, IModel;

        T Get<T>(Guid key) where T : class, IModel;

        T Get<T>(Expression<Func<T, bool>> @where) where T : class, IModel;

        IList<T> GetAll<T>() where T : class, IModel;

        IList<T> GetList<T>(Expression<Func<T, bool>> @where) where T : class, IModel;

        void Create<T>(T entity) where T : class, IModel;

        void Create<T>(IEnumerable<T> entities) where T : class, IModel;

        void Update<T>(Guid key, T entity) where T : class, IModel;

        void Update<T>(Expression<Func<T, bool>> selector, T entity) where T : class, IModel;

        void Delete<T>(T entity) where T : class, IModel;

        void Delete<T>(IList<T> entities) where T : class, IModel;

        void Delete<T>(Guid key) where T : class, IModel;

        void Delete<T>(Expression<Func<T, bool>> selector) where T : class, IModel;

        void DeleteAll<T>() where T : class, IModel;
    }
}
    