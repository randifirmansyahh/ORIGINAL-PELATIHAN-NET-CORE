using go_blogs.Data;
using go_blogs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using go_blogs.Helper;

namespace go_blogs.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var banyakData = new BlogDashBoard();

            banyakData.blog = _context.Tb_Blog.Include(x => x.User).ToList();
      
            banyakData.user = _context.Tb_User.Include(x => x.Roles).ToList();

            return View(banyakData);
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
                parameter.Id = BuatPrimary.buatPrimary(); // ini dari helper

                string nama = User.GetUsername();

                parameter.User = _context.Tb_User.FirstOrDefault(x => x.Username == nama);

                _context.Add(parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        public async Task<IActionResult> Hapus(string id)
        {
            var cari = _context.Tb_Blog.Where(x => x.Id == id).FirstOrDefault();

            if (cari == null)
            {
                return NotFound();
            }

            _context.Tb_Blog.Remove(cari);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}