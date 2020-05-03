using System;
using System.Collections.Generic;
using System.Text;

namespace OrdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType MyProperty { get; set; }
    }
}