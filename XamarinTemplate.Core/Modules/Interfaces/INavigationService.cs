using System;
using System.Collections.Generic;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Core.Modules.Interfaces
{
    public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
    {
        IDictionary<string, Type> Views { get; }

        void Configure(string key, Type target);

        void ShowViewModel(string viewModelName, IDictionary<string, string> parameters = null, bool syncWithUiThread = false);

        void ShowViewModel(Type viewModelType, IDictionary<string, string> parameters = null, bool syncWithUiThread = false);

        void ShowViewModel<T>(IDictionary<string, string> parameters = null, bool syncWithUiThread = false)
            where T : BaseViewModel;
    }
}
