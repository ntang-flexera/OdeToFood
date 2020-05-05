using System.Text;
using System.Collections.Generic;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant restaurant);
       Restaurant Delete(int Id);
        int Commit();
    }
}