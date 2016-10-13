using XamarinTemplate.Android.Base.IOC;
using XamarinTemplate.Android.Base.Util;
using XamarinTemplate.Core.Services.Interfaces;

namespace XamarinTemplate.Android.Base.Services
{
    public class NetworkService : INetworkService
    {
        public void SignalNoInternetConnection()
        {
            Modules.NotificationMessageService.ShowError("Please check your internet connection");
        }

        public bool DeviceHasInternetConnectivity()
        {
            return NetworkUtilities.HasNetworkConnection();
        }

        public void SignalServerConnectionDown()
        {
            Modules.NotificationMessageService.ShowError("It seems that the server is down");
        }
    }
}