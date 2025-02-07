namespace Domain.Entities{
    public class User{
        public int UserId {get; set;}
        public string Username{get; set;}
        public string PasswordHash{get; set;}
        public string Email{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public DateTime CreatedAt{get; set;}
        public DateTime UpdatedAt{get; set;}
        public string Role{get; set;}

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ShoppingCart ShoppingCart { get; set; } // Navigation property
    }
}