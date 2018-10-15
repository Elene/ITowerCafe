using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITowerCafe.Data;
using ITowerCafe.Models;
using ITowerCafe.Services;

namespace ITowerCafe.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int menuId, int companyId)
        {
            Debug.WriteLine("Menu");

            var createMenuItemViewModel = new CreateMenuItemViewModel();

            ViewBag.MenuId = menuId;
            ViewBag.CompanyId = companyId;

            PopulateSelectLists(createMenuItemViewModel);

            return View(createMenuItemViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int menuId, int companyId, CreateMenuItemViewModel createMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var menuProduct = new MenuProduct();
                PopulateMenu(createMenuItemViewModel, menuProduct);

                int productId = MenuService.AddProduct(menuProduct);

                MenuService.AddMenuMapping(new MenuProductsMap
                {
                    MenuId = menuId,
                    MenuProductId = productId
                });
                return RedirectToAction("Details", "Company", new { id = companyId });
            }

            ViewBag.MenuId = menuId;

            PopulateSelectLists(createMenuItemViewModel);

            return View(createMenuItemViewModel);
        }

        private void PopulateMenu(CreateMenuItemViewModel createMenuItemViewModel, MenuProduct menuProduct)
        {
            menuProduct.Name = createMenuItemViewModel.Name;
            menuProduct.PreparationTime = createMenuItemViewModel.PreparationTime;
            menuProduct.Price = createMenuItemViewModel.Price;
            menuProduct.CategoryId = createMenuItemViewModel.CategoryId;
            menuProduct.ProductCodeId = createMenuItemViewModel.ProductCodeId;
        }

        private void PopulateSelectLists(CreateMenuItemViewModel createMenuItemViewModel)
        {
            var productCategoriesSelectList = FormService.GetProductCategories().Select(productCategory => new SelectListItem
            {
                Text = productCategory.Name,
                Value = productCategory.Id.ToString(),
                Selected = productCategory.Id == createMenuItemViewModel.Id
            });

            var productCodesSelectList = FormService.GetProducts().Select(product => new SelectListItem
            {
                Text = product.Code,
                Value = product.Id.ToString(),
                Selected = product.Id == createMenuItemViewModel.Id
            });

            createMenuItemViewModel.Categories = productCategoriesSelectList;
            createMenuItemViewModel.Products = productCodesSelectList;
        }
    }
}