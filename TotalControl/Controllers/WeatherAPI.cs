using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TotalControl.Controllers
{
    public class WeatherAPI : Controller
    {
        // GET: WeatherAPI
        public ActionResult Index()
        {
            return View();
        }
    }
}