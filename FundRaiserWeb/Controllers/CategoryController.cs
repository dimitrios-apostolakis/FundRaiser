﻿using FundRaiserWeb.Data;
using FundRaiserWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundRaiserWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {   //retrieve all records, convert to a list, assign to variable
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET ACTION METHOD
        public IActionResult Create()
        {
            return View();
        }

        //POST ACTION METHOD
        [HttpPost]
        [ValidateAntiForgeryToken]  //Prevent Cross Site Request Forgery Attack
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name."); //CustomError
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


		//GET ACTION METHOD
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categoryFromDb = _db.Categories.Find(id);
			//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
			//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}

		////POST ACTION METHOD
		//[HttpPost]
		//[ValidateAntiForgeryToken]  //Prevent Cross Site Request Forgery Attack
		//public IActionResult Edit(Category obj)
		//{
		//	if (obj.Name == obj.DisplayOrder.ToString())
		//	{
		//		ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name."); //CustomError
		//	}

		//	if (ModelState.IsValid)
		//	{
		//		_db.Categories.Add(obj);
		//		_db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	return View(obj);
		//}
	}
}
