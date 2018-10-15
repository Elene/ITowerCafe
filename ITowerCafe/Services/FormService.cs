using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITowerCafe.Data;
using ITowerCafe.Models;
using System.Data.Entity;

namespace ITowerCafe.Services
{
    public class FormService
    {
        public static IEnumerable<CompanyType> GetCompanyTypes()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.CompanyTypes.ToList();
            }
        }

        public static IEnumerable<CompanyCostType> GetCompanyCostTypes()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.CompanyCostTypes.ToList();
            }
        }

        public static IEnumerable<CommentType> GetCommentTypes()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.CommentTypes.ToList();
            }
        }

        public static IEnumerable<ProductCategory> GetProductCategories()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.ProductCategories.ToList();
            }
        }

        public static IEnumerable<Product> GetProducts()
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                return entities.Products.ToList();
            }
        }

        public static IEnumerable<FormViewModel> GetForms()
        {
            List<FormViewModel> forms = new List<FormViewModel>();

            forms.Add(new FormViewModel
            {
                FormName = "Company Type",
                FormId = 1,
            });

            forms.Add(new FormViewModel
            {
                FormName = "Company Cost Type",
                FormId = 2,
            });

            forms.Add(new FormViewModel
            {
                FormName = "Comment Type",
                FormId = 3,
            });

            forms.Add(new FormViewModel
            {
                FormName = "Product Category",
                FormId = 4,
            });

            return forms;
        }

        public static void Add(SingleFormViewModel singleFormViewModel, int formId)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                switch (formId)
                {
                    case 1:
                        CompanyType ct = new CompanyType
                        {
                            Name = singleFormViewModel.Name
                        };
                        entities.CompanyTypes.Add(ct);
                        entities.SaveChanges();
                        break;
                    case 2:
                        CompanyCostType cct = new CompanyCostType
                        {
                            Name = singleFormViewModel.Name
                        };
                        entities.CompanyCostTypes.Add(cct);
                        entities.SaveChanges();
                        break;
                    case 3:
                        CommentType coT = new CommentType
                        {
                            Name = singleFormViewModel.Name
                        };
                        entities.CommentTypes.Add(coT);
                        entities.SaveChanges();
                        break;
                    case 4:
                        ProductCategory pc = new ProductCategory
                        {
                            Name = singleFormViewModel.Name
                        };
                        entities.ProductCategories.Add(pc);
                        entities.SaveChanges();
                        break;
                }
            }
        }

        public static void Remove(int itemId, int formId)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                switch (formId)
                {
                    case 1:
                        CompanyType ct = entities.CompanyTypes.SingleOrDefault(type => type.Id == itemId);

                        entities.CompanyTypes.Attach(ct);

                        entities.CompanyTypes.Remove(ct);
                        entities.SaveChanges();
                        break;
                    case 2:
                        CompanyCostType cct = entities.CompanyCostTypes.SingleOrDefault(type => type.Id == itemId);

                        entities.CompanyCostTypes.Attach(cct);

                        entities.CompanyCostTypes.Remove(cct);
                        entities.SaveChanges();
                        break;
                    case 3:
                        CommentType coT = entities.CommentTypes.SingleOrDefault(type => type.Id == itemId);

                        entities.CommentTypes.Attach(coT);

                        entities.CommentTypes.Remove(coT);
                        entities.SaveChanges();
                        break;
                    case 4:
                        ProductCategory pc = entities.ProductCategories.SingleOrDefault(type => type.Id == itemId);

                        entities.ProductCategories.Attach(pc);

                        entities.ProductCategories.Remove(pc);
                        entities.SaveChanges();
                        break;
                }
            }
        }

        public static IEnumerable<SingleFormViewModel> FindById(int id)
        {
            
            switch (id) {
                case 1:
                    var types = GetCompanyTypes().Select(companyType => new SingleFormViewModel
                    {
                        Name = companyType.Name,
                        Id = companyType.Id
                    });
                    return types;
                case 2:
                    var costTypes = GetCompanyCostTypes().Select(companyCostType => new SingleFormViewModel
                    {
                        Name = companyCostType.Name,
                        Id = companyCostType.Id
                    });
                    return costTypes;
                case 3:
                    var commentTypes = GetCommentTypes().Select(commentType => new SingleFormViewModel
                    {
                        Name = commentType.Name,
                        Id = commentType.Id
                    });
                    return commentTypes;
                case 4:
                    var productCategories = GetProductCategories().Select(productCategory => new SingleFormViewModel
                    {
                        Name = productCategory.Name,
                        Id = productCategory.Id
                    });
                    return productCategories;
                default:
                    return null;
            }
        }
    }
}