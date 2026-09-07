using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Neo4jConsoleDemo;
using Neo4jConsoleDemo.Infrastructure;
using Neo4jConsoleDemo.Infrastructure.MissionRepositories;
using Neo4jConsoleDemo.Options;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddTransient<ConsoleApp>();

builder.Services
    .AddSingleton(sp =>
    {
        var options = sp.GetRequiredService<IOptions<Neo4jOptions>>().Value;
        return new Neo4jConnection(options.Uri, options.User, options.Password);
    })
    .Configure<Neo4jOptions>(builder.Configuration.GetSection("Neo4j"));

builder.Services
    .AddSingleton<IMissionRepository, MissionRepository>();

using IHost host = builder.Build();

ConsoleApp app = host.Services.GetRequiredService<ConsoleApp>();

await app.ExecuterAsync();