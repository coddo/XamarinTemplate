using System;
using Android.App;
using Android.Runtime;
using XamarinTemplate.Android.Base;

namespace XamarinTemplate.Android
{
    [Application]
    public class MainApp : BaseApp
    {
        protected MainApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            if (!App.IsAppInitialized)
            {
                App.Initialize();
            }
        }
    }
}