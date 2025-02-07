namespace Domain.Entities{
public class Product{
    public int ProductId{get; set;}
    public string Name{get; set;}
    public string Description{get; set;}
    public decimal Price{get; set;}
    public int StockQuantity{get; set;}
    public DateTime CreatedAt{get; set;}
    public DateTime UpdatedAt{get; set;}
    public int CategoryID{get; set;}

    public virtual Category Category { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
}