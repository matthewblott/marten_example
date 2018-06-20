using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using marten_example.data;

namespace marten_example.console
{
  class Program
  {
    static void Main(string[] args)
    {
      var services = Startup.ConfigureServices();
      var serviceProvider = services.BuildServiceProvider();
      var app = serviceProvider.GetService<IApplication>();

      app.Run();

    }

  }

}
