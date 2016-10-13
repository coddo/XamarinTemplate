using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using XamarinTemplate.Core.IOC;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand mNavigateCommand;
        private ICommand mShowInfoMessageCommand;
        private ICommand mShowInfoMessageWithActionCommand;
        private ICommand mShowErrorMessageCommand;
        private ICommand mShowErrorMessageWithActionCommand;

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

        private void ShowInfoMessage()
        {
            Modules.NotificationMessageService.ShowInfo("SOME INFO");
        }

        private void ShowInfoMessageWithAction()
        {
            Modules.NotificationMessageService.ShowInfo("SOME INFO", "Random Action",
                () => Modules.NotificationMessageService.ShowInfo("INFO ACTION CLICKED!"));
        }

        private void ShowErrorMessage()
        {
            Modules.NotificationMessageService.ShowError("SOME INFO");
        }

        private void ShowErrorMessageWithAction()
        {
            Modules.NotificationMessageService.ShowError("SOME INFO", "Random Action",
                () => Modules.NotificationMessageService.ShowError("ERROR ACTION CLICKED!"));
        }
    }
}