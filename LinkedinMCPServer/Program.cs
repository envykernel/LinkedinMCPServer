using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using System.Net.Http.Headers;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

builder.Services.AddSingleton(_ =>
{
    var client = new HttpClient() { BaseAddress = new Uri("https://linkedin-data-api.p.rapidapi.com") };
    client.DefaultRequestHeaders.Add("x-rapidapi-host", "linkedin-data-api.p.rapidapi.com");
    client.DefaultRequestHeaders.Add("x-rapidapi-key", "200b95a8c9msh36250aa73bd746ap13a2c7jsne8a99d2a6d78");
    
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("linkedin-tool", "1.0"));
    return client;
});

var app = builder.Build();

await app.RunAsync();