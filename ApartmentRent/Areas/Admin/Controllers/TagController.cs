using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApartmentRent.Models;
namespace ApartmentRent.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TagController : Controller
    {
        private ApartmentUnitOfWork data { get; set; }
        public TagController(DatabaseContext ctx) => data = new ApartmentUnitOfWork(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();
            var vm = new TagViewModel();

            vm.Tags = data.Tags.List(new QueryOptions<Tag>
            {
                Include = "Type",
                OrderBy = t => t.Name
            });
            return View(vm);
        }

        [HttpGet]
        public ViewResult Add(int id) => GetTag(id, "Add");

        private ViewResult GetTag(int id, string operation)
        {
            var tag = new TagViewModel();
            Load(tag, operation, id);
            return View("Tag", tag);
        }

        private void Load(TagViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Tag = new Tag();
            }
            else
            {
                vm.Tag = data.Tags.Get(new QueryOptions<Tag>
                {
                    Include = "Type",
                    Where = a => a.TagId == (id ?? vm.Tag.TagId)
                });
            }



            vm.TagType = data.TagTypes.List(new QueryOptions<TagType>
            {
                OrderBy = t => t.TypeId
            });

        }

        [HttpPost]
        public IActionResult Add(TagViewModel vm)
        {

            //var validate = new Validate(TempData);
            //if (!validate.IsTagChecked)
            //{
            //    validate.CheckTag(vm.Tag.Name, data.Tags);
            //    if (!validate.IsValid)
            //    {
            //        ModelState.AddModelError(nameof(vm.Tag.Name), validate.ErrorMessage);
            //    }
            //}

            //if (ModelState.IsValid)
            //{
            //    data.Tags.Insert(vm.Tag);
            //    data.Save();
            //    validate.ClearTag();
            //    TempData["message"] = $"{vm.Tag.Name} added to Tags.";
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    Load(vm, "Add");
            //    return View("Tag", vm);
            //
            if (ModelState.IsValid)
            {

                data.Tags.Insert(vm.Tag);
                data.Save();

                TempData["message"] = $"{vm.Tag.Name} added to Tags.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Book", vm);
            }
        }
        [HttpGet]
        public ViewResult Edit(int id) => GetTag(id, "Edit");

        [HttpPost]
        public IActionResult Edit(TagViewModel vm)
        {

            if (ModelState.IsValid)
            {

                data.Tags.Update(vm.Tag);
                data.Save();
                TempData["message"] = $"{vm.Tag.Name} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Edit");
                return View("Tag", vm);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tag = data.Tags.Get(new QueryOptions<Tag>
            {
                Include = "TaggedApartment",
                Where = t => t.TagId == id
            });

            if (tag.TaggedApartment.Count > 0)
            {
                TempData["message"] = $"Can't delete genre {tag.Name} "
                                    + "because it's associated with these apartments.";
                return GoToApartmentSearchResults(tag.Name);
            }
            else
            {
                return GetTag(id, "Delete");
            }
        }

        [HttpPost]
        public IActionResult Delete(TagViewModel vm)
        {
            data.Tags.Delete(vm.Tag);
            data.Save();
            TempData["message"] = $"{vm.Tag.Name} removed from Tags.";
            return RedirectToAction("Index");
        }



        private RedirectToActionResult GoToApartmentSearchResults(string name)
        {
            var search = new SearchData(TempData)
            {
                SearchTerm = name,
                Type = "tag"
            };
            return RedirectToAction("Search", "Apartment");
        }
    }
}




