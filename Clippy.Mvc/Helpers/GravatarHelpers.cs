using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Security.Cryptography;

public static class GravatarHelpers
{
    private const string gravatar = "http://www.gravatar.com/avatar/";

    public static MvcHtmlString Gravatar(this HtmlHelper helper, string email, string fallback = null, int? size = null, string defaultIconKeyWord = null)
    {
        var img = new TagBuilder("img");
        img.Attributes["alt"] = string.Empty;

        var myGravatar = gravatar;

        var url = string.Concat(gravatar, ConstructGravatarUrl(email));

        if (!string.IsNullOrEmpty(defaultIconKeyWord))
            url = url.AddQueryStringParameter("d", defaultIconKeyWord);

        if (size.HasValue)
        {
            if (size.Value < 1 || size.Value > 512)
                throw new ArgumentOutOfRangeException("size", "allowed values are 1 - 512");

            url = url.AddQueryStringParameter("s", size.Value.ToString());
        }

        img.Attributes["src"] = url;
        return MvcHtmlString.Create(img.ToString(TagRenderMode.SelfClosing));
    }

    private static string ConstructGravatarUrl(string email)
    {
        var md5Hasher = MD5.Create();
        var utf8 = new UTF8Encoding();

        var emailHash = md5Hasher.ComputeHash(utf8.GetBytes(email));
        var s = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < emailHash.Length; i++)
            s.Append(emailHash[i].ToString("x2"));

        return s.ToString();
    }
}