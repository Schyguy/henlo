using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce_Portal.Models;

namespace E_Commerce_Portal.Logic
{
    public class CartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private GazeboContext _db = new GazeboContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the Gazebo from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = _db.CartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.GazeboId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new ShopCart
                {
                    ItemId = Guid.NewGuid().ToString(),
                    GazeboId = id,
                    CartId = ShoppingCartId,
                    Gazebo = _db.Gazebos.SingleOrDefault(
                   g => g.GazeboID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<ShopCart> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.CartItems.Where(c => c.CartId == ShoppingCartId).ToList();
        }

        public decimal GetTotal()
        {
            ShoppingCartId = GetCartId();
            decimal? total = decimal.Zero;
            total = (decimal?)(from cartItems in _db.CartItems
                               where cartItems.CartId == ShoppingCartId
                               select (int?)cartItems.Quantity *
                               cartItems.Gazebo.UnitPrice).Sum();
            return total ?? decimal.Zero;
        }
        public CartActions GetCart(HttpContext context)
        {
            using (var cart = new CartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new E_Commerce_Portal.Models.GazeboContext())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<ShopCart> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Gazebo.GazeboID == CartItemUpdates[i].GazeboId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.GazeboId);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.GazeboId, CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeGazeboID)
        {
            using (var _db = new E_Commerce_Portal.Models.GazeboContext())
            {
                try
                {
                    var myItem = (from c in _db.CartItems where c.CartId == removeCartID && c.Gazebo.GazeboID == removeGazeboID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.CartItems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateGazeboID, int quantity)
        {
            using (var _db = new E_Commerce_Portal.Models.GazeboContext())
            {
                try
                {
                    var myItem = (from c in _db.CartItems where c.CartId == updateCartID && c.Gazebo.GazeboID == updateGazeboID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        myItem.Quantity = quantity;
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.CartItems.Where(
                c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.CartItems.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.CartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int GazeboId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }
    }
}


