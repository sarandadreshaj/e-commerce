namespace Domain.Entities{
public class Review{
    public int ReviewId{get; set;}
    public byte Rating{get; set;}
    public string Comment{get; set;}
    public DateTime CreatedAt{get; set;}
    public int ProductId{get; set;}
    public int UserId{get; set;}

    public virtual Product Product { get; set; }
    public virtual User User { get; set; }
}
}