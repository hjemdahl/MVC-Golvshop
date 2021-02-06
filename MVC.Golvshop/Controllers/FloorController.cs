using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Golvshop.Models;
using Newtonsoft.Json;


namespace MVC.Golvshop.Controllers
{
    public class FloorController : Controller
    {
        [HttpGet("/hem")]
        public IActionResult Index()
        {
            //Viewmodel list of floors
            List<FloorModel> floors = new List<FloorModel>
            {
                new FloorModel("Gold", "images/light.jpg"),
                new FloorModel("Dark", "images/dark.jpg"),
                new FloorModel("Gray", "images/gray.jpg")
            };

            //Send list to View with Viewmodel
            ViewModel vm = new ViewModel
            {
                FloorList = floors
            };

            return View(vm);
        }

        [HttpGet("/bestallning")]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost("/bestallning")]
        public IActionResult Order(OrderModel model)
        {
            //Validation for int inputs in form
            if (model.Length >= 1 && model.Length <= 100 || model.Width >= 1 && model.Width <= 100)
            {
                model.Count(); //Calculates kvm and total price
            }
            else
            {
                return View();
            }

            //Validation for inputs in form for model
            if (ModelState.IsValid)
            {
                //Open JSON file, add new model
                var Json = System.IO.File.ReadAllText("orders.json");
                var JsonObj = JsonConvert.DeserializeObject<List<OrderModel>>(Json);
                JsonObj.Add(model);

                //Close JSON file
                System.IO.File.WriteAllText("orders.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                //Start session
                string s = JsonConvert.SerializeObject(model);
                HttpContext.Session.SetString("order-session", s);

                return RedirectToAction("Confirmation", "Floor");
            }

            return View();
        }

        [HttpGet("/bekraftelse")]
        public IActionResult Confirmation()
        {
            //Get session string and read it
            string s = HttpContext.Session.GetString("order-session");
            OrderModel model = JsonConvert.DeserializeObject<OrderModel>(s);

            //Planned deliverydate and sent to View with Viewdata
            DateTime OrderDate = DateTime.Today;
            String DeliveryDate = OrderDate.AddDays(5).ToString("dd/MM/yyyy");
            ViewData["DeliveryDate"] = DeliveryDate;

            return View(model);
        }

        [HttpGet("/admin")]
        public IActionResult Admin()
        {
            //Open JSON file and send to View with Viewbag
            var Json = System.IO.File.ReadAllText("orders.json");
            var JsonList = JsonConvert.DeserializeObject<IEnumerable<OrderModel>>(Json).Reverse();

            ViewBag.list = JsonList;

            return View();
        }
    }
}