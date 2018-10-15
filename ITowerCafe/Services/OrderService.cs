using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITowerCafe.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ITowerCafe.Services
{
    public class OrderService
    {
        public static int AddOrder(Order order)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                entities.Orders.Add(order);
                entities.SaveChanges();
                return order.Id;
            }
        }

        public static void AddOrderDetail(OrderDetail orderDetail)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                entities.OrderDetails.Add(orderDetail);
                entities.SaveChanges();
            }
        }

        public static IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var orders = entities.Orders
                    .Include(order => order.Company)
                    .Where(order => order.UserId == userId);
                return orders.ToList();
            }
        }

        public static int AddReview(Review review)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var orders = entities.Reviews.Add(review);
                entities.SaveChanges();
                return review.Id;
            }
        }

        public static int AddComment(Comment comment)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var orders = entities.Comments.Add(comment);
                entities.SaveChanges();
                return comment.Id;
            }
        }

        public static int AddRating(Rating rating)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var orders = entities.Ratings.Add(rating);
                entities.SaveChanges();
                return rating.Id;
            }
        }

        public static List<Comment> GetCommentsByCompanyId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var joined = (from r in entities.Reviews
                              join c in entities.Comments on
                              r.CommentId equals c.Id
                              join o in entities.Orders on
                              r.OrderId equals o.Id
                              where o.CompanyId == id
                              select c);
                return joined.ToList();

            }
        }

        public static IEnumerable<MenuProduct> GetOrderDetailsByOrderId(int id)
        {
            using (var entities = new ITowerCafeDBEntities())
            {
                var joined = (from od in entities.OrderDetails
                              join mp in entities.MenuProducts on
                              od.ProductId equals mp.Id
                              where od.OrderId == id
                              select mp);
                return joined
                    .Include(product => product.ProductCategory)
                    .Include(product => product.Product)
                    .ToList();
            }
        }
    }
}