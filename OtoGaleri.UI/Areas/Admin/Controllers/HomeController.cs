using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OtoGaleri.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Arac> araclarim = new List<Arac>();

            using (var httpClient = new HttpClient())
            {
                using (var cevap = await httpClient.GetAsync("https://localhost:44360/api/Arac/GetAraclar"))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    araclarim = JsonConvert.DeserializeObject<List<Arac>>(apiCevap);
                }
            }

            ViewBag.KullaniciSayisi = 15;
            ViewBag.AracSayisi = araclarim.Count;
            ViewBag.MagazaSayisi = 15;

            return View(araclarim);
        }

        [HttpGet]
        public IActionResult AracEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AracEkle(Arac arac)
        {
            arac.AktifMi = true;
            arac.EklenmeTarihi = DateTime.Now;
            arac.DegistirilmeTarihi = DateTime.Now;

            Arac kaydedilenArac = new Arac();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(arac), Encoding.UTF8, "application/json");


                using (var cevap = await httpClient.PostAsync("https://localhost:44360/api/Arac/CreateArac", content))
                {
                    string apiCevap = await cevap.Content.ReadAsStringAsync();
                    //arac = JsonConvert.DeserializeObject<Arac>(apiCevap);
                }
            }

            return RedirectToAction("Index"); // Return to Index after create process is done.
        }
    }
}
