using Context;
using HuseyinBerkayTellı_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HuseyinBerkayTellı_MVC.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        Uri baseAddress = new Uri("https://localhost:7084/api");
        HttpClient client;

        public CityController(ApplicationDbContext applicationDbContext)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {

            List<CityViewModel> modelList = new List<CityViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/City/GetList").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<CityViewModel>>(data);
            }
            return View(modelList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CityViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/City/Create", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int id)
        {
            CityViewModel model = new CityViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/City/Update/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CityViewModel>(data);
            }
            return View("Update", model);
        }
        [HttpPost]
        public IActionResult Update(CityViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/City", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/City/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
