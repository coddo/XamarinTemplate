using Android.Widget;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders
{
    public class CheckedItemViewHolder : ICheckedListViewItemViewHolder
    {
        public TextView TvName { get; set; }

        public CheckBox CbSelected { get; set; }
    }
}