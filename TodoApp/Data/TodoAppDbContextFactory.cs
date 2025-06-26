using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoApp.Data;

public class TodoAppDbContextFactory : IDesignTimeDbContextFactory<TodoAppDbContext>
{
    public TodoAppDbContext CreateDbContext(string[] args)
    {
        TodoAppEfCoreEntityExtensionMappings.Configure();
        
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TodoAppDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new TodoAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
