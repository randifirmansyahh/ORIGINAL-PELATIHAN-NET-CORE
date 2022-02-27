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
using go_blogs.Services;

namespace go_blogs.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IService _service;
        public BlogController(IService s)
        {
            _service = s;
        }

        public IActionResult Index()
        {
            var banyakData = new BlogDashBoard(); // membuat kumpulan model

            banyakData.blog = _service.TampilSemuaData(); // semua blog
            banyakData.user = _service.TampilSemuaUser(); // semua user

            return View(banyakData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog parameter)
        {
            if (ModelState.IsValid)
            {
                _service.BuatBlog(parameter, User.GetUsername()); // dari helper, tanpa tampungan
                return RedirectToAction("Index");
            }
            return View(parameter); // ini kondisi else
        }

        public IActionResult Hapus(string id)
        {
            _service.HapusBlog(id);
            return RedirectToAction("Index");
        }

        public IActionResult Ubah(string id)
        {
            var cari = _service.TampilBlogById(id);
            return cari == null ? NotFound() : View(cari); // ini adalah if else yang singkat
        }

        [HttpPost]
        public IActionResult Ubah(Blog data)
        {
            if (ModelState.IsValid)
            {
                _service.UbahBlog(data);
                return RedirectToAction("Index");
            }
            return View(data); // ini kondisi else
        }

        public IActionResult Details(string id)
        {
            var data = _service.TampilBlogById(id);
            return View(data);
        }
    }
}