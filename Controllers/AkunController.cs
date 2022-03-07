using go_blogs.Data;
using go_blogs.Helper;
using go_blogs.Models;
using go_blogs.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace go_blogs.Controllers
{
    public class AkunController : Controller
    {

        private readonly IService _service;
        private readonly EmailService _email;

        public AkunController(IService s, EmailService e)
        {
            _service = s;
            _email = e;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User datanya)
        {
            if (!ModelState.IsValid) return View(datanya);

            int OTP = BantuanUmum.BuatOTP(); // menggunakan static, jadi gausah di new

            // fungsi kirim email bisa di panggil di controller mana saja
            _email.KirimEmail(datanya.Email, "Konfirmasi daftar", "<h1 style='color:red'>ini </h1>" + OTP); // bisa pake html atau tidak

            datanya.Roles = _service.TampilRolesById("2"); // ngisi roles

            _service.BuatUser(datanya); // add user

            return RedirectToAction("Masuk");
            //return RedirectToAction(controllerName: "Akun", actionName: "Masuk"); // cara kedua
            //return Redirect("Masuk"); // cara ke tiga
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
            if (!ModelState.IsValid) return View(datanya);

            var tampungan = _service.TampilUserByUsername(datanya.Username);

            if (tampungan == null) // cek username
            {
                ViewBag.pesan = "username anda tidak ada";
                return View(datanya);
            }

            tampungan = _service.TampilUserByUsernameDanPassword(tampungan.Username, tampungan.Password);

            if (tampungan == null) // cek username & password
            {
                ViewBag.pesan = "passwordnya salah loh";
                return View(datanya);
            }

            // proses buat klaim
            var daftar = BantuanUmum.BuatKlaim(tampungan.Username, tampungan.Roles.Name);

            // proses daftar auth atau cookie pada browser
            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                )
            );

            // arahkan redirect nya
            if (tampungan.Roles.Name == "Admin") return Redirect("/Admin/Home");
            else if (tampungan.Roles.Name == "User") return Redirect("/User/Home");
            else return Redirect("/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}