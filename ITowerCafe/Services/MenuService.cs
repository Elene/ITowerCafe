using ITowerCafe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITowerCafe.Models;

namespace ITowerCafe.Services
{
    public class MenuService
    {
        public static int AddMenu(Menu menu)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                entities.Menus.Add(menu);
                entities.SaveChanges();
                return menu.Id;
            }
        }

        public static int AddProduct(MenuProduct menuProduct)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                entities.MenuProducts.Add(menuProduct);
                entities.SaveChanges();
                return menuProduct.Id;
            }
        }

        public static void AddMenuMapping(MenuProductsMap menuProductsMap)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                entities.MenuProductsMaps.Add(menuProductsMap);
                entities.SaveChanges();
            }
        }

        public static DisplayMenuItemViewModel GetMenuItemByMenuProductId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var mp = entities.MenuProducts.SingleOrDefault(menuProduct => menuProduct.Id == id);
                return new DisplayMenuItemViewModel
                {
                    Id = mp.Id,
                    Name = mp.Name,
                    PreparationTime = mp.PreparationTime,
                    Price = mp.Price,
                    Category = mp.ProductCategory.Name,
                    ProductCode = mp.Product.Name
                };
            }
        }

        public static List<DisplayMenuItemViewModel> GetMenuByCompanyId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                int menuId = entities.Menus.SingleOrDefault(menu => menu.CreatorCompanyId == id).Id;
                var joined = (from mpm in entities.MenuProductsMaps
                              join mp in entities.MenuProducts on
                              mpm.MenuProductId equals mp.Id
                              where mpm.MenuId == menuId
                              select new DisplayMenuItemViewModel
                              {
                                  Id = mp.Id,
                                  Name = mp.Name,
                                  PreparationTime = mp.PreparationTime,
                                  Price = mp.Price,
                                  Category = mp.ProductCategory.Name,
                                  ProductCode = mp.Product.Name
                              });
                return joined.ToList();
            }
        }
    }
}