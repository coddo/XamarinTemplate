using System;
using System.Collections.Generic;

namespace XamarinTemplate.Core.Base.ViewModels.Base.Args
{
    public class ParametersSetEventArgs : EventArgs
    {
        public ParametersSetEventArgs(IDictionary<string, string> parameters)
        {
            Parameters = parameters;
        }

        public IDictionary<string, string> Parameters { get; private set; }
    }
}
