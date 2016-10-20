using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;
using XamarinTemplate.Core.Base.ViewModels.Base;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.Adapters
{
    public abstract class BaseSelectableListViewAdapter<TUiItem, TViewHolder> : BaseListViewAdapter<TUiItem, TViewHolder>
        where TUiItem : BaseListItemViewModel
        where TViewHolder : INameTextViewItemViewHolder, new()
    {
        private readonly Action<TUiItem> mItemSelectedCallbackAction;

        protected BaseSelectableListViewAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        protected BaseSelectableListViewAdapter(Context context, int rowViewResourceId, int nameTvId, TUiItem[] objects)
            : base(context, rowViewResourceId, nameTvId, objects)
        {
        }

        protected BaseSelectableListViewAdapter(Context context, int rowViewResourceId, int nameTvId)
            : base(context, rowViewResourceId, nameTvId)
        {
        }

        protected BaseSelectableListViewAdapter(Context context, int resource, int textViewResourceId, int nameTvId)
            : base(context, resource, textViewResourceId, nameTvId)
        {
        }

        protected BaseSelectableListViewAdapter(Context context, int rowViewResourceId, int nameTvId, IList<TUiItem> dataSource,
            Action<TUiItem> itemTappedCallbackAction, Action<TUiItem> itemSelectedCallbackAction) 
            : base(context, rowViewResourceId, nameTvId, dataSource, itemTappedCallbackAction)
        {
            mItemSelectedCallbackAction = itemSelectedCallbackAction;
        }

        #region Protected methods

        protected void OnItemSelected(object sender, bool isChecked)
        {
            var tagObject = ExtractTagObject(sender);

            var javaObjectWrapper = tagObject?.JavaObjectWrapper;
            if (javaObjectWrapper == null)
            {
                return;
            }

            if (javaObjectWrapper.Data.Selected != isChecked)
            {
                mItemSelectedCallbackAction?.Invoke(javaObjectWrapper.Data);
            }
        }

        #endregion
    }
}