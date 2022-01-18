
/******************************************************************************************************************************
 FILENAME:                 QueryStringModule.cs
 VERSION:                  1.0
 Created Date              21-Oct-14
 DESCRIPTION:              This class will be used as a HTTP Module for the application.
 AUTHOR:                   Anubhav Chaudhary
 REVISION HISTORY
 -------------------------------------------------------------------------------------------------------------------------------
 Change Ref    Date  		        Revised By         Bug ID#	    Change Description
 -------------------------------------------------------------------------------------------------------------------------------
 
*******************************************************************************************************************************/

using System;
using System.Text;
using System.Web;

public class QueryStringModule : IHttpModule
{
    static ASCIIEncoding encoding;

    static QueryStringModule()
    {
        encoding = new ASCIIEncoding();
    }

    /// <summary>
    /// Function is called when any request is initiated
    /// </summary>
    /// <param name="context"></param>
    /// <author>Anubhav Chaudhary</author>
    public void Init(HttpApplication context)
    {
        context.BeginRequest += context_BeginRequest;
    }


    /// <summary>
    /// Function is called when the request for a page is started
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <author>Anubhav Chaudhary</author>

    private const string PARAMETER_NAME = "encrypt=1&";
    private const string ENCRYPTION_KEY = "key";
    void context_BeginRequest(object sender, EventArgs e)
    {

        HttpContext context = HttpContext.Current;
        if (context.Request.Url.OriginalString.Contains("aspx") &&
                   context.Request.RawUrl.Contains("?"))
        {
            string query = context.Request.RawUrl;
            string path = GetVirtualPath();

            if (query.Contains(PARAMETER_NAME))
            {
                // Decrypts the query string and rewrites the path.
                //string rawQuery = query.Replace(PARAMETER_NAME, string.Empty);
                string decryptedQuery = Decrypt(query);
                context.RewritePath(path, string.Empty, decryptedQuery);
            }
            else if (context.Request.HttpMethod == "GET")
            {
                // Encrypt the query string and redirects to the encrypted URL.
                // Remove if you don't want all query strings to be encrypted automatically.
                if (query != "")
                {
                    string encryptedQuery = Encrypt(query);
                    context.Response.Redirect(encryptedQuery);
                }
            }
        }
    }

    private static string GetVirtualPath()
    {
        string path = HttpContext.Current.Request.RawUrl;
        path = path.Substring(0, path.IndexOf("?"));
        path = path.Substring(path.LastIndexOf("/") + 1);
        return path;
    }

    /// <summary>
    /// Function encrypts the url
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <author>Anubhav Chaudhary</author>
    public static string Encrypt(string url)
    {
        string cookedUrl = url;

        if (url != null && url.Contains(".aspx?"))
        {
            cookedUrl = url.Substring(0, url.IndexOf('?') + 1);

            var queryStrings = url.Substring(url.IndexOf('?') + 1).Split('&');

            foreach (var queryString in queryStrings)
            {
                if (!string.IsNullOrEmpty(queryString)) 
                    cookedUrl += queryString.Split('=')[0] + "=" + Encrypting(queryString.Split('=')[1]) + "&";
            }
            cookedUrl = cookedUrl.Substring(0, cookedUrl.Length - 1);
            cookedUrl = cookedUrl.Replace("?", "?" + PARAMETER_NAME);
        }
        return cookedUrl;

    }

    /// <summary>
    /// Functin decrypts the url
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    /// <author>Anubhav Chaudhary</author>
    public static string Decrypt(string url)
    {
        if (url.Contains(".aspx?"))
        {
            var path = HttpContext.Current.Request.RawUrl;
            path = path.Substring(0, path.IndexOf("?", StringComparison.Ordinal) + 1);
            path = path.Substring(path.LastIndexOf("/", StringComparison.Ordinal) + 1);

            var queryStrings = url.Substring(url.IndexOf('?') + 1).Split('&');

            foreach (var queryString in queryStrings)
            {
                path += queryString.Split('=')[0] + "=" + Decrypting(queryString.Substring(queryString.IndexOf('=') + 1)) + "&";
            }
            path = path.Substring(0, path.Length - 1);
            url = path;
        }
        return url;
    }
    /// <summary>
    /// Function encodes the input parameter
    /// </summary>
    /// <param name="target">the target which is to be encoded</param>
    /// <returns>encoded string</returns>
    /// <author>Anubhav Chaudhary</author>
    static string Encrypting(string target)
    {
        try
        {
            var bytes = encoding.GetBytes(target ?? string.Empty);
            var encodedString = Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
            return encodedString;
        }
        catch { }
        return null;
    }
    /// <summary>
    /// Function decodes the input parameter
    /// </summary>
    /// <param name="target">the target which is to be decoded</param>
    /// <returns>decode string</returns>
    /// <author>Anubhav Chaudhary</author>
    static string Decrypting(string target)
    {
        try
        {
            var bytes = Convert.FromBase64String(target ?? string.Empty);
            var decodedString = encoding.GetString(bytes);
            return decodedString;
        }
        catch { }
        return null;
    }

    /// <summary>
    /// Function Disposes the unused objects
    /// </summary>
    /// <author>Anubhav Chaudhary</author>
    public void Dispose()
    {
        // Do nothing
    }
}