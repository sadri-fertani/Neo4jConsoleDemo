using Neo4jConsoleDemo.Models;

namespace Neo4jConsoleDemo.Infrastructure.MissionRepositories;

public interface IMissionRepository
{
    Task<IReadOnlyList<MissionDto>> GetByPersonneAsync(string nomPersonne, CancellationToken ct = default);

    Task<IReadOnlyList<MissionDto>> GetAllAsync(CancellationToken ct = default);
}