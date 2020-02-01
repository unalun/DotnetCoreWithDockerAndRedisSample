

using System.Collections.Generic;

namespace DotnetCoreWithDockerAndRedisSample.Models.ViewModel
{

    public class ProductVm
    {
        public ProductVm()
        {
            ProductList = new List<ProductInputModel>();
        }

       public List<ProductInputModel> ProductList { get; set; }
    }

    public class ProductInputModel
    {
        public string  Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
