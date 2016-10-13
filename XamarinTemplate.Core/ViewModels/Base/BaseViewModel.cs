using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Threading;
using XamarinTemplate.Core.IOC;

namespace XamarinTemplate.Core.ViewModels.Base
{
    public abstract class BaseViewModel : EventBaseViewModel
    {
        public Action CloseViewAction { get; set; }

        public bool IsBusy { get; private set; }

        public void ShowViewModel(Type viewModelType, IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
        {
            Modules.NavigationService.ShowViewModel(viewModelType, parameters, syncWithUiThread);
        }

        public void ShowViewModel<T>(IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
            where T : BaseViewModel
        {
            Modules.NavigationService.ShowViewModel<T>(parameters, syncWithUiThread);
        }

        public void GoBack(bool syncWithUiThread = false)
        {
            Action navigationAction = () => Modules.NavigationService.GoBack();

            if (syncWithUiThread)
            {
                RunOnUiThread(navigationAction);
                return;
            }

            navigationAction.Invoke();
        }

        public void SetBusy(bool value, bool showUi = true, string text = "")
        {
            IsBusy = value;

            if (!value)
            {
                Modules.DialogService.CloseBusyDialog();
            }
            else if (showUi)
            {
                Modules.DialogService.ShowBusyDialog(text);
            }
        }

        protected void RunOnUiThread(Action action)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }
    }
}
