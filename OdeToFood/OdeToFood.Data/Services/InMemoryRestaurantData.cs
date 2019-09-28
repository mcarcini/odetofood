using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        

        public InMemoryRestaurantData() {
            restaurants = new List<Restaurant>
            {
                new Restaurant{ Id=1, Name = "Pizza Italiana", Cuisine=CuisineType.Italian},
                new Restaurant{ Id=2, Name = "Tersiguels", Cuisine=CuisineType.French},
                new Restaurant{ Id=3, Name = "Mango Grove", Cuisine=CuisineType.Indian}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Edit(Restaurant restaurant)
        {
            var existingModel = Get(restaurant.Id);

            if (existingModel != null) {
                existingModel.Name = restaurant.Name;
                existingModel.Cuisine = restaurant.Cuisine;
            }

        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id); 
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Delete(int id)
        {
            var model = Get(id);
            if (model != null) {
                restaurants.Remove(model);
            }
        }
    }
}
