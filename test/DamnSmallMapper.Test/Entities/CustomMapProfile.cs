namespace DamnSmallMapper.Test.Entities;

public class CustomMapProfile : BasicMapProfile
{
	protected override void DefineMapping(object source, object target)
	{
		IgnoreProp(nameof(Client.FirstName));
		base.DefineMapping(source, target);
	}
}