using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 4, Name="Indian food", Location = "ny, ny", Cuisine = CuisineType.Indian},
                new Restaurant{Id = 20, Name="Mexican rest", Location = "la, ca", Cuisine = CuisineType.Mexican},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                    orderby r.Name
                    select r;

        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name){
            return from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                    orderby r.Name
                    select r;
        }

         public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) +1;
            restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == Id);
            if (restaurant != null){
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }
    }
}