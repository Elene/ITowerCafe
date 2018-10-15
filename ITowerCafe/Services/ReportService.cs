using ITowerCafe.Data;
using ITowerCafe.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace ITowerCafe.Controllers
{
    internal class ReportService
    {
        public static ReportViewModel GetReports()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                ReportViewModel reportViewModel = new ReportViewModel();
                reportViewModel.PersonalStatistics = (from o in entities.Orders
                                                      where o.UserId == 1
                                                      group o.Cost by new { id = o.CompanyId, name = o.Company.Name} into t
                                                      select new PersonalStatisticViewModel
                                                      {
                                                        CompanyId = t.Key.id,
                                                        CompanyName = t.Key.name,
                                                        TotalCost = t.Sum()
                                                      }).ToList();

                int mostPopularProductId = entities.OrderDetails.GroupBy(od => od.ProductId).Select(g => new { key = g.Key, count = g.Count() }).
                    OrderByDescending(x => x.count).First().key;

                reportViewModel.MostPopularProduct = entities.MenuProducts.Include(x => x.Product).SingleOrDefault(od => od.Id == mostPopularProductId);

                return reportViewModel;
            }
        }
    }
}