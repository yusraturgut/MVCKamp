using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.VaildationRules;
using FluentValidation.Results;

namespace MvcProjesi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator= new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult Sendbox(string p) 
        {
            var messageList=mm.GetListSendbox(p);
            return View(messageList);
        }
        public ActionResult GetMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage () 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {

            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public ActionResult IsRead(int id)
        {
            var result = mm.GetByID(id);
            if (result.ısRead == false)
            {
                result.ısRead = true;
            }
            else
            {
                result.ısRead = false;
            }
            mm.MessageUpdate(result);
            return RedirectToAction("Inbox");
        }
        

        public ActionResult MessageUnRead()
        {
            var result = mm.GetAllRead();
            return View(result);
        }
    }
    }
