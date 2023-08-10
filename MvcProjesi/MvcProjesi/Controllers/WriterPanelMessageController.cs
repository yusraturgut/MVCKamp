﻿using BusinessLayer.Concrete;
using BusinessLayer.VaildationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjesi.Controllers
{
    public class WriterPanelMessageController : Controller
    {

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var MessageList = mm.GetListInbox(p);
            return View(MessageList);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }
        public ActionResult GetMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
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
        public ActionResult MessageRead()
        {
            var result = mm.GetListInbox().Where(m => m.ısRead == true).ToList();
            return View(result);
        }
        public ActionResult MessageUnRead()
        {
            var result = mm.GetAllRead();
            return View(result);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);

        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
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
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }


    }
}