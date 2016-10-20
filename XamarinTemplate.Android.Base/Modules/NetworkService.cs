using XamarinTemplate.Android.Base.Containers;
using XamarinTemplate.Android.Base.Util;
using XamarinTemplate.Core.Base.Modules.Interfaces;

namespace XamarinTemplate.Android.Base.Modules
{
    public class NetworkService : INetworkService
    {
        public void SignalNoInternetConnection()
        {
            CoreServices.NotificationMessageService.ShowError("Please check your internet connection");
        }

        public bool DeviceHasInternetConnectivity()
        {
            return NetworkUtilities.HasNetworkConnection();
        }

        public void SignalServerConnectionDown()
        {
            CoreServices.NotificationMessageService.ShowError("It seems that the server is down");
        }
    }
}