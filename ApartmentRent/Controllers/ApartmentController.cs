using ApartmentRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRent.Controllers
{
    public class ApartmentController : Controller
    {

        private ApartmentUnitOfWork data { get; set; }
        public ApartmentController(DatabaseContext ctx) => data = new ApartmentUnitOfWork(ctx);

        public IActionResult Index() => RedirectToAction("Index","Home");

        public ViewResult Details(int id)
        {
            var apartment = data.Apartments.Get(new QueryOptions<Apartment>
            {
                Include = "TaggedApartment.Tag, ApartmentAlbum.Picture,City,Owner,Status,ApartmentProfilePicture",
                Where = b => b.ApartmentId == id
            });
            return View(apartment);
        }




    }
}
