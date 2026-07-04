using System.Collections.Generic;

namespace RetailInventoryHub.Data
{
    public class ProductLinearSearch
    {
        public Product Search(
            List<Product> products,
            string title)
        {
            foreach (var p in products)
            {
                if (p.Title == title)
                    return p;
            }

            return null;
        }
    }
}