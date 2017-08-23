namespace Sample.Extensions
{
    public static class LuongExt
    {
        public static string Hello(this string source)
        {
            return $"Hello {source}";
        }
        public static string Hello(this string source, string wish)
        {
            return $"Hello {source}. {wish}!";
        }

        public static int MultiplyBy(this int value, int mulitiplier)
        {
            // Uses a second parameter after the instance parameter.
            return value * mulitiplier;
        }
    }
}
