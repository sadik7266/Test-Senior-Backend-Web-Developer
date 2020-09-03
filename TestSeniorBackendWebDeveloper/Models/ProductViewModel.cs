using System;
using TestSeniorBackendWebDeveloper.Helpers;

namespace TestSeniorBackendWebDeveloper.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public ProductTypes ProductType { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductBrand { get; set; }
        public string ProductTag { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductWeight { get; set; }
    }
}
