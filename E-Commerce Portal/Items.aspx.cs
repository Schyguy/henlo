using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Commerce_Portal.Models;
using System.Web.ModelBinding;

namespace E_Commerce_Portal
{
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Gazebo> GetGazebos([QueryString("id")] int? categoryId)
        {
            var _db = new E_Commerce_Portal.Models.GazeboContext();
            IQueryable<Gazebo> query = _db.Gazebos;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(g => g.CategoryID == categoryId);
            }
            return query;
        }
    }
}