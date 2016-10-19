using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using XamarinTemplate.Android.Base.UI.Activities.Base;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Android.UI.Activities
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/app_icon", Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        private Button mNavigateButton;
        private Button mInfoButton;
        private Button mInfoWithActionButton;
        private Button mErrorButton;
        private Button mErrorWithActionButton;
        private Button mSettingsTestButton;
        private Button mDatabaseTestButton;

        private Button NavigateButton => mNavigateButton 
            ?? (mNavigateButton = FindViewById<Button>(Resource.Id.main_btn_navigate_second));

        private Button InfoButton => mInfoButton 
            ?? (mInfoButton = FindViewById<Button>(Resource.Id.main_btn_info));
        private Button InfoWithActionButton => mInfoWithActionButton 
            ?? (mInfoWithActionButton = FindViewById<Button>(Resource.Id.main_btn_info_action));

        private Button ErrorButton => mErrorButton 
            ?? (mErrorButton = FindViewById<Button>(Resource.Id.main_btn_error));

        private Button ErrorWithActionButton => mErrorWithActionButton 
            ?? (mErrorWithActionButton = FindViewById<Button>(Resource.Id.main_btn_error_action));

        private Button SettingsTestButton => mSettingsTestButton
            ?? (mSettingsTestButton = FindViewById<Button>(Resource.Id.main_btn_error_action));

        private Button DatabaseTestButton => mDatabaseTestButton
            ?? (mDatabaseTestButton = FindViewById<Button>(Resource.Id.main_btn_error_action));

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            NavigateButton.SetCommand("Click", ViewModel.NavigateCommand);
            InfoButton.SetCommand("Click", ViewModel.ShowInfoMessageCommand);
            InfoWithActionButton.SetCommand("Click", ViewModel.ShowInfoMessageWithActionCommand);
            ErrorButton.SetCommand("Click", ViewModel.ShowErrorMessageCommand);
            ErrorWithActionButton.SetCommand("Click", ViewModel.ShowErrorMessageWithActionCommand);
            SettingsTestButton.SetCommand("Click", ViewModel.GetStoreClearSettings);
            DatabaseTestButton.SetCommand("Click", ViewModel.GetStoreClearDatabase);
        }
    }
}

