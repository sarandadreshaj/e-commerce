using Application.DTOs;

namespace Application.Services.Interfaces{
    public interface IUserService{
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(int id,  UserDto userDto);
        Task<UserDto> DeleteUser(int id);
    }
}