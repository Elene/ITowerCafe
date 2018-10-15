using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITowerCafe.Data;
using ITowerCafe.Services;

namespace ITowerCafe.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            var orders = OrderService.GetOrdersByUserId(1);

            return View(orders);
        }
        
        public ActionResult Review(int orderId)
        {
            Review review = new Review();

            ViewBag.OrderId = orderId;

            PopulateSelectLists(review);

            return View(review);
        }

        private void PopulateSelectLists(Review review)
        {
            var ratingSelectList = new List<SelectListItem>();
            for(int i = 1; i <= 5; i++)
            {
                var current = new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString(),
                    Selected = i == 5
                };
                ratingSelectList.Add(current);
            }

            var commentTypesSelectList = FormService.GetCommentTypes().Select(commentType => new SelectListItem
            {
                Text = commentType.Name,
                Value = commentType.Id.ToString(),
                Selected = commentType.Id == review.Id
            });

            review.Ratings = ratingSelectList;
            review.CommentTypes = commentTypesSelectList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review(int orderId, Review review)
        {
            if (ModelState.IsValid)
            {
                review.OrderId = orderId;

                //var comment = review.Comment;
                //int commentId = OrderService.AddComment(comment);

                //var rating = review.Rating;
                //int ratingId = OrderService.AddRating(rating);

                //review.CommentId = commentId;
                //review.RatingId = ratingId;

                int id = OrderService.AddReview(review);

                return RedirectToAction("Index");
            }

            return View(review);
        }

        public ActionResult Details(int orderId)
        {
            var orderDetails = OrderService.GetOrderDetailsByOrderId(orderId);

            return View(orderDetails);
        }
    }
}