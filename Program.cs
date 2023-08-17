using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.Function.Business;
using My.Function.Data;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase("TodoDb"));
        services.AddScoped<ITodoRepository, TodoRepository>();
    })
    .Build();

await host.RunAsync();
