using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace E_Commerce_Portal.Models
{
    public class ShopCart
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int GazeboId { get; set; }

        public virtual Gazebo Gazebo { get; set; }
    }
}