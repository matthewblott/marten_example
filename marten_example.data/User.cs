using System.Collections.Generic;

namespace marten_example.data
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool Active { get; set; }

    public Audit Audit;

    public IEnumerable<Group> Groups { get; set; }

  }

}