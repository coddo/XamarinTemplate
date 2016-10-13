namespace XamarinTemplate.Core.Services.Interfaces
{
    public interface IDialogService : GalaSoft.MvvmLight.Views.IDialogService
    {
        void ShowBusyDialog(string text = "");

        void CloseBusyDialog();
    }
}
