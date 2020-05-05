using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int Id)
        {
            var restaurant = GetById(Id);
            if(restaurant != null){
                db.Restaurants.Remove(restaurant);
                return restaurant;
            }

            return new Restaurant();
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            
            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;

            return restaurant;
        }
    }
}