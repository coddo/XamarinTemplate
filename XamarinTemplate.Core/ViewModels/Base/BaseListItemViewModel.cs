namespace XamarinTemplate.Core.ViewModels.Base
{
    public class BaseListItemViewModel : BaseViewModel
    {
        private string mName;
        private bool mSelected;

        public string Name
        {
            get { return mName; }
            set
            {
                mName = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public bool Selected
        {
            get { return mSelected; }
            set
            {
                mSelected = value;
                RaisePropertyChanged(() => Selected);
            }
        }
    }
}
