using Java.Lang;

namespace XamarinTemplate.Android.Base.Util.Extensions
{
    public static class TextExtensions
    {
        public static string Stringify(this ICharSequence charSequence)
        {
            return charSequence.ToString();
        }

        public static ICharSequence ToCharSequence(this string value)
        {
            return new String(value);
        }
    }
}