using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.Shared;

public static class Constants
{
    public static SqlTemplate ReadSql => """
        SELECT * FROM Users WHERE Id = @Id
    """;
    
    public static SqlTemplate CreateSql => """
         INSERT INTO Users (Name, Role)
         VALUES (@Name, @Role)
     """;
}