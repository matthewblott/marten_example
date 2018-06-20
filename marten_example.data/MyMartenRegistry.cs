using Marten;

namespace marten_example.data
{
  public class MyMartenRegistry : MartenRegistry
  {
    public MyMartenRegistry()
    {
      //For<User>().Duplicate(x => x.FirstName);
      For<User>().SoftDeleted();
    }

  }

}