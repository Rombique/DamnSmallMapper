using System;
using System.Collections.Generic;
using System.Linq;

namespace DamnSmallMapper
{
	public class BasicMapProfile : IMapProfile
	{
		protected readonly HashSet<string> IgnoredPropertiesSet = new HashSet<string>();

		public object Map(object source, object target)
		{
			DefineMapping(source, target);
			return target;
		}

		protected virtual void DefineMapping(object source, object target)
		{
			foreach (var sourceProp in source.GetType().GetProperties())
			{
				if (!sourceProp.CanRead || sourceProp.GetGetMethod() == null ||
				    IgnoredPropertiesSet.Contains(sourceProp.Name.ToLowerInvariant()) ||
				    Attribute.IsDefined(sourceProp, typeof(DoNotMapAttribute)))
				{
					continue;
				}

				var targetProp = target.GetType().GetProperties()
					.FirstOrDefault(p =>
						string.Equals(p.Name, sourceProp.Name, StringComparison.CurrentCultureIgnoreCase));

				if (targetProp != null && targetProp.CanWrite && targetProp.GetSetMethod() != null &&
				    sourceProp.PropertyType == targetProp.PropertyType &&
				    !Attribute.IsDefined(targetProp, typeof(DoNotMapAttribute)))
				{
					targetProp.SetValue(target, sourceProp.GetValue(source));
				}
			}
		}

		public BasicMapProfile IgnoreProp(string propName) => 
			IgnoreProps(propName);

		public BasicMapProfile IgnoreProps(params string[] propNames)
		{
			foreach (var propName in propNames)
			{
				IgnoredPropertiesSet.Add(propName.ToLowerInvariant());
			}
			
			return this;
		}
	}
}
