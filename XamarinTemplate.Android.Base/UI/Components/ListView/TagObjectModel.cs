using Java.Lang;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;
using XamarinTemplate.Android.Base.Util.Models;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Android.Base.UI.Components.ListView
{
    public class TagObjectModel<TUiItem, TViewHolder> : Object
        where TUiItem : BaseListItemViewModel
        where TViewHolder : INameTextViewItemViewHolder
    {
        public TagObjectModel(TViewHolder viewHolder)
        {
            ViewHolder = viewHolder;
        }

        public TViewHolder ViewHolder { get; set; }

        public JavaObjectWrapper<TUiItem> JavaObjectWrapper { get; set; }
    }
}