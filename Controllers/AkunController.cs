using go_blogs.Data;
using go_blogs.Models;
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

        private readonly AppDbContext _context;

        public AkunController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User datanya)
        {
            var deklarRole = _context.Tb_Roles.Where(x => x.Id == "1").FirstOrDefault();

            datanya.Roles = deklarRole;

            _context.Add(datanya); // insert to tb_user
            _context.SaveChanges(); // eksekusi

            //return RedirectToAction(controllerName:"Akun",actionName:"Masuk");
            return RedirectToAction("Masuk");
            //return Redirect("Masuk");
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {
            //var cari = _context.Tb_User.Where(  // proses pencarian
            //                                bebas =>
            //                                bebas.Username == datanya.Username
            //                                &&
            //                                bebas.Password == datanya.Password
            //).FirstOrDefault(); // hanya dapat 1 data

            var cariusername = _context.Tb_User.Where(  // proses pencarian username
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            ).FirstOrDefault();

            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(  // proses pengecekan username & pass
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            &&
                                            bebas.Password == datanya.Password
                                            )
                                    .Include(bebas2 => bebas2.Roles)
                                    .FirstOrDefault();

                if(cekpassword != null)
                {
                    // proses tampungan data
                    var daftar = new List<Claim>
                    {
                        new Claim("Username", cariusername.Username),
                        new Claim("Role", cariusername.Roles.Id)
                    };

                    // proses daftar auth
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                            )
                        );

                    if(cariusername.Roles.Id == "1")
                    {
                        return Redirect("/Admin/Home");
                    }else if(cariusername.Roles.Id == "2")
                    {
                        return Redirect("/User/Home");
                    }
                    
                    return RedirectToAction(controllerName: "Home", actionName: "Privacy");
                }

                ViewBag.pesan = "passwordnya salah loh";
                
                return View(datanya);
            }

            ViewBag.pesan = "username anda tidak ada";

            return View(datanya);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}