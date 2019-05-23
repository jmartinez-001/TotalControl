using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotalControl.Models;

namespace TotalControl.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.IsInRole("Coordinator"))
            {
                return RedirectToAction("Index", "Coordinator");
            }
            else if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "Manager");
            }
            else if (User.IsInRole("Associate"))
            {
                return RedirectToAction("Index", "Associate");
            }
            else
            {
                return View();
            }

        }

        
    }
}