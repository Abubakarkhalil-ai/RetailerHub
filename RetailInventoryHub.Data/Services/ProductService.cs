using RetailInventoryHub.Entities;

namespace RetailInventoryHub.Services;

public class ProductService
{
    private readonly List<Product> _products = new();

    public void Add(Product p) => _products.Add(p);

    public void Update(Product p)
    {
        var existing = _products.FirstOrDefault(x => x.ProductId == p.ProductId);
        if (existing == null) return;

        existing.Title = p.Title;
        existing.Price = p.Price;
        existing.QuantityInStock = p.QuantityInStock;
    }

    public void Delete(int id)
    {
        var p = _products.FirstOrDefault(x => x.ProductId == id);
        if (p != null)
            _products.Remove(p);
    }

    public Product? LinearSearchByName(string name)
    {
        foreach (var p in _products)
            if (p.Title.Equals(name, StringComparison.OrdinalIgnoreCase))
                return p;

        return null;
    }

    public Product? BinarySearchByBarcode(string barcode)
    {
        var list = _products.OrderBy(x => x.Barcode).ToList();

        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            int result = string.Compare(
                list[mid].Barcode,
                barcode,
                StringComparison.OrdinalIgnoreCase);

            if (result == 0)
                return list[mid];

            if (result < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }
}
