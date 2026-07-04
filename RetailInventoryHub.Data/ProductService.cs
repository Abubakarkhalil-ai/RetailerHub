using System.Collections.Generic;
using System.Linq;

namespace RetailInventoryHub.Data
{
    public class ProductService
    {
        private List<Product> products =
            new List<Product>();

        public void Add(Product p)
        {
            products.Add(p);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products
                .FirstOrDefault(
                    x => x.ProductId == id);
        }

        public void Update(Product p)
        {
            Product old =
                GetById(p.ProductId);

            if (old == null)
                return;

            old.Barcode =
                p.Barcode;

            old.Title =
                p.Title;

            old.Price =
                p.Price;

            old.QuantityInStock =
                p.QuantityInStock;
        }

        public void Delete(int id)
        {
            Product p =
                GetById(id);

            if (p != null)
                products.Remove(p);
        }
    }
}