namespace DamnSmallMapper
{
	public static class Mapper
	{
		public static object MapFrom(this object target, object source, IMapProfile mapProfile) =>
			mapProfile.Map(source, target);

		public static object MapFrom(this object target, object source) =>
			new BasicMapProfile().Map(source, target);

		public static object MapFrom(this object target, object source, params string[] ignoredProps) =>
			new BasicMapProfile().IgnoreProps(ignoredProps).Map(source, target);
	}
}
