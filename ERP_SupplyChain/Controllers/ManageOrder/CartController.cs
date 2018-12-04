using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPEntities.DataContext;
using ERPEntities.Models;
using System.Data;

namespace ERP_SupplyChain.Controllers.ManageOder
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            //Init product list
            var cart = Session["cart"] as List<CartViewModel> ?? new List<CartViewModel>();

            //Check if the car is empty
            if( cart.Count == 0 || Session["cart"] == null)
            {
                ViewBag.message = "No item is added";
                return View();
            }

            //Calculate total and add to viewbag
            decimal Total = 0m;
            foreach(var item in cart)
            {
                Total = item.Total;
            }
            ViewBag.GrandTotal = Total;

            //Return view
            return View(cart);
        }

        public JsonResult cartPartial(int id, int quantity,DateTime orderDate)
        {
            //Init CartVM List
            List<CartViewModel> cart = Session["cart"] as List<CartViewModel> ?? new List<CartViewModel>();

            //Init CartVM
            CartViewModel CartModel = new CartViewModel();
 
            using (ERPDataContext db = new ERPDataContext())
            {
                //Get Product
                Item Product = db.Items.First(x => x.ItemID == id);

                //Check if product is in the cart
                var ProductinCart = cart.FirstOrDefault(x => x.ProductID == id);

                //If not, add new
                if(ProductinCart == null)
                {
                    cart.Add(new CartViewModel()
                    {
                        ProductID = Product.ItemID,
                        ProductName = Product.ItemName,
                        Price = (decimal)(Product.PurchasePrice),
                        Quantity = quantity,
                        OrderDate = orderDate,
                        });
                }
                else
                {
                    //if yes increment
                    ProductinCart.Quantity++;

                }
            }

            //Get total quantity and add it to model
            int qty = 0;
            decimal price = 0m;
            foreach (var item in cart) 
            {
                qty = item.Quantity;
                price = item.Price;

            }
           

            //Save cart back to session
            Session["cart"] = cart;

            //Return view with modal
            return Json(CartModel, JsonRequestBehavior.AllowGet);
        }
	}
}