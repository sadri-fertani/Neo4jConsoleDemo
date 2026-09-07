namespace Neo4jConsoleDemo.Options;

public sealed record Neo4jOptions
{
    public required string Uri { get; set; } 
    public required string User { get; set; }
    public required string Password { get; set; }
}
