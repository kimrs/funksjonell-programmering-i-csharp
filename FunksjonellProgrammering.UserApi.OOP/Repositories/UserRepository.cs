using Dapper;
using FunksjonellProgrammering.Shared;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi.OOP.Repositories;

public interface IUserRepository
{
    User Read(UserId Id);
    void Create(User Id);
}

public class UserRepository
    : IUserRepository
{
    
    private readonly ConnectionString _connectionString;
    
    public UserRepository(ConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    public User Read(UserId id)
    {
        try
        {
            return _connectionString.Connect(c => c.Query(Constants.ReadSql, new { Id = (int) id })
                .Select(x => new User(x.Name, x.Role))
                .SingleOrDefault()
            );
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public void Create(User user)
    {
        try
        {
            _connectionString.Connect(c => c.Execute(Constants.CreateSql, user));
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
