namespace DamnSmallMapper.Test.Entities;

public class Person
{
	public string FirstName { get; set; }
	public string Lastname { get; set; }
	public int Age { get; set; }
	public DateTime RegisteredAt { get; set; }
	[DoNotMap]
	public string IgnoredInPerson { get; set; }
	public string IgnoredInClient { get; set; }
}