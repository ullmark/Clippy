using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Security.Cryptography;

public static class GravatarHelpers
{
	private const string gravatar = "http://www.gravatar.com/avatar/";
	
	public static MvcHtmlString Gravatar(this HtmlHelper helper, string email, string fallback = null)
	{
		var img = new TagBuilder("img");
		img.Attributes["alt"] = string.Empty;
		img.Attributes["src"] = string.Concat(gravatar, ConstructGravatarUrl(email));
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