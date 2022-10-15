using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRent.Controllers
{
    public class ReservationController : Controller
    {
        [Authorize(Roles = "Member,Admin")]
        public IActionResult Reservation()
        {
            return View();
        }
    }
}
