namespace XamarinTemplate.Core.Services.Interfaces
{
    public interface INetworkService
    {
        void SignalNoInternetConnection();

        bool DeviceHasInternetConnectivity();

        void SignalServerConnectionDown();
    }
}
