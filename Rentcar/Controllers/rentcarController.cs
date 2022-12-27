using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rentcar.data;
using Rentcar.Models;

namespace Rentcar.Controllers
{
    [Authorize]
	public class rentcarController : Controller

	{
		public readonly ApplicationDbContext _db;

		public rentcarController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<rentcar> objrentcarList = _db.rentcars;
			return View(objrentcarList);
		}
        //GET
        public IActionResult Create()
        {
        
            return View();
        }

      
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(rentcar obj)
        {
            if (obj.Model == obj.Year.ToString())
            {
                ModelState.AddModelError("CustomError", "The year cannot exactly match the Model.");
            }
            if (ModelState.IsValid)
            {
                _db.rentcars.Add(obj);
                TempData["success"] = "rentcar created successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rentcarFromDb = _db.rentcars.Find(id);
         

            if (rentcarFromDb == null)
            {
                return NotFound();
            }
            return View(rentcarFromDb);

        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(rentcar obj)
        {
            if (obj.Model == obj.Price.ToString())
            {
                ModelState.AddModelError("CustomError", "The Price cannot exactly match the Model.");
            }
            if (ModelState.IsValid)
            {
                _db.rentcars.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "rentcar updated successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rentcarFromDb = _db.rentcars.Find(id);
            

            if (rentcarFromDb == null)
            {
                return NotFound();
            }
            return View(rentcarFromDb);

        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.rentcars.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.rentcars.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "rentcar removed successfully";
            return RedirectToAction("Index");
        }
    }
}

