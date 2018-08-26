using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace StatusWeb
{
    public class StatusHandler : IHttpHandler
    {
        static readonly Regex _areaNormalizer = new Regex(@"[^a-zA-Z]", RegexOptions.Compiled);

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var area = string.Join("/", context.Request.Url.Segments.Skip(2).Select(s => _areaNormalizer.Replace(s, "_")));
            var statusCode = 200;

            var body = new StringBuilder();
            body.Append(@"<!doctype html><html><head>
<style>
body { font-family: consolas; margin: 0; }
table { width: 100%; }
th { white-space: nowrap; text-align: right; }
caption { color: #fff; background-color: #000; }
</style></head><body>");
            body.AppendFormat("<h1>{0}</h1>", area);
            RequestDumper.AppendHtml(body, context);
            body.Append("</body></html>");

            context.Response.StatusCode = statusCode;
            context.Response.Write(body);
        }
    }
}
