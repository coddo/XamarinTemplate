using XamarinTemplate.Models.Extensions;

namespace XamarinTemplate.Models.Response
{
    public enum ResponseCode
    {
        // Default
        NotSet = -1,

        // Success code constants
        Success,
        SuccessNoData,
        SuccessSignUp,
        SuccessSignIn,
        SuccessSignOut,

        // Error code constants
        ErrorAnErrorOccurred,
        ErrorNoInternet,
        ErrorEmailAlreadyUsed,
        ErrorSignInFail,
        ErrorInvalidUsernameOrPassword,
        ErrorInvalidInput,
    }

    public static class CodeConstantsExtensions
    {
        public static bool IsEqualToResponseCode(this int value, ResponseCode target)
        {
            return target.IsEqualToInt(value);
        }

        #region private methods

        private static bool IsEqualToInt(this ResponseCode value, int target)
        {
            return value.ToInt() == target;
        }

        #endregion
    }
}