using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce_Portal.Models
{
    public class GazeboDatabaseInitializer : DropCreateDatabaseIfModelChanges<GazeboContext>
    {
        protected override void Seed(GazeboContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetGazebos().ForEach(g => context.Gazebos.Add(g));
        }
        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Gazebo"
                },
            };

            return categories;
        }
        private static List<Gazebo> GetGazebos()
        {
            var gazebos = new List<Gazebo> {
                new Gazebo 
                {
                    GazeboID = 1,
                    GazeboName = "White Gazebo",
                    ImagePath = "Gazebo1.png",
                    UnitPrice = 6999.99
               },
                new Gazebo
                {
                    GazeboID = 2,
                    GazeboName = "Special Addition SRU Gazebo",
                    ImagePath = "Gazebo2.png",
                    UnitPrice = 250000.00
               },
                new Gazebo
                {
                    GazeboID = 3,
                    GazeboName = "Culture Gazebo",
                    ImagePath = "Gazebo3.png",
                    UnitPrice = 10000.00
                },
                new Gazebo
                {
                    GazeboID = 4,
                    GazeboName = "Beach Side Gazebo",
                    ImagePath = "Gazebo4.png",
                    UnitPrice = 12000.00
                },
                new Gazebo
                {
                    GazeboID = 5,
                    GazeboName = "Red Gazebo",
                    ImagePath = "Gazebo5.png",
                    UnitPrice = 125000.00
                },
                new Gazebo
                {
                    GazeboID = 6,
                    GazeboName = "Backyard Gazebo",
                    ImagePath = "Gazebo6.png",
                    UnitPrice = 8500.00
                }
            };

            return gazebos;
        }
    }
}