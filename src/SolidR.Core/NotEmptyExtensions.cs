namespace SolidR.Core
{
    public static class NotEmptyExtensions
    {
        public static bool NotEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) == false;
        }

        public static bool NotEmpty(this string[] value)
        {
            return value != null && value.Length > 0;
        }
    }
}
