using System;
using System.Text;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant>GetAll();
        IEnumerable<Restaurant> GetRestaurantByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name="Indian food", Location = "ny, ny", Cuisine = CuisineType.Indian},
                new Restaurant{Id = 1, Name="Mexican rest", Location = "la, ca", Cuisine = CuisineType.Mexican},
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                    orderby r.Name
                    select r;

        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name){
            return from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name
                    select r;
        }
    }
}