using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web;
using ITowerCafe.Models;
using ITowerCafe.Services;
using ITowerCafe.Data;
using Microsoft.AspNet.Identity;

namespace ITowerCafe.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index(int companyId)
        {
            if (Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new List<DisplayMenuItemViewModel>();
                Session["CompanyId"] = companyId;
            }

            ViewBag.CompanyId = companyId;

            return View(Session["ShoppingCart"]);
        }

        [HttpPost]
        public ActionResult Index(int companyId, IEnumerable<ITowerCafe.Models.DisplayMenuItemViewModel> orderedItems)
        {
            return RedirectToAction("Pay", "Cart", new { companyId = companyId } );
        }

        public ActionResult Pay(int companyId)
        {
            ViewBag.CompanyId = companyId;

            var sum = ((List<DisplayMenuItemViewModel>)Session["ShoppingCart"]).Sum(item => item.Price);

            ViewBag.MoneyToPay = sum;

            ViewBag.MoneyToString = NumberHelper.NumberToText((int)sum) + " Lari, "
                                    + NumberHelper.NumberToText((int)(sum - Math.Floor(sum))) + " Tetri";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pay(int companyId, CardViewModel cardViewModel)
        {
            if (ModelState.IsValid)
            {
                List <DisplayMenuItemViewModel> orderedItems = (List<DisplayMenuItemViewModel>)Session["ShoppingCart"];
                //System.Diagnostics.Debug.WriteLine("Dzilis droa {0} {1}", companyId, );
                int orderId = OrderService.AddOrder(new Order
                {
                    Cost = orderedItems.Sum(item => item.Price),
                    Date = new DateTime(),
                    Status = "N",
                    UserId = 1,
                    CompanyId = companyId
                });

                for (int i = 0; i < orderedItems.Count(); i++)
                {
                    OrderService.AddOrderDetail(new OrderDetail
                    {
                        OrderId = orderId,
                        ProductId = orderedItems.ElementAt(i).Id
                    });
                }

                Session["ShoppingCart"] = null;
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Add(int menuProductId, int companyId)
        { 
            if (Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new List<DisplayMenuItemViewModel>();
                Session["CompanyId"] = companyId;
            }

            if ((int)Session["CompanyId"] == companyId)
            {
                var cart = (List<DisplayMenuItemViewModel>)Session["ShoppingCart"];
                cart.Add(MenuService.GetMenuItemByMenuProductId(menuProductId));
                System.Diagnostics.Debug.WriteLine("{0}", cart.Count);
            }

            return RedirectToAction("Details", "Company", new { id = companyId});
        }

        public ActionResult Remove(int id, int companyId)
        {
            if (Session["ShoppingCart"] == null)
            {
                Session["ShoppingCart"] = new List<DisplayMenuItemViewModel>();
            }

            var cart = (List<DisplayMenuItemViewModel>)Session["ShoppingCart"];

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id == id)
                {
                    cart.Remove(cart[i]);
                    break;
                }
            }

            if(cart.Count == 0)
            {
                Session["ShoppingCart"] = null;
            }

            return RedirectToAction("Index", new { companyId = companyId });
        }

    }

}