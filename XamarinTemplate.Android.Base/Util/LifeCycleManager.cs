using Android.App;
using Android.OS;
using Java.Lang;

namespace XamarinTemplate.Android.Base.Util
{
    public class LifeCycleManager : Object, global::Android.App.Application.IActivityLifecycleCallbacks
    {
        private int mStartedActivities;
        private int mStoppedActivities;

        #region IActivityLifecycleCallbacks implementation

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            ++mStartedActivities;

            if (App.Instance.IsAppInForeground == false)
            {
                App.Instance.IsAppInForeground = true;
            }
        }

        public void OnActivityStopped(Activity activity)
        {
            ++mStoppedActivities;

            if (mStartedActivities == mStoppedActivities)
            {
                App.Instance.IsAppInForeground = false;
            }
        }

        #endregion
    }
}