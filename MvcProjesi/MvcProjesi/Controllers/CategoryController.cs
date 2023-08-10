using BusinessLayer.VaildationRules;
using BussinesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProjesi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        // GET: Category
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAdd(p);
            CategoryValidatior CategoryValidator = new CategoryValidatior();
            ValidationResult results = CategoryValidator.Validate(p);
            if(results.IsValid) 
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GeetCategoryList");
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

    }
    
}
