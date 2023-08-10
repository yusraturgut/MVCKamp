using BusinessLayer.Concrete;
using BusinessLayer.VaildationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidatior cv=new ContactValidatior();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues=cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

    }
}