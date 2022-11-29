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
    }
}
