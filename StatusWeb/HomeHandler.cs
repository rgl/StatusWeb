using System.Text;
using System.Web;

namespace StatusWeb
{
    public class HomeHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var body = new StringBuilder();
            body.Append(@"<!doctype html><html><head>
<style>
body { font-family: consolas; margin: 0; }
table { width: 100%; }
th { white-space: nowrap; text-align: right; }
caption { color: #fff; background-color: #000; }
</style></head><body>");
            body.Append("<p><a href='status/health'>status/health</a> | <a href='status/management'>status/management</a></p>");
            RequestDumper.AppendHtml(body, context);
            body.Append("</body></html>");

            context.Response.Write(body);
        }
    }
}
