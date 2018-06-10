namespace WebServer.ByTheCakeApplication.Infrastructure
{
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Views;

    public abstract class Controller
    {
        private const string DefaultPath = @"../../../ByTheCakeApplication\Resources\{0}.html";
        private const string ContentPlaceholder = "{{{content}}}";

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["authDisplay"] = "block",  // show logout button
                ["showError"] = "none"      // hide form errors
            };
        }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var resultHtml = ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    resultHtml = resultHtml.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(resultHtml));
        }

        private static string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));
            var fileHtml = File.ReadAllText(string.Format(DefaultPath, fileName));

            return layoutHtml.Replace(ContentPlaceholder, fileHtml);
        }

        protected void AddError(string errorMessage)
        {
            this.ViewData["showError"] = "block";
            this.ViewData["error"] = errorMessage;
        }
    }
}
