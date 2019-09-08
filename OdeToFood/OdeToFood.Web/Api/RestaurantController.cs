using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantController : ApiController
    {

        private IRestaurantData db;


        public RestaurantController(IRestaurantData db) {
            this.db= db;
        }

        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }

    }
}