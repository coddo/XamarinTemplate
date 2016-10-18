﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using SQLite.Net;
using SQLite.Net.Interop;
using XamarinTemplate.Core.Services.Interfaces;
using XamarinTemplate.Models.Interfaces;

namespace XamarinTemplate.Core.Services
{
    public abstract class StorageService : IStorageService
    {
        private const string DATABASE_NAME = "MyDatabase.db3";

        private bool mIsInitialized;

        private string mDatabasePath;
        private ISQLitePlatform mPlatform;

        public void InitializeDatabase(ISQLitePlatform platform, string storagePath, IEnumerable<Type> ormModelsCollection)
        {
            if (mIsInitialized)
            {
                return;
            }

            mPlatform = platform;
            mDatabasePath = Path.Combine(storagePath, DATABASE_NAME);

            CreateDatabase(ormModelsCollection);
            mIsInitialized = true;
        }

        public int Count<T>(Expression<Func<T, bool>> @where) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                return database.Table<T>().Count(@where);
            }
        }

        public bool Any<T>(Func<T, bool> @where) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                return database.Table<T>().Any(@where);
            }
        }

        public bool All<T>(Func<T, bool> @where) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                return database.Table<T>().All(@where);
            }
        }

        public T Get<T>(Guid key) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                return database.Get<T>(key);
            }
        }

        public IList<T> GetAll<T>() where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                return database.Table<T>().ToList();
            }
        }

        public IList<T> GetList<T>(Expression<Func<T, bool>> @where) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                return database.Table<T>().Where(@where).ToList();
            }
        }

        public void Create<T>(T entity) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                database.Insert(entity, typeof (T));
            }
        }

        public void Create<T>(IEnumerable<T> entities) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                database.InsertAll(entities, typeof (T));
            }
        }

        public void Update<T>(Guid key, T entity) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                database.Update(entity, typeof (T));
            }
        }

        public void Update<T>(Expression<Func<T, bool>> selector, T entity) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                // TODO
            }
        }

        public void Delete<T>(T entity) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                database.Delete(entity);
            }
        }

        public void Delete<T>(IList<T> entities) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                foreach (var entity in entities)
                {
                    database.Delete(entity);
                }
            }
        }

        public void Delete<T>(Guid key) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                database.Delete<T>(key);
            }
        }

        public void Delete<T>(Expression<Func<T, bool>> selector) where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                var entities = database.Table<T>().Where(selector);

                foreach (var entity in entities)
                {
                    database.Delete(entity);
                }
            }
        }

        public void DeleteAll<T>() where T : class, IModel
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                database.DeleteAll<T>();
            }
        }

        #region Private methods

        private void CreateDatabase(IEnumerable<Type> ormModelsCollection)
        {
            using (var database = new SQLiteConnection(mPlatform, mDatabasePath))
            {
                foreach (var modelType in ormModelsCollection)
                {
                    database.CreateTable(modelType);
                }
            }
        }

        #endregion
    }
}