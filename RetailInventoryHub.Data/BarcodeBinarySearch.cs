using System.Collections.Generic;
using System.Linq;

namespace RetailInventoryHub.Data
{
    public class BarcodeBinarySearch
    {
        public Product Search(
            List<Product> products,
            string barcode)
        {
            products =
                products
                .OrderBy(
                    x => x.Barcode)
                .ToList();

            int left = 0;
            int right =
                products.Count - 1;

            while (left <= right)
            {
                int mid =
                    (left + right) / 2;

                if (products[mid]
                    .Barcode == barcode)
                    return products[mid];

                if (string.Compare(
                    products[mid].Barcode,
                    barcode) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }
    }
}