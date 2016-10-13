using System;
using Android.App;
using Android.Runtime;
using XamarinTemplate.Android.Base.Util;

namespace XamarinTemplate.Android.Base
{
    public abstract class BaseApp : Application
    {
        protected BaseApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public static Application Current { get; set; }

        public override void OnCreate()
        {
            base.OnCreate();

            Current = this;
            RegisterActivityLifecycleCallbacks(new LifeCycleManager());
        }

        public override void OnTerminate()
        {
            base.OnTerminate();

            if (App.IsAppInitialized)
            {
                App.Instance.CleanupInstance();
            }
        }
    }
}