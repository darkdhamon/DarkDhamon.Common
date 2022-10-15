namespace DarkDhamon.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Shortcut for string.IsNullOrEmpty(string value)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Shortcut for string.IsNullOrWhiteSpace(string value)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhitespace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Replace Null Or Whitespace value with Alternate Value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="alternateValue"></param>
        /// <returns></returns>
        public static string IfNullOrWhitespace(this string value, string alternateValue)
        {
            return !string.IsNullOrWhiteSpace(value)
                ?value
                :alternateValue;
        }

        /// <summary>
        /// if value is not null, or whitespace adds space after, other return empty.
        ///
        /// Shortcut for for string interpolation or formatting with empty strings
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string AddSpaceAfter(this string value)
        {
            return value.IsNullOrWhitespace() ? string.Empty : $"{value} ";
        }

        /// <summary>
        /// Combine the string values of a list into a comma separated string, alias of Join&lt;T&gt;(this IEnumerable&lt;T&gt; valueList, string separator = ", ")
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueList"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> valueList, string separator = ", ")
        {
            return valueList.Join(separator);
        }

        /// <summary>
        /// Combine the string values of a list into a comma separated string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueList"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> valueList, string separator = ", ")
        {
            return string.Join(separator, valueList);
        }
    }
}
