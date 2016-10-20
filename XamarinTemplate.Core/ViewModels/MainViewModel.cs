using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using XamarinTemplate.Core.Containers;
using XamarinTemplate.Core.ViewModels.Base;
using XamarinTemplate.Models.Models;

namespace XamarinTemplate.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private const string SETTINGS_TEST_KEY = "someKey";
        private static readonly Guid mDatabaseTestId = Guid.NewGuid();

        private Task mSettingsTask;
        private Task mDatabaseTask;

        private ICommand mNavigateCommand;
        private ICommand mShowInfoMessageCommand;
        private ICommand mShowInfoMessageWithActionCommand;
        private ICommand mShowErrorMessageCommand;
        private ICommand mShowErrorMessageWithActionCommand;
        private ICommand mGetStoreClearSettings;
        private ICommand mGetStoreClearDatabase;

        public ICommand NavigateCommand => mNavigateCommand
            ?? (mNavigateCommand = new RelayCommand(() => ShowViewModel<SecondViewModel>(new Dictionary<string, string>
            {
                {"test", "BOOOOYYEEEEAAHHH!!!"}
            })));

        public ICommand ShowInfoMessageCommand => mShowInfoMessageCommand
            ?? (mShowInfoMessageCommand = new RelayCommand(ShowInfoMessage));

        public ICommand ShowInfoMessageWithActionCommand => mShowInfoMessageWithActionCommand
            ?? (mShowInfoMessageWithActionCommand = new RelayCommand(ShowInfoMessageWithAction));

        public ICommand ShowErrorMessageCommand => mShowErrorMessageCommand
            ?? (mShowErrorMessageCommand = new RelayCommand(ShowErrorMessage));

        public ICommand ShowErrorMessageWithActionCommand => mShowErrorMessageWithActionCommand
            ?? (mShowErrorMessageWithActionCommand = new RelayCommand(ShowErrorMessageWithAction));

        public ICommand GetStoreClearSettings => mGetStoreClearSettings
            ?? (mGetStoreClearSettings = new RelayCommand(GetStoreClearSettingsAction));

        public ICommand GetStoreClearDatabase => mGetStoreClearDatabase
            ?? (mGetStoreClearDatabase = new RelayCommand(GetStoreClearDatabaseAction));

        private void ShowInfoMessage()
        {
            CoreServices.NotificationMessageService.ShowInfo("SOME INFO");
        }

        private void ShowInfoMessageWithAction()
        {
            CoreServices.NotificationMessageService.ShowInfo("SOME INFO", "Random Action",
                () => CoreServices.NotificationMessageService.ShowInfo("INFO ACTION CLICKED!"));
        }

        private void ShowErrorMessage()
        {
            CoreServices.NotificationMessageService.ShowError("SOME INFO");
        }

        private void ShowErrorMessageWithAction()
        {
            CoreServices.NotificationMessageService.ShowError("SOME INFO", "Random Action",
                () => CoreServices.NotificationMessageService.ShowError("ERROR ACTION CLICKED!"));
        }

        private void GetStoreClearSettingsAction()
        {
            var value = CoreServices.AppSettingsService.Get(SETTINGS_TEST_KEY);
            if (string.IsNullOrEmpty(value))
            {
                CoreServices.NotificationMessageService.ShowError("No data found in settings. Will store it as 'HELLO WOLRD!' " + "and delete it" +
                                                             " after 10 seconds");

                CoreServices.AppSettingsService.Set(SETTINGS_TEST_KEY, "HELLO WORLD!");
                
                CreateSettingsTask();
            }
            else
            {
                CoreServices.NotificationMessageService.ShowInfo($"VALUES IS: {value}");

                if (mSettingsTask == null)
                {
                    CreateSettingsTask();
                }
            }
        }

        private void GetStoreClearDatabaseAction()
        {
            var value = CoreServices.StorageService.Get<User>(mDatabaseTestId);
            if (value == null)
            {
                CoreServices.NotificationMessageService.ShowError("No data found in settings. Will store a random new " + "user and delete it after 10 seconds");

                CoreServices.StorageService.Create(new User
                {
                    Email = "some_email@emails.com",
                    Id = mDatabaseTestId,
                });

                CreateDatabaseTask();
            }
            else
            {
                var serializedObject = JsonConvert.SerializeObject(value);
                CoreServices.NotificationMessageService.ShowInfo($"VALUES IS: {serializedObject}");

                if (mDatabaseTask == null)
                {
                    CreateDatabaseTask();
                }
            }
        }

        private void CreateSettingsTask()
        {
            mSettingsTask = Task.Delay(TimeSpan.FromSeconds(10));
            mSettingsTask.ConfigureAwait(false).GetAwaiter().OnCompleted(() =>
            {
                CoreServices.AppSettingsService.Delete(SETTINGS_TEST_KEY);
                CoreServices.NotificationMessageService.ShowInfo("Settings value deleted");
                mSettingsTask = null;
            });
        }

        private void CreateDatabaseTask()
        {
            mDatabaseTask = Task.Delay(TimeSpan.FromSeconds(10));
            mDatabaseTask.ConfigureAwait(false).GetAwaiter().OnCompleted(() =>
            {
                CoreServices.StorageService.Delete<User>(mDatabaseTestId);
                CoreServices.NotificationMessageService.ShowInfo("Database entity deleted");
                mDatabaseTask = null;
            });
        }
    }
}