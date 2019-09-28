using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public void Add(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges();
        }

        public void Edit(Restaurant restaurant)
        {
            var entry = dbContext.Entry(restaurant);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return dbContext.Restaurants;
            return from r in dbContext.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Delete(int id) {
            var model = dbContext.Restaurants.Find(id);
            if (model != null) {
                dbContext.Restaurants.Remove(model);
                dbContext.SaveChanges();
            }
        }
    }
}
