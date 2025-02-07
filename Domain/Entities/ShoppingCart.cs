namespace Domain.Entities{
public class ShoppingCart{
    public int ShoppingCartId{get; set;}
    public DateTime CreatedAt{get; set;}
    public DateTime UpdatedAt{get; set;}
    public int UserId{get; set;}

    public virtual User User { get; set; } // Navigation property
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
}