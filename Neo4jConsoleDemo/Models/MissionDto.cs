namespace Neo4jConsoleDemo.Models;

public sealed record MissionDto
    (
        string Personne,
        string Client,
        string Role,
        DateOnly DateDebut,
        DateOnly? DateFin
    );
