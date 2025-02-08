namespace Domain.Entities{
    public class CartItem{
        public int CartItemId{get; set;}
        public int Quantity{get; set;}
        public int CardId{get; set;}
        public int ProductId{get; set;}

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Product Product { get; set; }
    }
}