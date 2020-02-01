using DotnetCoreWithDockerAndRedisSample.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DotnetCoreWithDockerAndRedisSample.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public DashboardController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductInputModel item)
        {
            if (ModelState.IsValid)
            {
                var data = JsonConvert.SerializeObject(item);
                _distributedCache.SetString("SampleProduct", data);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}