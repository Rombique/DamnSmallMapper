namespace DamnSmallMapper.Test.Entities;

public class Client
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
	public DateTime RegisteredAt { get; set; }
	[DoNotMap]
	public string IgnoredInClient { get; set; }
	public string IgnoredInPerson { get; set; }
}