using Android.App;
using Android.OS;
using XamarinTemplate.Android.Base.UI.Activities.Base;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Android.UI.Activities
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/app_icon", MainLauncher = true, Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class SplashScreenActivity : BaseActivity<SplashScreenViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash_screen);

            ViewModel.NavigateToMainPageDelayed(0);
        }
    }
}