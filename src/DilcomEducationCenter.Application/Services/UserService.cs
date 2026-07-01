using DilcomEducationCenter.Application.Abstractions;
using DilcomEducationCenter.Application.DTOs;
using DilcomEducationCenter.Application.Interfaces;
using DilcomEducationCenter.Domain.Common;
using DilcomEducationCenter.Domain.Entities;
using DilcomEducationCenter.Domain.Enums;
using DilcomEducationCenter.Domain.ValueObjects;

namespace DilcomEducationCenter.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest createUserRequest, string creatorRole,CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByName(createUserRequest.Role, cancellationToken);

        if(role is null)
            return Result<CreateUserResponse>.Failure(new Error("Role.NotFound", "Role does not exist", ErrorType.NotFound));
            
        if(!RoleAssignmentPolicy.CanAssign(creatorRole, createUserRequest.Role))
            return Result<CreateUserResponse>.Failure(new Error("Auth.Forbidden", "You are not allowed to assign this role", ErrorType.Forbidden ));  

        var emailResult = Email.Create(createUserRequest.Email);

        if(emailResult.IsFailure)
           return Result<CreateUserResponse>.Failure(emailResult.Error!);
        
        var phoneResult = PhoneNumber.Create(createUserRequest.Phone);

        if(phoneResult.IsFailure)
           return Result<CreateUserResponse>.Failure(phoneResult.Error!);
        
        var conflictResult = await _userRepository.FindConflictAsync(
            emailResult.Data!.Value, phoneResult.Data!.Value, createUserRequest.Login, cancellationToken);

        if(conflictResult.EmailExists)
           return Result<CreateUserResponse>.Failure(new Error("User.Email.Taken", "Email already in use", ErrorType.Conflict));
        if(conflictResult.PhoneExists)
           return Result<CreateUserResponse>.Failure(new Error("User.Phone.Taken", "Phone number already registered", ErrorType.Conflict));
        if(conflictResult.LoginExists)
           return Result<CreateUserResponse>.Failure(new Error("User.Login.Taken", "Login already taken", ErrorType.Conflict));

        // Password validator must be added  

        var passwordHash = _passwordHasher.Hash(createUserRequest.Password);

        var user = new User()
        {
           Id = Guid.NewGuid(),
           FirstName = createUserRequest.FirstName,
           LastName  = createUserRequest.LastName,
           BirthDate = createUserRequest.BirthDate,
           Login = createUserRequest.Login,
           PasswordHash = passwordHash,
           Email = emailResult.Data!,
           Phone = phoneResult.Data!,
           Gender = createUserRequest.Gender,
           RoleId = role.Id,
           CreatedOn = DateTime.UtcNow,  
        };

        _userRepository.Add(user);
        await _unitOfWork.SaveChanges(cancellationToken);

        var response = new CreateUserResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate,
            Email = user.Email.Value,
            Phone = user.Phone.Value,
            Gender = user.Gender.ToString(),
            Role = role.Name
        };

        return Result<CreateUserResponse>.Success(response);              
    }
}
        