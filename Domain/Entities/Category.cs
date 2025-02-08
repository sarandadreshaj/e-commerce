namespace Domain.Entities{
public class Category{
    public int CategoryId{get; set;}
    public String Name{get; set;}
    public String Description{get; set;}
     public DateTime CreatedAt{get; set;}
    public DateTime UpdatedAt{get; set;}

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
}