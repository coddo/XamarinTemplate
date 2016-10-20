using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using XamarinTemplate.Core.Modules.Interfaces;

namespace XamarinTemplate.Android.Base.Modules
{
    public class DialogService : GalaSoft.MvvmLight.Views.DialogService, IDialogService
    {
        #region Private fields

        #endregion

        #region Private properties

        private AlertDialog BusyDialog { get; set; }

        #endregion

        #region Display methods

        public void ShowBusyDialog(string text = "")
        {
            // Close any existing dialogs
            CloseBusyDialog();

            // Create a new dialog and retain it's inflated view
            CreateBusyDialog(text);

            BusyDialog.Show();
        }

        #endregion

        #region Hide methods

        public void CloseBusyDialog()
        {
            if (!IsDialogAvailable(BusyDialog))
            {
                return;
            }

            BusyDialog.Dismiss();
            BusyDialog = null;
        }

        #endregion

        #region Dialog validation methods

        private static bool IsDialogAvailable(Dialog dialog) => dialog != null && (App.Instance.IsAppInForeground && dialog.IsShowing);

        #endregion

        #region Dialog creation methods

        private void CreateBusyDialog(string text = "")
        {
            BusyDialog = new AlertDialog.Builder(App.Instance.CurrentActivity)
                .SetCancelable(false)
                .Create();

            var dialogContentView = BusyDialog.LayoutInflater.Inflate(Resource.Layout.loading_dialog, null);
            var dialogTextView = dialogContentView.FindViewById<TextView>(Resource.Id.tv_loading_dialog_action_title);
            dialogTextView.Text = text;

            BusyDialog.SetView(dialogContentView);
            BusyDialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
        }

        #endregion
    }
}