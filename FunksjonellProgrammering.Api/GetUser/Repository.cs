﻿using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api.GetUser;

public interface IRepository
{
    IEnumerable<Domain> GetAll();
}

public class Repository
    : IRepository
{
    private static readonly SqlTemplate
        _selectSql = """SELECT * FROM Users""",
        _byIdSql = $"{_selectSql} WHERE Id = @Id";
    private readonly ConnectionString _connectionString;

    public Repository(IConfiguration configuration)
        => _connectionString = configuration.GetConnectionString("ApiDb");

    public IEnumerable<Domain> GetById(UserId id)
        => _connectionString.Retrieve<Entity>(_byIdSql)(id)
            .Select(x => x.ToDomain());

    public IEnumerable<Domain> GetAll()
        => _connectionString
            .Retrieve<Entity>(_selectSql)(null)
            .Select(x => x.ToDomain());
}