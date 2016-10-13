using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using XamarinTemplate.Android.Base.UI.Activities.Base;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Android.UI.Activities
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/app_icon", Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class SecondActivity : BaseActivity<SecondViewModel>
    {
        private Button mNavigateButton;
        private Button mNotificationButton;
        private Button mLoadingDialogButton;

        private Button NavigateButton => mNavigateButton ?? (mNavigateButton = FindViewById<Button>(Resource.Id.second_btn_navigate_main));

        private Button NotificationButton => mNotificationButton 
            ?? (mNotificationButton = FindViewById<Button>(Resource.Id.second_btn_notification_main));

        private Button LoadingDialogButton => mLoadingDialogButton 
            ?? (mLoadingDialogButton = FindViewById<Button>(Resource.Id.second_btn_show_loading_dialog));

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second);

            NavigateButton.SetCommand("Click", ViewModel.NavigateCommand);
            NotificationButton.SetCommand("Click", ViewModel.NotificationCommand);
            LoadingDialogButton.SetCommand("Click", ViewModel.LoadingDialogCommand);
        }
    }
}