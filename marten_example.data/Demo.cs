using System;
using System.Collections.Generic;
using System.Linq;
using Marten;

namespace marten_example.data
{
  public class Demo
  {
    IDocumentStore store;
    string connectionString;
    public Demo(string connectionString)
    {
      this.connectionString = connectionString;
      this.store = DocumentStore.For(_ =>
      {
        _.Connection(connectionString);
        _.Schema.Include<MyMartenRegistry>();
        //_.Schema.For<User>().SoftDeleted();
      });

    }

    public void CreateUsers(IEnumerable<User> users)
    {
      // this.store.BulkInsertDocuments(users);

      using (var session = this.store.LightweightSession())
      {
        foreach (var user in users)
        {
          session.Store(user);
        }

        session.SaveChanges();

      }

    }

    public int CreateUser(User user)
    {
      using (var session = this.store.LightweightSession())
      {
        session.Store(user);
        session.SaveChanges();

        return user.Id;

      }

    }

    public int CreateGroup(Group group)
    {
      using (var session = this.store.LightweightSession())
      {
        session.Store(group);
        session.SaveChanges();

        return group.Id;

      }

    }

    public void UpdateUser(User user)
    {
      using (var session = this.store.LightweightSession())
      {
        session.Store(user);
        session.SaveChanges();
      }

    }

    public User FindUser(int id)
    {
      using (var session = this.store.OpenSession())
      {
        var user = session
          .Query<User>()
          .Where(x => x.Id == id)
          .Single();

        var data = this.store.Tenancy.Default.MetadataFor(user);

        return user;
      }

    }

    public void DeleteUser(int id)
    {
      using (var session = this.store.LightweightSession())
      {
        session.DeleteWhere<User>(_ => _.Id == id);
        session.SaveChanges();
      }

    }

    public void DisplayUserDetails(User user)
    {
      var message = $"{user.Id} : {user.FirstName} {user.LastName} {user.Active}";

      Console.WriteLine(message);

    }

  }

}
