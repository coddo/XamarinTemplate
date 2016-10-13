using Android.Widget;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders
{
    public class RadioItemViewHolder : IRadioListViewItemViewHolder
    {
        public RadioButton RbChecked { get; set; }

        public TextView TvName { get; set; }
    }
}