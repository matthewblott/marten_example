using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace marten_example.console
{
  public static class Startup
  {
    public static IServiceCollection ConfigureServices()
    {
      var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true);
        
      configuration.AddUserSecrets<Program>();
      
      var config2 = configuration.Build();

      var connStr = config2.GetConnectionString("default");

      var services = new ServiceCollection();

      // services.AddSingleton<IConfigurationRoot>(config2);
      services.AddSingleton<IConfigurationRoot>(config2);
      services.AddTransient<IApplication, Application>();

      return services;

    }

  }

}