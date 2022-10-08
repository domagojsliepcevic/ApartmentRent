using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApartmentRent.Models;

namespace ApartmentRent.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ApartmentController : Controller
    {

        private ApartmentUnitOfWork data { get; set; }

        public ApartmentController(DatabaseContext ctx) => data = new ApartmentUnitOfWork(ctx);


        public IActionResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData)
                {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Apartment>
                {
                    Include = "City,Owner,Status,TaggedApartment.Tag,ApartmentAlbum.Picture"
                };
                if (search.IsApartment)
                {
                    options.Where = a => a.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for apartment name '{vm.SearchTerm}'";
                }
                if (search.IsTag)
                {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1)
                    {
                        options.Where = a => a.TaggedApartment.Any(
                            ta => ta.Tag.Name.Contains(vm.SearchTerm) ||
                            ta.Tag.NameEng.Contains(vm.SearchTerm));
                    }
                    else
                    {
                        string first = vm.SearchTerm.Substring(0, index);
                        string last = vm.SearchTerm.Substring(index + 1);
                        options.Where = a => a.TaggedApartment.Any(
                            ta => ta.Tag.Name.Contains(first) &&
                            ta.Tag.NameEng.Contains(last));
                    }

                    vm.Header = $"Search results for tag '{vm.SearchTerm}'";
                }
                if (search.IsOwner)
                {
                    options.Where = o => o.Owner.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for owner '{vm.SearchTerm}'";
                }

                if (search.IsStatus)
                {
                    options.Where = s => s.Status.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for status '{vm.SearchTerm}'";
                }
                if (search.IsCity)
                {
                    options.Where = c => c.City.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for city  '{vm.SearchTerm}'";
                }

                vm.Apartments = data.Apartments.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }
    
        [HttpGet]
        public ViewResult Add(int id) => GetApartment(id, "Add");

        private ViewResult GetApartment(int id, string operation)
        {
            var apartment = new ApartmentViewModel();
            Load(apartment, operation, id);
            return View("Apartment", apartment);
        }

        [HttpPost]
        public IActionResult Add(ApartmentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.LoadNewApartmentAlbum(vm.Apartment, vm.SelectedPictures);
                data.LoadNewTaggedApartments(vm.Apartment, vm.SelectedTags);
                data.Apartments.Insert(vm.Apartment);
                data.Save();

                TempData["message"] = $"{vm.Apartment.Name} added to Apartments.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Apartment", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetApartment(id, "Edit");

        [HttpPost]
        public IActionResult Edit(ApartmentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.DeleteCurrentApartmentAlbum(vm.Apartment);
                data.DeleteCurrentTaggedApartments(vm.Apartment);
                data.LoadNewApartmentAlbum(vm.Apartment, vm.SelectedPictures);
                data.LoadNewTaggedApartments(vm.Apartment, vm.SelectedTags);
                data.Apartments.Update(vm.Apartment);
                data.Save();

                TempData["message"] = $"{vm.Apartment.Name} updated.";
                return RedirectToAction("Search");
            }
            else
            {
                Load(vm, "Edit");
                return View("Apartment", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetApartment(id, "Delete");

        [HttpPost]
        public IActionResult Delete(ApartmentViewModel vm)
        {
            data.Apartments.Delete(vm.Apartment);
            data.Save();
            TempData["message"] = $"{vm.Apartment.Name} removed from Apartments.";
            return RedirectToAction("Search");
        }

        private void Load(ApartmentViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Apartment = new Apartment();
            }
            else
            {
                vm.Apartment = data.Apartments.Get(new QueryOptions<Apartment>
                {
                    Include = "City,Owner,Status,TaggedApartment.Tag,ApartmentAlbum.Picture, ApartmentProfilePicture",
                    Where = a => a.ApartmentId == (id ?? vm.Apartment.ApartmentId)
                });
            }

            vm.SelectedTags = vm.Apartment.TaggedApartment?.Select(
               ta => ta.Tag.TagId).ToArray();

            vm.SelectedPictures = vm.Apartment.ApartmentAlbum?.Select(p => p.Picture.ImageId).ToArray();

            vm.Picture = data.ApartmentPictures.List(new QueryOptions<ApartmentPicture>
            {
                OrderBy = p => p.ApartmentName,
                
                
            });

            vm.Tags = data.Tags.List(new QueryOptions<Tag>
            {
                OrderBy = t => t.TypeId
            });

            vm.ApartmentProfilePictures = data.ApartmentProfilePicture.List(new QueryOptions<ApartmentProfilePicture>
            {
                OrderBy= app=>app.ApartmentName
            });

            vm.Cities = data.Cities.List(new QueryOptions<City>
            {
                OrderBy = c => c.Name
            });
            vm.Owners = data.ApartmentsOwner.List(new QueryOptions<ApartmentOwner>
            {
                OrderBy = o => o.Name
            });
            vm.Statuses = data.ApartmentStatuses.List(new QueryOptions<ApartmentStatus>
            {
                OrderBy = s => s.Name
            });
        }

    }
}

