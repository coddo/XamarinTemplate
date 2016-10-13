using Android.App;
using Android.Content;
using Android.Net;

namespace XamarinTemplate.Android.Base.Util
{
    public static class NetworkUtilities
    {
        public static bool HasNetworkConnection()
        {
            var context = Application.Context;
            var connectivityManager = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            var netInfo = connectivityManager.ActiveNetworkInfo;

            return netInfo != null && netInfo.IsConnectedOrConnecting;
        }
    }
}