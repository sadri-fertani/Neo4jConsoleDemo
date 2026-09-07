using Neo4j.Driver;

namespace Neo4jConsoleDemo.Infrastructure;

public sealed class Neo4jConnection(string uri, string user, string password) : IAsyncDisposable
{
    private readonly IDriver _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));

    public IAsyncSession GetSession() => _driver.AsyncSession();

    public async ValueTask DisposeAsync()
    {
        await _driver.DisposeAsync();
    }
}
