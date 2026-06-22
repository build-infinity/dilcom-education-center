using DilcomEducationCenter.Application.Abstractions;
using DilcomEducationCenter.Application.DTOs;


namespace DilcomEducationCenter.Application.Services;

public sealed class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task CreateUser(CreateUserRequest createUserRequestDto)
    {
        
    }
}