using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using test_lightpoint.Models;

namespace test_lightpoint.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Shop, Product> db;

        public HomeController()
        {
            db = new SQLRepository();
        }
        public ActionResult ViewProduct(int shopId)
        {       
            return PartialView(db.GetProductsInShop(shopId));
        }
        
        public ActionResult Index()
        {
            ViewBag.shopList = db.GetShopList();
            ViewBag.productList = db.GetProductList();
            return View();
        }


        [HttpGet]
        public ActionResult AddProduct()
        {

            ViewBag.shopList = db.GetShopList();
            ViewBag.dropDownList =createShopList();
            return View();
        }
        SelectList createShopList()
        {
            
            SelectList s = new SelectList(db.GetShopList(), "id", "name");
            var selectList = from shops in db.GetShopList()
                             select new SelectListItem { Text = shops.name, Value = shops.id.ToString() };
            return s;
        }
        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            if (String.IsNullOrEmpty(model.name) || String.IsNullOrEmpty(model.desctiption))
            {

                ViewBag.shopList = db.GetShopList();
                ViewBag.dropDownList = createShopList();
                ModelState.AddModelError("MyError", "Ошибка. Заполните все поля");
                return View(model);
            }
            model.shopId = db.GetShopList().Where(c => c.id.ToString() == model.shopId.name).FirstOrDefault();
            db.CreateProduct(model);
            db.Save();
            return RedirectToAction("AddProduct");
        }

        [HttpGet]
        public ActionResult AddShop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShop(Shop model)
        {
            if (model.name == null || model.adres == null)
            {
                ModelState.AddModelError("MyError", "Ошибка. Заполните все поля");
                return View(model);
            }
            string[] days = new string[7];
            days[0] = model.Mo;
            days[1] = model.We;
            days[2] = model.Tu;
            days[3] = model.Th;
            days[4] = model.Su;
            days[5] = model.Sa;
            days[6] = model.Fr;
            for (int i = 0; i < days.Length; i++)
                if (days[i] == null)
                    days[i] = "Выходной";
            model.Mo = days[0];
            model.We = days[1];
            model.Tu = days[2];
            model.Th = days[3];
            model.Su = days[4];
            model.Sa = days[5];
            model.Fr = days[6];

            db.CreateShop(model);
            db.Save();
            return RedirectToAction("AddShop");
        }
    }
}
