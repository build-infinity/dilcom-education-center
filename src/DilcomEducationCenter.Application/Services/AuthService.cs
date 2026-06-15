using DilcomEducationCenter.Application.Abstractions;
using DilcomEducationCenter.Application.DTOs;
using DilcomEducationCenter.Application.Errors;
using DilcomEducationCenter.Domain.Common;

namespace DilcomEducationCenter.Application.Services;

public sealed class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenProvider _tokenProvider;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenProvider = tokenProvider;
    }
    public async Task<Result<LoginResponseDto>> Login(LoginRequestDto loginRequestDto)
    {
        var user = await _userRepository.GetByLogin(loginRequestDto.Login); 

        if(user is null) 
           return Result<LoginResponseDto>.Failure(AuthError.InvalidCredentials);
        
        if(!_passwordHasher.Verify(loginRequestDto.Password, user.PasswordHash))
           return Result<LoginResponseDto>.Failure(AuthError.InvalidCredentials);

        var token = _tokenProvider.GenerateAccessToken(user);

        return Result<LoginResponseDto>.Success( new LoginResponseDto(token)); 
    }
}