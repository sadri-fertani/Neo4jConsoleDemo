using System.Reflection;

namespace Neo4jConsoleDemo.Infrastructure;

public static class CypherQueryLoader
{
    private static readonly Assembly Assembly = typeof(CypherQueryLoader).Assembly;

    public static string Load(string fileName)
    {
        var resourceName = Assembly
            .GetManifestResourceNames()
            .SingleOrDefault(n => n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase))
            ?? throw new FileNotFoundException($"Ressource Cypher introuvable : {fileName}.");

        using var stream = Assembly.GetManifestResourceStream(resourceName)!;
        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}
