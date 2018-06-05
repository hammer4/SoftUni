namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Server.Http.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index() => this.FileViewResponse(@"home\index");

        public IHttpResponse About() => this.FileViewResponse(@"home\about");
    }
}
