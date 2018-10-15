using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITowerCafe.Services;
using ITowerCafe.Models;

namespace ITowerCafe.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            var forms = FormService.GetForms();

            return View(forms);
        }

        public ActionResult Details(int id)
        {
            var formElements = FormService.FindById(id);

            ViewBag.FormId = id;

            return View(formElements);
        }

        public ActionResult Create(int formId)
        {
            var singleFormViewModel = new SingleFormViewModel();

            ViewBag.FormId = formId;

            return View(singleFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int formId, SingleFormViewModel singleFormViewModel)
        {
            System.Diagnostics.Debug.WriteLine(formId);

            if (ModelState.IsValid)
            {
                FormService.Add(singleFormViewModel, formId);

                var formElements = FormService.FindById(formId);

                ViewBag.FormId = formId;

                return View("Details", formElements);
            }

            ViewBag.FormId = formId;

            return View(singleFormViewModel);
        }


        public ActionResult Remove(int formId, int itemId)
        {
            System.Diagnostics.Debug.WriteLine(formId);

            FormService.Remove(itemId, formId);

            var formElements = FormService.FindById(formId);

            ViewBag.FormId = formId;

            return View("Details", formElements);
        }
    }
}