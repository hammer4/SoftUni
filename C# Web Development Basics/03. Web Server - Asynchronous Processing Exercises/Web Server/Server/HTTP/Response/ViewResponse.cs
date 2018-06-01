using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Contracts;
using WebServer.Server.Enums;

namespace WebServer.Server.HTTP.Response
{
    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode responseCode, IView view)
        {
            this.ValidateStatusCode(responseCode);

            this.StatusCode = responseCode;
            this.view = view;
        }

        protected override string BuildResponse()
        {
            var response = base.BuildResponse() + this.view.View();

            return response;
        }

        private void ValidateStatusCode(HttpStatusCode responseCode)
        {
            var statusCodeNumber = (int)responseCode;

            var isViewResponse = statusCodeNumber < 300 || statusCodeNumber > 399;

            if (!isViewResponse)
            {
                throw new ArgumentException();
            }
        }
    }
}
