namespace Domain.Entities{
public class Order{
    public int OrderId{get; set;}
    public DateTime OrderDate{get; set;}
    public double TotalAmount{get; set;}
    public string Status{get; set;}
    public DateTime CreatedAt{get; set;}
    public DateTime UpdatedAt{get; set;}
    public int UserID{get; set;}

    public virtual User User { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
}