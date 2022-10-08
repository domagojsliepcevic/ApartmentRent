using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRent.Controllers
{
    public class BookingController : Controller
    {
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Booking()
        {
            return View();
        }
    }
}
