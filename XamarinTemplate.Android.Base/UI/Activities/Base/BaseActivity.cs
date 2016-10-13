using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using Newtonsoft.Json;
using XamarinTemplate.Android.Base.IOC;
using XamarinTemplate.Android.Base.Util.Constants;
using XamarinTemplate.Core.ViewModels.Base;
using XamarinTemplate.Core.ViewModels.Management;

namespace XamarinTemplate.Android.Base.UI.Activities.Base
{
    public abstract class BaseActivity<T> : RootViewBaseActivity where T : BaseViewModel
    {
        protected IList<Binding> Bindings { get; } = new List<Binding>();

        protected T ViewModel => ViewModelIoc.GetViewModel<T>();

        protected override void OnStop()
        {
            base.OnStop();

            Bindings?.Clear();
        }

        protected override void OnResume()
        {
            base.OnResume();

            App.Instance.CurrentViewModel = ViewModel;
            ViewModel.CloseViewAction = Finish;

            var parameters = Modules.ConcreteNavigationService.GetAndRemoveParameter<IDictionary<string, string>>(Intent);
            if (parameters == null || parameters.Count == 0)
            {
                var paramsString = Intent.GetStringExtra(ParameterConstants.PARAMETERS_INTENT_KEY);

                if (!string.IsNullOrEmpty(paramsString))
                {
                    parameters = JsonConvert.DeserializeObject<IDictionary<string, string>>(paramsString);
                }
            }

            OnParametersLoaded(parameters);
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (App.Instance.CurrentViewModel != null && App.Instance.CurrentViewModel.GetType() == ViewModel.GetType())
            {
                App.Instance.CurrentViewModel = null;
            }
        }

        protected virtual void OnParametersLoaded(IDictionary<string, string> parameters)
        {
            if (parameters != null)
            {
                ViewModel.SetParameters(parameters);
            }
        }
    }
}