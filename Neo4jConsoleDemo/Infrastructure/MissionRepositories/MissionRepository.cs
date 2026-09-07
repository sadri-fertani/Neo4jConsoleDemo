using Neo4j.Driver;
using Neo4jConsoleDemo.Models;

namespace Neo4jConsoleDemo.Infrastructure.MissionRepositories;

public sealed class MissionRepository(Neo4jConnection connection) : IMissionRepository
{
    private static readonly string GetByPersonneCypher = CypherQueryLoader.Load("GetMissionsByPersonne.cypher");

    private static readonly string GetAllCypher = CypherQueryLoader.Load("GetAllMissions.cypher");

    public async Task<IReadOnlyList<MissionDto>> GetByPersonneAsync(string nomPersonne, CancellationToken ct = default)
    {
        return await RunQuery(GetByPersonneCypher, new { nomPersonne });
    }

    public async Task<IReadOnlyList<MissionDto>> GetAllAsync(CancellationToken ct = default)
    {
        return await RunQuery(GetAllCypher, new { });
    }

    private async Task<IReadOnlyList<MissionDto>> RunQuery(string cypher, object parameters)
    {
        await using var session = connection.GetSession();

        return await session.ExecuteReadAsync(async tx =>
        {
            var cursor = await tx.RunAsync(cypher, parameters);
            var results = new List<MissionDto>();

            await foreach (var record in cursor)
            {
                results.Add(MapToMission(record));
            }

            return results;
        });
    }

    private static MissionDto MapToMission(IRecord record)
    {
        return new MissionDto
            (
                Personne: record["personne"].As<string>(),
                Client: record["client"].As<string>(),
                Role: record["role"].As<string>(),
                DateDebut: record["date_debut"].As<LocalDate>().ToDateOnly(),
                DateFin: record["date_fin"]?.As<LocalDate>().ToDateOnly()
            );
    }
}