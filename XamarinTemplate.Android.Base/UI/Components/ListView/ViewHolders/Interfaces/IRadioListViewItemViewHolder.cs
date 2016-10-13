using Android.Widget;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces
{
    public interface IRadioListViewItemViewHolder : INameTextViewItemViewHolder
    {
        RadioButton RbChecked { get; set; }
    }
}