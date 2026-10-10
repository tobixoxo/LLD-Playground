public class Product
{
    public Guid ProductId {get;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    public int Quantity {get; set;}
    public Product (string name, decimal price, int quantity)
    {
        ProductId = Guid.NewGuid();
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}