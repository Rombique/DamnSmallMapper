using DamnSmallMapper.Test.Entities;

namespace DamnSmallMapper.Test;

public class UnitTest1
{
	[Fact]
	public void MapWithSameProperties()
	{
		var client = new Client()
		{
			FirstName = "Sergey",
			LastName = "Bodrov",
			Age = 35,
			RegisteredAt = DateTime.Today,
			IgnoredInClient = "Ignored in Client",
			IgnoredInPerson = "Ignored in Person"
		};
		var person = new Person();
		person.MapFrom(client);
		Assert.Equal(client.FirstName, person.FirstName);
		Assert.Equal(client.LastName, person.Lastname);
		Assert.Equal(client.Age, person.Age);
		Assert.Equal(client.RegisteredAt, person.RegisteredAt);
		Assert.Null(person.IgnoredInClient);
		Assert.Null(person.IgnoredInPerson);
	}
	
	[Fact]
	public void MapWithIgnoredProps()
	{
		var client = new Client()
		{
			FirstName = "Sergey",
			LastName = "Bodrov",
			Age = 35
		};
		var person = new Person();
		person.MapFrom(client, nameof(client.Age));
		Assert.Equal(client.FirstName, person.FirstName);
		Assert.Equal(client.LastName, person.Lastname);
		Assert.Equal(0, person.Age);
	}
	
	[Fact]
	public void MapWithCustomMapProfile()
	{
		var customMapProfile = new CustomMapProfile();
		var client = new Client()
		{
			FirstName = "Sergey",
			LastName = "Bodrov",
			Age = 35
		};
		var person = new Person();
		person.MapFrom(client, customMapProfile);
		Assert.Null(person.FirstName);
		Assert.Equal(client.LastName, person.Lastname);
		Assert.Equal(client.Age, person.Age);
	}
	
	[Fact]
	public void MapUsingMethodMap()
	{
		var client = new Client()
		{
			FirstName = "Sergey",
			LastName = "Bodrov",
			Age = 35
		};
		var person = DamnSmallMapper.Map<Person>(client, nameof(Person.IgnoredInPerson));
		Assert.Equal(person.FirstName, client.FirstName);
		Assert.Equal(client.LastName, person.Lastname);
		Assert.Equal(client.Age, person.Age);
	}
}