using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Threading;
using XamarinTemplate.Core.Base.Modules.Interfaces;
using XamarinTemplate.Core.Base.ViewModels.Base;

namespace XamarinTemplate.Core.Base.Modules
{
    public class NavigationService : GalaSoft.MvvmLight.Views.NavigationService, INavigationService
    {
        public IDictionary<string, Type> Views { get; }

        public NavigationService()
        {
            Views = new Dictionary<string, Type>();
        }

        public new void Configure(string key, Type target)
        {
            base.Configure(key, target);

            Views.Add(key, target);
        }

        public void ShowViewModel(string viewModelName, IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            Action navigationAction = () => NavigateTo(viewModelName, parameters);

            if (syncWithUiThread)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(navigationAction);
                return;
            }

            navigationAction.Invoke();
        }

        public void ShowViewModel(Type viewModelType, IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            Action navigationAction = () => NavigateTo(viewModelType.Name, parameters);

            if (syncWithUiThread)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(navigationAction);
                return;
            }

            navigationAction.Invoke();
        }

        public void ShowViewModel<T>(IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
            where T : BaseViewModel
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            Action navigationAction = () => NavigateTo(typeof(T).Name, parameters);

            if (syncWithUiThread)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(navigationAction);
                return;
            }

            navigationAction.Invoke();
        }
    }
}
