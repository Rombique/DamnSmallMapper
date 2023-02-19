namespace DamnSmallMapper.Test.Entities;

public class CustomMapProfile : BasicMapProfile
{
	protected override void DefineMapping(object source, object target)
	{
		base.DefineMapping(source, target);
		IgnoreProp(nameof(Client.FirstName));
	}
}