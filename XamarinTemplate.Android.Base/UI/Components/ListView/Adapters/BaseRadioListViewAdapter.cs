using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.Adapters
{
    public abstract class BaseRadioListViewAdapter<TUiItem, TViewHolder> : BaseSelectableListViewAdapter<TUiItem, TViewHolder>
        where TUiItem : BaseListItemViewModel
        where TViewHolder : IRadioListViewItemViewHolder, new()
    {
        #region Constructors

        protected BaseRadioListViewAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        protected BaseRadioListViewAdapter(Context context, int rowViewResourceId, int rbCheckedId, int nameTvId, TUiItem[] objects)
            : base(context, rowViewResourceId, nameTvId, objects)
        {
            RbCheckedId = rbCheckedId;
        }

        protected BaseRadioListViewAdapter(Context context, int rowViewResourceId, int rbCheckedId, int nameTvId)
            : base(context, rowViewResourceId, nameTvId)
        {
            RbCheckedId = rbCheckedId;
        }

        protected BaseRadioListViewAdapter(Context context, int resource, int textViewResourceId, int rbCheckedId, int nameTvId)
            : base(context, resource, textViewResourceId, nameTvId)
        {
            RbCheckedId = rbCheckedId;
        }

        protected BaseRadioListViewAdapter(Context context, int rowViewResourceId, int rbCheckedId, int nameTvId, IList<TUiItem> dataSource,
            Action<TUiItem> itemTappedCallbackAction, Action<TUiItem> itemSelectedCallbackAction) 
            : base(context, rowViewResourceId, nameTvId, dataSource, itemTappedCallbackAction, itemSelectedCallbackAction)
        {
            RbCheckedId = rbCheckedId;
        }

        #endregion

        #region Properties

        protected int RbCheckedId { get; }

        #endregion

        #region Overrides

        protected sealed override View HandleSelectorItem(TViewHolder viewHolder, View view, TagObjectModel<TUiItem, TViewHolder> tagObject)
        {
            var currentItem = tagObject.JavaObjectWrapper.Data;
            viewHolder.RbChecked = view.FindViewById<RadioButton>(RbCheckedId);

            if (currentItem == null || viewHolder.RbChecked == null)
            {
                return view;
            }

            if (!StyleItemDisplay(view, viewHolder, currentItem))
            {
                return view;
            }

            viewHolder.RbChecked.Tag = tagObject;
            viewHolder.RbChecked.CheckedChange -= RadioButton_CheckedChanged;
            viewHolder.RbChecked.CheckedChange += RadioButton_CheckedChanged;

            viewHolder.RbChecked.Checked = currentItem.Selected;

            return view;
        }

        #endregion

        #region Events

        private void RadioButton_CheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            OnItemSelected(sender, e.IsChecked);
        }

        #endregion
    }
}