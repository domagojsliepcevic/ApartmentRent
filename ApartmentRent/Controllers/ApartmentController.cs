using ApartmentRent.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

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

            // get user id
            string currentUserId = null;
            var claimsIdentity = User.Identity as ClaimsIdentity;
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null) currentUserId = userIdClaim.Value;
            }

            if (!string.IsNullOrWhiteSpace(currentUserId))
            {
                var review = data.ApartmentReviews.Get(new QueryOptions<ApartmentReview>
                {
                    Where = b => b.ApartmentId == id && b.UserId == currentUserId,
                    OrderBy = b => b.ApartmentReviewId,
                    OrderByDirection = "desc"
                });
                if (review != null) ViewData["Review"] = review.ReviewText;
            }

            return View(apartment);
        }

        public ViewResult List()
        {
            return View();

        }

        public ActionResult Search(string searchTerm)
        {
            var apartments = data.Apartments.List(new QueryOptions<Apartment>
            {
                Include = "TaggedApartment.Tag, ApartmentAlbum.Picture,City,Owner,Status,ApartmentProfilePicture",
                Where = b => (b.NameEng + b.Name + b.ShortDescription).Contains(searchTerm),
                OrderBy = a => a.ApartmentId
            }).ToList(); 
            
            return PartialView("SearchResultsView", apartments);
        }

        [HttpPost]
        public ActionResult PostReview(int apartmentId, string review)
        {
            // get user id
            string currentUserId = null;
            var claimsIdentity = User.Identity as ClaimsIdentity;
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim != null) currentUserId = userIdClaim.Value;
            }

            if (!string.IsNullOrWhiteSpace(currentUserId))
            {
                data.ApartmentReviews.Insert(new ApartmentReview
                {
                    ApartmentId = apartmentId,
                    UserId = currentUserId,
                    ReviewText = review,
                    ReviewTime = DateTime.Now
                });
                data.ApartmentReviews.Save();

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

    }
}
