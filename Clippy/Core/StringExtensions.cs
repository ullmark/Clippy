using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Clippy
{
    /// <summary>
    /// Extension methods for the string data type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method for html decoding a string
        /// </summary>
        /// <param name="s">The string to html decode</param>
        /// <returns>A html decoded string</returns>
        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }

        /// <summary>
        /// Extension method for stripping all html from a string
        /// </summary>
        /// <param name="s">The string to remove html from</param>
        /// <returns>A string without html tags</returns>
        public static string StripHtml(this string s)
        {
            return Regex.Replace(s, @"(\<[^\>]+\>)", string.Empty);
        }

        /// <summary>
        /// Extension method for adding a parameter to a query string
        /// </summary>
        /// <param name="s">The string to add parameter to</param>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter</param>
        /// <returns>A string with the added parameter</returns>
        public static string AddQueryStringParameter(this string s, string name, string value)
        {
            var splitOnQuestionMark = s.Split(new[] { '?' });
            var leftPart = splitOnQuestionMark[0];
            var queryString = splitOnQuestionMark.Length > 1 ? splitOnQuestionMark[1] : string.Empty;
            var q = HttpUtility.ParseQueryString(queryString);
            q[name] = HttpUtility.UrlEncode(value);
            return string.Format("{0}?{1}",
                leftPart,
                string.Join("&", q.AllKeys.Select(k => string.Format("{0}={1}", k, q.Get(k)))));
        }

        /// <summary>
        /// Extension method for converting the first character in a string to upper case
        /// </summary>
        /// <param name="s">The string to convert first character to upper case in</param>
        /// <returns>A string with the first character converted to upper case</returns>
        public static string ToFirstUpper(this string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
                return char.ToUpper(s[0]) + s.Substring(1);
            return s;
        }

        /// <summary>
        /// Extension method for checking whether a string is null or contains whitespaces only
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>
        /// <c>true</c> if the string is null or contains whitespace(s) only; otherwise <c>false</c>
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return System.String.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Extension method to reverse a string
        /// </summary>
        /// <param name="s">The string to be reversed</param>
        /// <returns>The reversed string</returns>
        public static string Reverse(this string s)
        {
            if (s.IsNullOrWhiteSpace() || (s.Length == 1))
                return s;

            var chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// Extension method for checking if a string is a valid url
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>
        /// True if the string is a valid url; otherwise false
        /// </returns>
        public static bool IsValidUrl(this string s)
        {
            Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(s);
        }
    }
}
