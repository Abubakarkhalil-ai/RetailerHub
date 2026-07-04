using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetailInventoryHub.Data;

namespace RetailInventoryHub.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void Add_Product_Test()
        {
            ProductService service =
                new ProductService();

            Product p = new Product
            {
                ProductId = 1,
                Barcode = "111",
                Title = "Milk",
                Price = 10,
                QuantityInStock = 20
            };

            service.Add(p);

            Assert.AreEqual(
                1,
                service.GetAll().Count
            );
        }

        [TestMethod]
        public void Delete_Product_Test()
        {
            ProductService service =
                new ProductService();

            Product p = new Product
            {
                ProductId = 1,
                Barcode = "111",
                Title = "Milk",
                Price = 10,
                QuantityInStock = 20
            };

            service.Add(p);

            service.Delete(1);

            Assert.AreEqual(
                0,
                service.GetAll().Count
            );
        }

        [TestMethod]
        public void Linear_Search_Test()
        {
            ProductService service =
                new ProductService();

            Product p = new Product
            {
                ProductId = 1,
                Barcode = "111",
                Title = "Milk",
                Price = 10,
                QuantityInStock = 20
            };

            service.Add(p);

            ProductLinearSearch search =
                new ProductLinearSearch();

            Product result =
                search.Search(
                    service.GetAll(),
                    "1");

            Assert.IsNotNull(result);
        }
    }
}