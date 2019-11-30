using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using E_Commerce_Portal.Logic;

namespace E_Commerce_Portal

{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["GazeboID"];
            int gazeboId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out gazeboId))
            {
                using (CartActions usersShoppingCart = new CartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a GazeboId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a GazeboId.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}