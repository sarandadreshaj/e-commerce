using System.ComponentModel;
using Application.CustomExceptions;
using Application.DTOs;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services{
    public class UserService{

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper){
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);

        }

        public async Task<UserDto> GetUserById(int id){
            var user = await _userRepository.GetByIdAsync(id);
             if (user == null){
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(int id, CreateUserDto userDto){
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null){
                throw new NotFoundException("Category not found");
            }
            _mapper.Map(userDto, existingUser);
            _userRepository.Update(existingUser);

        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if(existingUser == null){
                throw new NotFoundException("User not found!");
            }
            _userRepository.Delete(existingUser);
        }

    }
}