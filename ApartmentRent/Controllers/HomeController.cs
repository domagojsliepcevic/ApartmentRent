using ApartmentRent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ApartmentRent.Controllers
{
    public class HomeController : Controller
    {

        private ApartmentUnitOfWork data { get; set; }

        public HomeController(DatabaseContext ctx) => data = new ApartmentUnitOfWork(ctx);



        public IActionResult Index()
        {

            var apartments = data.Apartments.List(new QueryOptions<Apartment>
            {
                Include="ApartmentProfilePicture",
                OrderBy = a => a.ApartmentId
            });
          
            
            return View(apartments);
        }

      
    }
}
