using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinTemplate.Android.Base.UI.Components.ListView.ViewHolders.Interfaces;
using XamarinTemplate.Android.Base.Util.Models;
using XamarinTemplate.Core.ViewModels.Base;

namespace XamarinTemplate.Android.Base.UI.Components.ListView.Adapters
{
    public abstract class BaseListViewAdapter<TUiItem, TViewHolder> : ArrayAdapter<TUiItem>
        where TUiItem : BaseListItemViewModel
        where TViewHolder : INameTextViewItemViewHolder, new()
    {
        #region Private fields

        private readonly int mRow;
        private readonly LayoutInflater mInflater;

        private List<TUiItem> mDataSource;
        private readonly Action<TUiItem> mItemTappedCallbackAction;

        #endregion

        #region Constructors

        protected BaseListViewAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        protected BaseListViewAdapter(Context context, int rowViewResourceId, int nameTvId, TUiItem[] objects)
            : base(context, rowViewResourceId, objects)
        {
            mInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

            TvNameId = nameTvId;
        }

        protected BaseListViewAdapter(Context context, int rowViewResourceId, int nameTvId)
            : base(context, rowViewResourceId)
        {
            mInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

            TvNameId = nameTvId;
        }

        protected BaseListViewAdapter(Context context, int resource, int textViewResourceId, int nameTvId)
            : base(context, resource, textViewResourceId)
        {
            mInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

            TvNameId = nameTvId;
        }

        protected BaseListViewAdapter(Context context, int rowViewResourceId, int nameTvId, IList<TUiItem> dataSource,
            Action<TUiItem> itemTappedCallbackAction) : base(context, rowViewResourceId, dataSource)
        {
            mDataSource = dataSource?.ToList() ?? new List<TUiItem>();

            mRow = rowViewResourceId;
            mInflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

            TvNameId = nameTvId;

            mItemTappedCallbackAction = itemTappedCallbackAction;
        }

        #endregion

        #region Properties

        public List<TUiItem> DataSource
        {
            get { return mDataSource; }
            set
            {
                mDataSource = value;

                App.Instance.CurrentActivity?.RunOnUiThread(NotifyDataSetChanged);
            }
        }

        public override int Count => mDataSource?.Count ?? 0;

        protected int TvNameId { get; }

        #endregion

        #region Public methods

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            TViewHolder viewHolder;
            TagObjectModel<TUiItem, TViewHolder> tagObject;

            var view = convertView;
            if (view == null)
            {
                view = mInflater.Inflate(mRow, null);

                viewHolder = new TViewHolder();
                tagObject = new TagObjectModel<TUiItem, TViewHolder>(viewHolder);

                view.Tag = tagObject;
            }
            else
            {
                tagObject = (TagObjectModel<TUiItem, TViewHolder>)view.Tag;
                viewHolder = tagObject.ViewHolder;
            }

            try
            {
                if (position > (mDataSource.Count - 1))
                {
                    return view;
                }

                tagObject.JavaObjectWrapper = new JavaObjectWrapper<TUiItem> { Data = mDataSource[position] };

                view.Click -= Item_Click;
                view.Click += Item_Click;

                return HandleSelectorItem(viewHolder, view, tagObject);
            }
            catch (Exception ex)
            {
                Core.Containers.CoreServices.LoggingService.LogException<BaseListViewAdapter<TUiItem, TViewHolder>>(ex);
                return view;
            }
        }

        #endregion

        #region Abstract methods

        protected abstract View HandleSelectorItem(TViewHolder viewHolder, View view, TagObjectModel<TUiItem, TViewHolder> tagObject);

        #endregion

        #region Virtual methods

        protected virtual bool StyleItemDisplay(View view, TViewHolder viewHolder, TUiItem currentItem)
        {
            viewHolder.TvName = view.FindViewById<TextView>(TvNameId);
            if (viewHolder.TvName == null)
            {
                return false;
            }

            viewHolder.TvName.Text = currentItem.Name;
            viewHolder.TvName.SetTextColor(currentItem.Selected ? Color.Black : Color.Gray);

            return true;
        }

        #endregion

        #region Protected methods

        protected TagObjectModel<TUiItem, TViewHolder> ExtractTagObject(object sender)
        {
            var intermediaryView = (View)sender;

            return intermediaryView?.Tag as TagObjectModel<TUiItem, TViewHolder>;
        }

        #endregion

        #region Events

        private void Item_Click(object sender, EventArgs e)
        {
            if (mItemTappedCallbackAction == null)
            {
                return;
            }

            var tagObject = ExtractTagObject(sender);
            if (tagObject == null)
            {
                return;
            }

            mItemTappedCallbackAction.Invoke(tagObject.JavaObjectWrapper.Data);
        }

        #endregion
    }
}