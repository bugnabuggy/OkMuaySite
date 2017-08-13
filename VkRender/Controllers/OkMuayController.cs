using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkMuay.Vkontakte;

namespace OkMuay.Controllers
{
    public class OkMuayController : Controller
    {
        public ActionResult Index()
        {
			var api = new VkApi();
			var wall = api.GetWall("12343864");
            return View(wall);
        }

	    public ActionResult Trainings()
	    {
		    return View();
	    }
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

	    public ActionResult GetBgPics()
	    {
		    var list = new List<string>();
			var files = new DirectoryInfo(Server.MapPath("~/BgPics/"));
			foreach (var file in files.GetFiles("*.jpg"))
		    {
				list.Add(file.Name);   
		    }

		    return Json(list, JsonRequestBehavior.AllowGet);
	    }
    }
}