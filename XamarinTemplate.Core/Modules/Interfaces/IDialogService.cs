namespace XamarinTemplate.Core.Modules.Interfaces
{
    public interface IDialogService : GalaSoft.MvvmLight.Views.IDialogService
    {
        void ShowBusyDialog(string text = "");

        void CloseBusyDialog();
    }
}
