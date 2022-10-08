using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApartmentRent.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ApartmentRent.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ApartmentPictureController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DatabaseContext _context;

        public ApartmentPictureController(DatabaseContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;

        }

        // GET: ApartmentPicture
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApartmentPicture.ToListAsync());
        }

        // GET: ApartmentPicture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentPicture = await _context.ApartmentPicture
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (apartmentPicture == null)
            {
                return NotFound();
            }

            return View(apartmentPicture);
        }

        // GET: ApartmentPicture/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApartmentPicture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ApartmentName,ImageFile")] ApartmentPicture imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/images
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = imageModel.ApartmentName+"_"+fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/" + imageModel.ApartmentName+"/", fileName);
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

        // GET: ApartmentPicture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentPicture = await _context.ApartmentPicture.FindAsync(id);
            if (apartmentPicture == null)
            {
                return NotFound();
            }
            return View(apartmentPicture);
        }

        // POST: ApartmentPicture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Title,ImageName")] ApartmentPicture apartmentPicture)
        {
            if (id != apartmentPicture.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartmentPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentPictureExists(apartmentPicture.ImageId))
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
            return View(apartmentPicture);
        }

        // GET: ApartmentPicture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentPicture = await _context.ApartmentPicture
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (apartmentPicture == null)
            {
                return NotFound();
            }

            return View(apartmentPicture);
        }

        // POST: ApartmentPicture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartmentPicture = await _context.ApartmentPicture.FindAsync(id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath + "/images/" + apartmentPicture.ApartmentName + "/", apartmentPicture.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //delete the record
            _context.ApartmentPicture.Remove(apartmentPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentPictureExists(int id)
        {
            return _context.ApartmentPicture.Any(e => e.ImageId == id);
        }
    }
}
