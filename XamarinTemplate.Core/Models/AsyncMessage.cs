using System.Collections.Generic;
using XamarinTemplate.Core.Enum;

namespace XamarinTemplate.Core.Models
{
    public class AsyncMessage
    {
        private IDictionary<string, string> mParameters;

        public AsyncMessage()
        {
        }

        public string Title { get; set; }

        public string TargetViewModel { get; set; }

        public MessageAction Action { get; set; }

        public NotificationIcon Icon { get; set; }

        public IDictionary<string, string> Parameters
        {
            get { return mParameters ?? (mParameters = new Dictionary<string, string>()); }
            set { mParameters = value; }
        }

        public string SerializedObject { get; set; }
    }
}
