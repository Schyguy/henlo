using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Portal.Models
{
    public class Gazebo
    {
        [ScaffoldColumn(false)]
        public int GazeboID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string GazeboName { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}