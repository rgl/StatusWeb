using System.Text;
using System.Web;

namespace StatusWeb
{
    public class RequestDumper
    {
        internal static void AppendHtml(StringBuilder body, HttpContext context)
        {
            body.Append("<table>");
            body.Append("<caption>Request Properties</caption>");
            body.AppendFormat("<tr><th>Url</th><td>{0}</td></tr>", HttpUtility.HtmlEncode(context.Request.Url.AbsoluteUri));
            body.AppendFormat("<tr><th>HttpMethod</th><td>{0}</td></tr>", HttpUtility.HtmlEncode(context.Request.HttpMethod));
            body.AppendFormat("<tr><th>IsSecureConnection</th><td>{0}</td></tr>", context.Request.IsSecureConnection);
            body.AppendFormat("<tr><th>IsLocal</th><td>{0}</td></tr>", context.Request.IsLocal);
            body.AppendFormat("<tr><th>UserAgent</th><td>{0}</td></tr>", HttpUtility.HtmlEncode(context.Request.UserAgent));
            body.AppendFormat("<tr><th>UserHostAddress</th><td>{0}</td></tr>", HttpUtility.HtmlEncode(context.Request.UserHostAddress));
            body.Append("</table>");

            body.Append("<table>");
            body.Append("<caption>Request Headers</caption>");
            foreach (string name in context.Request.Headers)
            {
                var values = context.Request.Headers.GetValues(name);

                foreach (var value in values)
                {
                    body.AppendFormat("<tr><th>{0}</th><td>{1}</td></tr>", HttpUtility.HtmlEncode(name), HttpUtility.HtmlEncode(value));
                }
            }
            body.Append("</table>");
        }
    }
}