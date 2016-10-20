using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;
using XamarinTemplate.Core.Base.ViewModels.Base;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.Adapters
{
    public abstract class BaseCheckedListViewAdapter<TUiItem, TViewHolder> : BaseSelectableListViewAdapter<TUiItem, TViewHolder>
        where TUiItem : BaseListItemViewModel
        where TViewHolder : ICheckedListViewItemViewHolder, new()
    {
        #region Constructors

        protected BaseCheckedListViewAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        protected BaseCheckedListViewAdapter(Context context, int rowViewResourceId, int cbSelectedId, int nameTvId, TUiItem[] objects) 
            : base(context, rowViewResourceId, nameTvId, objects)
        {
            CbSelectedId = cbSelectedId;
        }

        protected BaseCheckedListViewAdapter(Context context, int rowViewResourceId, int cbSelectedId, int nameTvId) : base(context, rowViewResourceId, nameTvId)
        {
            CbSelectedId = cbSelectedId;
        }

        protected BaseCheckedListViewAdapter(Context context, int resource, int textViewResourceId, int cbSelectedId, int nameTvId) 
            : base(context, resource, textViewResourceId, nameTvId)
        {
            CbSelectedId = cbSelectedId;
        }

        protected BaseCheckedListViewAdapter(Context context, int rowViewResourceId, int cbSelectedId, int nameTvId, IList<TUiItem> dataSource,
            Action<TUiItem> itemTappedCallbackAction, Action<TUiItem> itemSelectedCallbackAction) 
            : base(context, rowViewResourceId, nameTvId, dataSource, itemTappedCallbackAction, itemSelectedCallbackAction)
        {
            CbSelectedId = cbSelectedId;
        }

        #endregion

        #region Properties

        protected int CbSelectedId { get; }

        #endregion

        #region Overrides

        protected override View HandleSelectorItem(TViewHolder viewHolder, View view, TagObjectModel<TUiItem, TViewHolder> tagObject)
        {
            var currentItem = tagObject.JavaObjectWrapper.Data;
            viewHolder.CbSelected = view.FindViewById<CheckBox>(CbSelectedId);

            if (currentItem == null || viewHolder.CbSelected == null)
            {
                return view;
            }

            if (!StyleItemDisplay(view, viewHolder, currentItem))
            {
                return view;
            }

            viewHolder.CbSelected.Tag = tagObject;
            viewHolder.CbSelected.CheckedChange -= CheckBox_CheckedChanged;
            viewHolder.CbSelected.CheckedChange += CheckBox_CheckedChanged;

            viewHolder.CbSelected.Checked = currentItem.Selected;

            return view;
        }

        #endregion

        #region Events

        private void CheckBox_CheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            OnItemSelected(sender, e.IsChecked);
        }

        #endregion
    }
}