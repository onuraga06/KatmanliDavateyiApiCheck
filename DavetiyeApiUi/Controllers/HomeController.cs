using DavetiyeApiUi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DavetiyeApiUi.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            List<Davetiye> hList = new List<Davetiye>();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44369/api/Home");
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();//resultun content ıcergını oku
                    var davet = readTask.Result;//Sonuc dondu
                    hList = JsonConvert.DeserializeObject<List<Davetiye>>(davet);//

                }

            }
            return View(hList);
        }
        
        public IActionResult Details(int id)
        {
            Davetiye davet = new Davetiye();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44369/api/Home" + "/" + id);
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var davetOkunan = readTask.Result;
                    davet = JsonConvert.DeserializeObject<Davetiye>(davetOkunan);
                    return View(davet);
                }

            }
            return RedirectToAction("Index");
        }
        public IActionResult True()
        {
            List<Davetiye> hList = new List<Davetiye>();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44369/api/Home/Katilanlar");
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var davet = readTask.Result;
                    hList = JsonConvert.DeserializeObject<List<Davetiye>>(davet);

                }

            }
            return View(hList);

      
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Davetiye ent)
        {
            HttpClient client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(ent), Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://localhost:44369/api/Home", stringContent);
            result.Wait();
            if (result.IsCompletedSuccessfully)
            {
                return RedirectToAction("Index", "Home");
            }
            return NotFound("Ekleme Yapılamadı");
          
        }

        public IActionResult Edit(int id)
        {
            Davetiye hostel = new Davetiye();
            using (var client = new HttpClient())
            {
                var responseTalk = client.GetAsync("https://localhost:44369/api/Home" + "/" + id);
                responseTalk.Wait();
                var result = responseTalk.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var davetOkunan = readTask.Result;
                    hostel = JsonConvert.DeserializeObject<Davetiye>(davetOkunan);
                    return View(hostel);
                }

            }
            return View();

        }
        [HttpPost]
        public IActionResult Edit(Davetiye ent)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44369/api/");
            var stringContent = new StringContent(JsonConvert.SerializeObject(ent), Encoding.UTF8, "application/json");
            var result = client.PutAsync("Home", stringContent);
            result.Wait();
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
