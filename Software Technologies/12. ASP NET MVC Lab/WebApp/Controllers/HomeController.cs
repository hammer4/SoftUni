using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Numbers()
        {
            return View();
        }

        public ActionResult Files()
        {
            var path = @"C:\";
            var files = Directory.GetDirectories(path).ToList();
            files.AddRange(Directory.GetFiles(path));
            return View(files);
        }

        public ActionResult FilesInFolder(string path = @"C:\")
        {
            var files = Directory.GetDirectories(path).ToList();
            files.AddRange(Directory.GetFiles(path));
            ViewBag.Path = path;
            return View(files);
        }
    }
}