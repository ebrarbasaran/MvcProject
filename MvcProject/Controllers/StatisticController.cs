using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class StatisticController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var TotalCategory = c.Categories.Count();
            ViewBag.r1 = TotalCategory;

            var TotalSoftware = c.Headings.Where(p => p.HeadingName == "Yazılım").Count();
            ViewBag.r2 = TotalSoftware;

            var WritersInA = c.Writers.Where(p => p.WriterName.Contains("a")).Count();
            ViewBag.r3 = WritersInA;

            var MaxHeadings = c.Headings.Max(p => p.Category.CategoryName);
            ViewBag.r4 = MaxHeadings;

            var StatusIsTrue = c.Categories.Where(p => p.CategoryStatus == true).Count();
            var StatusIsFalse = c.Categories.Where(p => p.CategoryStatus == false).Count();
            ViewBag.r5 = (StatusIsTrue - StatusIsFalse);

            return View();
        }

        

    }
}