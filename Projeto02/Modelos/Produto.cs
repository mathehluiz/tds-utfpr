namespace Projeto02;

public class Product
{
    public int? ProductID { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public decimal? Price { get; set; }
    public string? Supplier { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) {
            return false;
        }

        Product products = (Product)obj;
        return products.ProductID.Equals(this.ProductID);
    }
}
