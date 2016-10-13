using Android.Views;
using GalaSoft.MvvmLight.Views;

namespace XamarinTemplate.Android.Base.UI.Activities.Base
{
    public class RootViewBaseActivity : ActivityBase
    {
        private View mRootView;

        public View RootView => mRootView
            ?? (mRootView = FindViewById(global::Android.Resource.Id.Content))
            ?? (mRootView = Window?.DecorView?.RootView);

        protected override void OnResume()
        {
            base.OnResume();

            App.Instance.CurrentActivity = this;
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (App.Instance.CurrentActivity != null && App.Instance.CurrentActivity.GetType() == GetType())
            {
                App.Instance.CurrentActivity = null;
            }
        }
    }
}