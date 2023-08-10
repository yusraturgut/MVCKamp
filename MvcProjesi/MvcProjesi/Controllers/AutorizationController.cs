using BusinessLayer.Concrete;
using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
   
    public class AutorizationController : Controller
    {
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        // GET: Autorization
        public ActionResult Index()
        {
            var adminvalues=adminmanager.GetList();
            return View(adminvalues);
        }
    }
}