using Android.Widget;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces
{
    public interface ICheckedListViewItemViewHolder : INameTextViewItemViewHolder
    {
        CheckBox CbSelected { get; set; }
    }
}