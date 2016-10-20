using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using XamarinTemplate.Core.Containers;
using XamarinTemplate.Core.Enum;
using XamarinTemplate.Core.Models;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Core.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        private ICommand mNavigateCommand;
        private ICommand mNotificationCommand;
        private ICommand mLoadingDialogCommand;

        public ICommand NavigateCommand => mNavigateCommand ?? (mNavigateCommand = new RelayCommand(() => GoBack()));

        public ICommand NotificationCommand => mNotificationCommand ?? (mNotificationCommand = new RelayCommand(NotificationAction));

        public ICommand LoadingDialogCommand => mLoadingDialogCommand ?? (mLoadingDialogCommand = new RelayCommand(LoadingDialogAction));

        protected override void OnParametersSet(IDictionary<string, string> parameters)
        {
            Task.Delay(100).ConfigureAwait(false).GetAwaiter().OnCompleted(() =>
            {
                var text = parameters?["test"];
                CoreServices.NotificationMessageService.ShowInfo(text);
            });
        }

        private void NotificationAction()
        {
            var mainMessage = new AsyncMessage
            {
                TargetViewModel = nameof(MainViewModel),
                Action = MessageAction.BasicTestMainAction,
                Icon = NotificationIcon.AppIcon,
            };
            var secondMessage1 = new AsyncMessage
            {
                TargetViewModel = nameof(MainViewModel),
                Action = MessageAction.BasicTestSecondaryAction,
                Icon = NotificationIcon.AppIcon,
                Title = "First text"
            };
            var secondMessage2 = new AsyncMessage
            {
                TargetViewModel = nameof(MainViewModel),
                Action = MessageAction.BasicTestExtraAction,
                Icon = NotificationIcon.AppIcon,
                Title = "Second text"
            };

            CoreServices.NotificationService.CreateNotification(NotificationIcon.AppIcon, "Sample notification title",
                "afhasifbhaskfhzsifhai fhsauif haifhaskjf hasjklfhas jfhakf haskf", mainMessage,  new[] { secondMessage1, secondMessage2 });
        }

        private void LoadingDialogAction()
        {
            RunOnUiThread(() => CoreServices.DialogService.ShowBusyDialog("Action in progress"));

            Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false).GetAwaiter().OnCompleted(() =>
            {
                RunOnUiThread(() => CoreServices.DialogService.CloseBusyDialog());
            });
        }
    }
}
