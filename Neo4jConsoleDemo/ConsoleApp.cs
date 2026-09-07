using Neo4jConsoleDemo.Infrastructure.MissionRepositories;

namespace Neo4jConsoleDemo;

public class ConsoleApp(IMissionRepository missionRepository)
{
    public async Task ExecuterAsync()
    {
        var result = await missionRepository.GetAllAsync();

        foreach (var m in result)
        {
            var fin = m.DateFin?.ToString("yyyy-MM-dd") ?? "en cours";
            Console.WriteLine($"{m.Personne,-20} | {m.Client,-18} | {m.Role,-20} | {m.DateDebut:yyyy-MM-dd} → {fin}");
        }
    }
}
