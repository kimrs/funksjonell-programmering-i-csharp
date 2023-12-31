using System.Text.Json;
using FunksjonellProgrammering.Api;
using FunksjonellProgrammering.Api.CreateUser;
using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Tests;
using LaYumba.Functional;
using static LaYumba.Functional.F;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var options = new JsonSerializerOptions
        {
            Converters =
            {
                new PrimitiveConverter<Name, string>()
            }
        };
        
        var createUser = new User("Tony Stark", "SpaceExplorer");
        var createdUserSerialized = JsonSerializer.Serialize(createUser, options);
        var ceatedUSerDeserialized = JsonSerializer.Deserialize<User>(createdUserSerialized, options);
        
        Assert.Equals(createdUserSerialized, "{\"Name\":\"Tony Stark\",\"Role\":\"SpaceExplorer\"}");
    }
}