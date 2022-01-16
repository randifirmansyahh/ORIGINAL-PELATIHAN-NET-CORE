using go_blogs.Data;
using go_blogs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog parameter)
        {
            if (ModelState.IsValid)
            {
                //proses masukan ke database
                parameter.Id = parameter.CreateDate.Ticks.ToString("x"); // membuat id unix
                _context.Add(parameter);
                await _context.SaveChangesAsync();

                // asalnya url https://localhost:5001/Blog/Create
                // menjadi  https://localhost:5001/Home
                return Redirect("../Home");
            }
            return View(parameter);
        }
    }
}