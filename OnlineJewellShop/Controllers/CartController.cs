using OnlineJewellShop.BL;
using OnlineJewellShop.DAL;
using OnlineJewellShop.Entity;
using OnlineJewellShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace OnlineJewellShop.Controllers
{

    public class CartController : Controller
    {
        IProductCategoryBL productCategoryBL;
        IProductBL productBL;
        IShoppingCartBL ShoppingCartBL;
        DbConnect storeDB = new DbConnect();
        //creating reference for interface
        public CartController()
        {
            productCategoryBL = new ProductCategoryBL();
            productBL = new ProductBL();
            ShoppingCartBL = new ShoppingCartBL();
        }
        public ActionResult ViewProduct(int id)
        {
            Product product = productBL.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult ViewProduct(ProductModel product)
        {
            return RedirectToAction("AddToCart");
        }
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            try
            {
                Product product = productBL.GetProduct(id);
                // Add it to the shopping cart
                var cart = ShoppingCart.GetCart(this.HttpContext);

                cart.AddToCart(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Error");
            }
        }

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
               
            };
            // Return the view
            if (cart.GetTotal() == 0)
            {
                ViewBag.Total = "Cart is empty";
                return View();
                
            }
            else
            {
                return View(viewModel);
            }
            
        }
        //
        // GET: /Store/AddToCart/5

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpGet]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string ProductName = storeDB.Carts
                .Single(item => item.ProductId == id).Product.ProductName;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(ProductName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return RedirectToAction("Index");
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection collection)
        {
            var order = new OrderEntity();
            TryUpdateModel(order);
            var carts = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = carts.GetCartItems(),
                CartTotal = carts.GetTotal()
            };
            try
            {
                if (collection.Count>0)
                {

                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    order.Total = viewModel.CartTotal;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
                return View();

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        public ActionResult Complete(int id)
        {
            ShoppingCart cart = new ShoppingCart();
            // Validate customer owns this order
            IEnumerable<OrderDetail> products = cart.GetOrderDetails(id);
            return View(products);
            
        }
        [HttpGet]//get method for Payment
        public ActionResult Payment()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Payment(PaymentModel payment)
        {
           
                if (ModelState.IsValid)
                {
                    

                    var pay = AutoMapper.Mapper.Map<PaymentModel, Payment>(payment);
                        


                        ShoppingCartBL.Payment(pay);
                        return RedirectToAction("Final");
                    }
                return View();
        }
        public ActionResult Final()
        {
            return View();
        }

    }
}