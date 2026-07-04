namespace RetailInventoryHub.Entities;
public class Product
{
    public int ProductId { get; set; }
    public string Barcode { get; set; } = "";
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int SupplierId { get; set; }
}
