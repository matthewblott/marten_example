using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using marten_example.data;

namespace marten_example.console
{
  public class Application : IApplication
  {
    string connectionString = string.Empty;

    public Application(IConfigurationRoot configuration)
    {
      this.connectionString = configuration.GetConnectionString("default");
    }

    public void Run()
    {
      var demo = new Demo(this.connectionString);
      
          // static void Main(string[] args)
    // {
    //   var connStr = "";

    //   var demo = new Demo(connStr);

    //   var groups = new List<Group>
    //   {
    //     // new Group { Name = "admins" },
    //     // new Group { Name = "superusers" },
    //   };

    //   var group1 = new Group { Name = "admins" };
    //   var group2 = new Group { Name = "superusers" };

    //   group1.Id = demo.CreateGroup(group1);
    //   group2.Id = demo.CreateGroup(group2);

    //   groups.Add(group1);
    //   groups.Add(group2);

    //   var users = new List<User>
    //   {
    //     new User
    //     {
    //       FirstName = "Harrison",
    //       LastName = "Ford",
    //       Groups = groups.AsEnumerable()
    //     },
    //     new User
    //     {
    //       FirstName = "Gina",
    //       LastName = "Carano",
    //       Groups = groups.AsEnumerable()
    //     },
    //     new User
    //     {
    //       FirstName = "Michael",
    //       LastName = "Fassbander"
    //     },
    //   };

    //   //var user1 = from _ in users where _.FirstName == "Harrison" select _;
    //   var user2 = from _ in users where _.FirstName == "Gina" select _;
    //   demo.CreateUser(user2.Single());
    //   // demo.CreateUsers(users);

    //   // var audit = new Audit { CreatedAt = DateTime.Now, CreatedBy = "admin", UpdatedAt = DateTime.Now, UpdatedBy = "admin" };
    //   // var user = new User { FirstName = "Elizabeth", LastName = "Taylor", Audit = audit };
    //   // user.Id = demo.CreateUser(user);

    //   // user.Id = 4001;
    //   // demo.DisplayUserDetails(demo.FindUser(user.Id));

    //   // user.FirstName = "Gary";
    //   // user.Active = true;
    //   // demo.UpdateUser(user);

    //   // demo.DisplayUserDetails(demo.FindUser(11001));

    //   // demo.DeleteUser(1001);

    //   Console.WriteLine("Completed");

    // }



    }

  }

}