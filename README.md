# DamnSmallMapper
## How to use

Basically you can use 
```csharp
var foo = new Foo();
foo.MapFrom(bar);
```
or
```csharp
var foo = DamnSmallMapper.Map<Foo>(bar);
```
That's it! Now **foo** object contains values from object **bar**.
It maps properties with the same name ignoring case and type. 

## How to ignore properties
There are two different ways to mark property as ignored
1. **DoNotMapAttribute**
2.  **IgnoreProps** function

First, you can mark property by **DoNotMapAttribute** in target-class
```csharp
public TargetClass 
{
	[DoNotMap]
	public string IgnoredInTarget { get; set; }
}
```
or in source-class
```csharp
public SourceClass 
{
	[DoNotMap]
	public string IgnoredInSource { get; set; }
}
```
The second option is **IgnoreProps** function in **BasicMapProfile** (check Map profiles section below)
or using **ignoreProps** argument in **MapFrom** function
```csharp
// using MapFrom
foo.MapFrom(bar, nameof(Bar.IgnoredProp));

// using Map
var foo = DamnSmallMapper.Map<Foo>(bar, nameof(Bar.IgnoredProp));
```

##  Map profiles

It's possible to create your own map profile. 
```csharp
public class CustomMapProfile : BasicMapProfile  
{  
	protected override void DefineMapping(object source, object target)  
	{  
		IgnoreProps(nameof(Foo.IgnoredProperty));
		(target as Foo)!.IgnoredProperty = "Another value";
		base.DefineMapping(source, target);
	}
}
```
And use it in your code
```csharp
var customMapProfile = new CustomMapProfile();
foo.MapFrom(bar, customMapProfile);
```
or
```csharp
var customMapProfile = new CustomMapProfile();
foo = DamnSmallMapper.Map<Foo>(bar, customMapProfile);
```

## Samples

You can find useful snippets in [test-project](https://github.com/Rombique/DamnSmallMapper/tree/master/test/DamnSmallMapper.Test)
