using System.Collections.Generic;
using GalaSoft.MvvmLight;
using XamarinTemplate.Core.ViewModels.Base.Args;

namespace XamarinTemplate.Core.ViewModels.Base
{
    public abstract class EventBaseViewModel : ViewModelBase
    {
        #region Delegates

        public delegate void ParametersSetEventHandler(object source, ParametersSetEventArgs e);

        #endregion

        #region Events

        public event ParametersSetEventHandler OnParamtersSetEvent;

        #endregion

        protected EventBaseViewModel()
        {
            OnParamtersSetEvent += OnParamtersSetHandler;
        }

        #region Public activation methods

        public void SetParameters(IDictionary<string, string> parameters)
        {
            OnParamtersSetEvent?.Invoke(this, new ParametersSetEventArgs(parameters));
        }

        #endregion

        #region Event handlers

        private void OnParamtersSetHandler(object source, ParametersSetEventArgs e)
        {
            OnParametersSet(e.Parameters);
        }

        #endregion

        #region Virtual action methods

        protected virtual void OnParametersSet(IDictionary<string, string> parameters)
        {
        }

        #endregion
    }
}
