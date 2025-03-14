using AutoMapper;
using Domain.Entities; // Make sure to include the namespace where your entities are defined
using Application.DTOs; // Make sure to include the namespace where your DTOs are defined

namespace Business.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, CreateProductDto>();
            CreateMap<CreateProductDto, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();

            // Mapping for Order
            // CreateMap<Order, OrderDto>();
            // CreateMap<OrderDto, Order>();
            // CreateMap<Order, CreateOrderDto>();
            // CreateMap<CreateOrderDto, Order>();

            // // Mapping for OrderItem
            // CreateMap<OrderItem, OrderItemDto>();
            // CreateMap<OrderItemDto, OrderItem>();
            // CreateMap<OrderItem, CreateOrderItemDto>();
            // CreateMap<CreateOrderItemDto, OrderItem>();

            // // Mapping for Review
            // CreateMap<Review, ReviewDto>();
            // CreateMap<ReviewDto, Review>();
            // CreateMap<Review, CreateReviewDto>();
            // CreateMap<CreateReviewDto, Review>();

            // // Mapping for ShoppingCart
            // CreateMap<ShoppingCart, ShoppingCartDto>();
            // CreateMap<ShoppingCartDto, ShoppingCart>();
            // CreateMap<ShoppingCart, CreateShoppingCartDto>();
            // CreateMap<CreateShoppingCartDto, ShoppingCart>();

            // // Mapping for CartItem
            // CreateMap<CartItem, CartItemDto>();
            // CreateMap<CartItemDto, CartItem>();
            // CreateMap<CartItem, CreateCartItemDto>();
            // CreateMap<CreateCartItemDto, CartItem>();
        }
    }
}
