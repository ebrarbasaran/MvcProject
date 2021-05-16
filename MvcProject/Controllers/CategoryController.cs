using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetCategoryList();
            return View(categoryValues); //view dönerken categoryvalues'daki değerleri de getir
        }

        [HttpGet] //sayfa yüklendiğinde çalışacak
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost] //sayfada bir şey post edilidğinde çalışacak
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p); //ValidationResult türünde results değişkenini oluşturduk ve
                                                                       //CategoryValidator sınıfında olan değerlere göre kontrolünü yaptırdık .Validate() ile
            if (results.IsValid)
            {
                cm.CategoryAddBL(p); 
                RedirectToAction("GetCategoryList"); //Ekleme işlemi gerçekleştikten sonra
                                                     //içeride girilen metota yönlendirdik
            }
            else 
            {
                foreach (var item in results.Errors) //hata mesajlarını tutacağımız döngü
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
  
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetById(id);
            return View();
        }
    }
}