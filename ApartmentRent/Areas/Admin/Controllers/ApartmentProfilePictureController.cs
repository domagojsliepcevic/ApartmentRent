using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApartmentRent.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace ApartmentRent.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ApartmentProfilePictureController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DatabaseContext _context;

        public ApartmentProfilePictureController(DatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;

        }

        // GET: Admin/ApartmentProfilePicture
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApartmentProfilePicture.ToListAsync());
        }

        // GET: Admin/ApartmentProfilePicture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentProfilePicture = await _context.ApartmentProfilePicture
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (apartmentProfilePicture == null)
            {
                return NotFound();
            }

            return View(apartmentProfilePicture);
        }

        // GET: Admin/ApartmentProfilePicture/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ApartmentProfilePicture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ApartmentName,ImageFile")] ApartmentProfilePicture imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/images
                
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = imageModel.ApartmentName + "_" + fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/" + imageModel.ApartmentName + "/", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }


        // GET: Admin/ApartmentProfilePicture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentProfilePicture = await _context.ApartmentProfilePicture.FindAsync(id);
            if (apartmentProfilePicture == null)
            {
                return NotFound();
            }
            return View(apartmentProfilePicture);
        }

        // POST: Admin/ApartmentProfilePicture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Title,ApartmentName,ImageName")] ApartmentProfilePicture apartmentProfilePicture)
        {
            if (id != apartmentProfilePicture.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartmentProfilePicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentProfilePictureExists(apartmentProfilePicture.ImageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(apartmentProfilePicture);
        }

        // GET: Admin/ApartmentProfilePicture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentProfilePicture = await _context.ApartmentProfilePicture
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (apartmentProfilePicture == null)
            {
                return NotFound();
            }

            return View(apartmentProfilePicture);
        }

        // POST: Admin/ApartmentProfilePicture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartmentProfilePicture = await _context.ApartmentProfilePicture.FindAsync(id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath + "/images/" + apartmentProfilePicture.ApartmentName + "/", apartmentProfilePicture.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //delete the record
            _context.ApartmentProfilePicture.Remove(apartmentProfilePicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentProfilePictureExists(int id)
        {
            return _context.ApartmentProfilePicture.Any(e => e.ImageId == id);
        }
    }
}
