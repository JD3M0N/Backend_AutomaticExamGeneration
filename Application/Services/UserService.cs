using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddUserAsync(string name, string lastName, string email, string password, string rol)
    {
        var user = new User
        {
            Name = name,
            LastName = lastName,
            Email = email,
            Password = password,
            Rol = rol
        };

        await _userRepository.AddUserAsync(user);
        return user;
    }
}
