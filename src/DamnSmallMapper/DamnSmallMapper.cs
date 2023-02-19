using System;

namespace DamnSmallMapper
{
	public static class DamnSmallMapper
	{
		public static object MapFrom(this object target, object source, IMapProfile mapProfile) =>
			mapProfile.Map(source, target);

		public static object MapFrom(this object target, object source) =>
			new BasicMapProfile().Map(source, target);

		public static object MapFrom(this object target, object source, params string[] ignoredProps) =>
			new BasicMapProfile().IgnoreProps(ignoredProps).Map(source, target);

		public static Target? Map<Target>(object source, IMapProfile mapProfile)
			where Target : class
		{
			var target = Activator.CreateInstance<Target>();
			return mapProfile.Map(source, target!) as Target;
		}

		public static Target? Map<Target>(object source, params string[] ignoredProps) 
			where Target : class
		{
			var profile = new BasicMapProfile().IgnoreProps(ignoredProps);
			return Map<Target>(source, profile);
		}

		public static Target? Map<Target>(object source)
			where Target : class
		{
			var profile = new BasicMapProfile();
			return Map<Target>(source, profile);
		}
	}
}
