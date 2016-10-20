namespace XamarinTemplate.Core.Base.Modules.Interfaces
{
    public interface INetworkService
    {
        void SignalNoInternetConnection();

        bool DeviceHasInternetConnectivity();

        void SignalServerConnectionDown();
    }
}
