namespace XamarinTemplate.Core.Modules.Interfaces
{
    public interface INetworkService
    {
        void SignalNoInternetConnection();

        bool DeviceHasInternetConnectivity();

        void SignalServerConnectionDown();
    }
}
