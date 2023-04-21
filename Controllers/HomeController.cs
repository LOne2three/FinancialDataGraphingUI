using FinancialDataApp;
using FinancialDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FinancialDataWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDataProcessor<Root> _dataProcessor;

        public HomeController(IDataProcessor<Root> dataProcessor)
        {
            _dataProcessor = dataProcessor;

        }

        public async Task<IActionResult> Index()
           
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Monthly", Value = "1month" });
            items.Add(new SelectListItem { Text = "Weekly", Value = "1week" });
            items.Add(new SelectListItem { Text = "Daily", Value = "1day" });
            ViewBag.Items = items;


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel viewModel)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Monthly", Value = "1month" });
            items.Add(new SelectListItem { Text = "Weekly", Value = "1week" });
            items.Add(new SelectListItem { Text = "Daily", Value = "1day" });
            ViewBag.Items = items;
            try
            {
                var response = await _dataProcessor.LoadData(viewModel.symbol,viewModel.interval);
                viewModel.root = response;
                return View(viewModel);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return View();
        }
        public ContentResult JSON(Root root)
		{
            List<Value> values = root.values;

			JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
			return Content(JsonConvert.SerializeObject(values, _jsonSetting), "application/json");
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