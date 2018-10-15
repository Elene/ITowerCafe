using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITowerCafe.Models;
using ITowerCafe.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ITowerCafe.Services
{
    class CompanyService
    {
        public static IEnumerable<Company> GetCompanies()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var companies = entities.Companies
                    .Include(company => company.CompanyType)
                    .Include(company => company.CompanyCostType);
                return companies.ToList();
            }
        }

        public static Company GetCompanyById(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.Companies.Include(company => company.CompanyType)
                    .Include(company => company.CompanyCostType).SingleOrDefault(company => company.Id == id);
            }
        }

        public static LoadCompanyViewModel GetCompanyToLoadById(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var cmp = entities.Companies.Include(company => company.CompanyType)
                    .Include(company => company.CompanyCostType).SingleOrDefault(company => company.Id == id);

                LoadCompanyViewModel result = new LoadCompanyViewModel();
                result.Name = cmp.Name;
                result.Description = cmp.Description;
                result.LogoUrl = cmp.LogoUrl;
                result.CompanyType = cmp.CompanyType;
                result.CompanyCostType = cmp.CompanyCostType;
                result.RegistrationDate = cmp.CreateDate;
                var rating = (from r in entities.Ratings
                              join re in entities.Reviews on
                              r.Id equals re.RatingId
                              join o in entities.Orders on
                              re.OrderId equals o.Id
                              where o.CompanyId == id
                              select r.Value);
                result.AvgRating = rating.Average();
                result.RatingCount = rating.Count();

                return result;
            }
        }

        public static double GetAverageRatingByCompanyId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var rating = (from r in entities.Ratings
                              join re in entities.Reviews on
                              r.Id equals re.RatingId
                              join o in entities.Orders on
                              re.OrderId equals o.Id
                              where o.CompanyId == id
                              select r.Value);
                if (rating.Count() == 0)
                    return 0;
                return rating.Average();
            }
        }

        public static int GetRatingCountByCompanyId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var rating = (from r in entities.Ratings
                              join re in entities.Reviews on
                              r.Id equals re.RatingId
                              join o in entities.Orders on
                              re.OrderId equals o.Id
                              where o.CompanyId == id
                              select r.Value);


                if (rating == null)
                    return 0;

                return rating.Count();
            }
        }
        public static int Add(Company company)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                entities.Companies.Add(company);
                entities.SaveChanges();
                return company.Id;  
            }
        }

        public static int GetMenuIdByCompanyId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.Menus.SingleOrDefault(menu => menu.CreatorCompanyId == id).Id;
            }
        }
    }


}