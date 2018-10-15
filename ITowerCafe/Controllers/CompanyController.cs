using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITowerCafe.Data;
using ITowerCafe.Models;
using ITowerCafe.Services;

namespace ITowerCafe.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var companies = CompanyService.GetCompanies().ToList();

            return View(companies);
        }

        public ActionResult Details(int id)
        {
            System.Diagnostics.Debug.WriteLine("{0}", id);
            var company = CompanyService.GetCompanyById(id);

            LoadCompanyViewModel loadCompany = new LoadCompanyViewModel();
            loadCompany.Id = company.Id;
            loadCompany.MenuId = CompanyService.GetMenuIdByCompanyId(company.Id);
            loadCompany.Name = company.Name;
            loadCompany.Description = company.Description;
            loadCompany.LogoUrl = company.LogoUrl;
            loadCompany.CompanyType = company.CompanyType;
            loadCompany.CompanyCostType = company.CompanyCostType;
            loadCompany.RegistrationDate = company.CreateDate;
            loadCompany.AvgRating = CompanyService.GetAverageRatingByCompanyId(company.Id);
            loadCompany.RatingCount = CompanyService.GetRatingCountByCompanyId(company.Id);
            loadCompany.MenuItems = MenuService.GetMenuByCompanyId(company.Id);
            loadCompany.Comments = OrderService.GetCommentsByCompanyId(company.Id);

            return View(loadCompany);
        }

        public ActionResult Create()
        {
            System.Diagnostics.Debug.WriteLine("Company");
            var createCompanyViewModel = new CreateCompanyViewModel();

            PopulateSelectLists(createCompanyViewModel);

            return View(createCompanyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCompanyViewModel createCompanyViewModel)
        {
            if (ModelState.IsValid)
            {
                var company = new Company();
                PopulateCompany(createCompanyViewModel, company);

                int id = CompanyService.Add(company);

                MenuService.AddMenu(new Menu
                {
                    CreatorCompanyId = id
                });

                return RedirectToAction("Index");
            }

            PopulateSelectLists(createCompanyViewModel);

            return View(createCompanyViewModel);
        }

        private void PopulateCompany(CreateCompanyViewModel createCompanyViewModel, Company company)
        {
            company.Name = createCompanyViewModel.Name;
            company.Description = createCompanyViewModel.Description;
            company.LogoUrl = createCompanyViewModel.LogoUrl;
            company.TypeId = createCompanyViewModel.TypeId;
            company.CostId = createCompanyViewModel.CostId;
        }


        private void PopulateSelectLists(CreateCompanyViewModel createCompanyViewModel)
        {
            var companyTypesSelectList = FormService.GetCompanyTypes().Select(companyType => new SelectListItem
            {
                Text = companyType.Name,
                Value = companyType.Id.ToString(),
                Selected = companyType.Id == createCompanyViewModel.Id
            });

            var companyCostTypesSelectList = FormService.GetCompanyCostTypes().Select(companyCostType => new SelectListItem
            {
                Text = companyCostType.Name,
                Value = companyCostType.Id.ToString(),
                Selected = companyCostType.Id == createCompanyViewModel.Id
            });

            createCompanyViewModel.CompanyTypes = companyTypesSelectList;
            createCompanyViewModel.CompanyCostTypes = companyCostTypesSelectList;
        }
    }
}
