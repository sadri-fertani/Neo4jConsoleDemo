namespace Neo4jConsoleDemo.Options;

public sealed record Neo4jOptions
{
    public required string Uri { get; init; } 
    public required string User { get; init; }
    public required string Password { get; init; }
}
