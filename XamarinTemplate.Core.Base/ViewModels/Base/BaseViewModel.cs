using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Threading;
using XamarinTemplate.Core.Base.Containers;

namespace XamarinTemplate.Core.Base.ViewModels.Base
{
    public abstract class BaseViewModel : EventBaseViewModel
    {
        public Action CloseViewAction { get; set; }

        public bool IsBusy { get; private set; }

        public void ShowViewModel(Type viewModelType, IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
        {
            CoreServices.NavigationService.ShowViewModel(viewModelType, parameters, syncWithUiThread);
        }

        public void ShowViewModel<T>(IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
            where T : BaseViewModel
        {
            CoreServices.NavigationService.ShowViewModel<T>(parameters, syncWithUiThread);
        }

        public void GoBack(bool syncWithUiThread = false)
        {
            Action navigationAction = () => CoreServices.NavigationService.GoBack();

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
                CoreServices.DialogService.CloseBusyDialog();
            }
            else if (showUi)
            {
                CoreServices.DialogService.ShowBusyDialog(text);
            }
        }

        protected void RunOnUiThread(Action action)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }
    }
}
