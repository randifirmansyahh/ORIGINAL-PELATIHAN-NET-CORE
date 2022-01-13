using go_blogs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go_blogs.Controllers
{
    public class MobilController : Controller
    {
        public IActionResult Index()
        {
            var mobils = new List<Mobil>();

            //IEnumerable<Mobil> mobils2 = new List<Mobil>();

            //List<Mobil> mobils3 = new List<Mobil>();

            //mobils.Add(new Mobil
            //{
            //    id = 1,
            //    Tipe = "Sedan",
            //    Merk = "Toyota",
            //    Varian = "Apple",
            //});

            //mobils.Add(new Mobil
            //{
            //    IDRegistrasi = 2,
            //    Tipe = "Bus",
            //    Merk = "Toyota",
            //    Varian = "Android",
            //});

            //string nama = "Randi";

            //ViewBag.namaSaya = nama;
            //ViewBag.mobils = mobils;

            //ViewData["nama"] = "Randiiii";

            var banyakMobil = new Mobil[]
            {
                new Mobil{id = 1, Tipe="Sedan",Merk="Toyota",Varian="FT86"},
                new Mobil{id = 2, Tipe="SUV",Merk="Toyota",Varian="RAV4"},
                new Mobil{id = 3, Tipe="Sedan",Merk="Honda",Varian="Accord"},
                new Mobil{id = 4, Tipe="SUV",Merk="Honda",Varian="CRV"},
                new Mobil{id = 5, Tipe="Sedan",Merk="Honda",Varian="City"},
            };

            var cariMobil = banyakMobil.Single(x => x.id == 1);

            var pertama = banyakMobil.Where(x => x.Tipe == "Sedan").FirstOrDefault();

            ViewBag.mobils = pertama;

            return View();
        }
    }
}
