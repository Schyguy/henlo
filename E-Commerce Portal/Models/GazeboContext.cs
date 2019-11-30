using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_Commerce_Portal.Models
{
    public class GazeboContext : DbContext
    {
        public GazeboContext() : base("E_Commerce_Portal")
        {

        }
        public DbSet<Gazebo> Gazebos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCart> CartItems { get; set; }
    }
}