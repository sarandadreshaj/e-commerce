namespace Domain.Entities{
public class Review{
    public int ReviewID{get; set;}
    public byte Rating{get; set;}
    public string Comment{get; set;}
    public DateTime CreatedAt{get; set;}
    public int ProductID{get; set;}
    public int UserID{get; set;}

    public virtual Product Product { get; set; }
    public virtual User User { get; set; }
}
}