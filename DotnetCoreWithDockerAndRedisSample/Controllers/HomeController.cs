using DotnetCoreWithDockerAndRedisSample.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DotnetCoreWithDockerAndRedisSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        public IActionResult Index()
        {
            const string cacheKey = "SampleProduct";

            ProductVm productVm = new ProductVm();

            var productCacheValue = _distributedCache.GetString(cacheKey);

            if (productCacheValue!=null)
            {
                var productItem = JsonConvert.DeserializeObject<ProductInputModel>(productCacheValue);

                productVm.ProductList.Add(productItem);
            }

            return View(productVm);
        }
    }
}
