# Gmtl.CodeWatch library

## Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/8v6omwnj1o4fdc2h?svg=true)](https://ci.appveyor.com/project/pawelklimczyk/codewatch)
[![NuGet](https://img.shields.io/nuget/v/Gmtl.CodeWatch.svg)](https://www.nuget.org/packages/Gmtl.CodeWatch/)
## Idea

Idea behind creating CodeWatch was to add quality layer in developed product. Developers may use different IDE and programming techniques in the same project. Some tools (like FxCop) are difficult to use outside expected IDE. Developers agree to follow "coding standards" and forget to do that later.

This tool is not a panacea. It's rather a complementary piece that can help you achieve better code quality. It does not think on your behave, but automates it a little.


## What CodeWatch can solve?

- Automates rules checking during unit/integration testing
- Keep code conventions along with the project (in XML file)

## Examples


All fields in given assembly has to be uppercase

```
[TestFixture]
public class GlobalContextTests
{
    [Test]
    public void FluentConfigurationBuilder()
    {
        CodeWatcherConfig config = CodeWatcherConfig.Create()
            .WithWatcher(c => new FieldNamingWatcher(c).Configure(Naming.UpperCase))
            .WatchAssembly(typeof(DomainModel).Assembly)
            .Build();
            
        var result = config.Execute(); 
        
        //this will fail
        Assert.IsFalse(result.HasIssues);
    }
}
```

All properties in given assembly have to be uppercase, but skip DomainModel class from checking

```
[TestFixture]
public class GlobalContextTests
{
    [Test]
    public void FluentConfigurationBuilder()
    {
        CodeWatcherConfig config = CodeWatcherConfig.Create()
            .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.UpperCase))
            .WatchAssembly(typeof(DomainModel).Assembly)
            .SkipType(typeof(DomainModel))
            .Build();

        var result = config.Execute(); 
        
        //this will fail
        Assert.IsFalse(result.HasIssues);
    }
}
```

All properties in multiple assemblies have to be uppercase

```
[TestFixture]
public class GlobalContextTests
{
    [Test]
    public void FluentConfigurationBuilder()
    {
        CodeWatcherConfig config = CodeWatcherConfig.Create()
            .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.UpperCase))
            .WatchAssembly(typeof(DomainModel).Assembly)
            .WatchAssembly(typeof(PersistenceLayer).Assembly)
            .WatchAssembly(typeof(DomainServices).Assembly)
            .Build();

        var result = config.Execute(); 
        
        //this will fail
        Assert.IsFalse(result.HasIssues);
    }
}
```

All try/catch clauses in given assembly have to be handled

```
[TestFixture]
public class GlobalContextTests
{
    [Test]
    public void FluentConfigurationBuilder()
    {
        CodeWatcherConfig config = CodeWatcherConfig.Create()
            .WithWatcher(c => new ExceptionHandlingWatcher(c))
            .WatchAssembly(typeof(DomainModel).Assembly)
            .Build();

        var result = config.Execute(); 
        
        //this will fail
        Assert.IsFalse(result.HasIssues);
    }
}
```

All methods in assembly neet to have at most 4 parameters

```
[TestFixture]
public class GlobalContextTests
{
    [Test]
    public void FluentConfigurationBuilder()
    {
        CodeWatcherConfig config = CodeWatcherConfig.Create()
            .WithWatcher(c => new MaxMethodParametersWatcher(c).Configure(4))
            .WatchAssembly(typeof(DomainModel).Assembly)
            .Build();

        var result = config.Execute(); 
        
        //this will fail
        Assert.IsFalse(result.HasIssues);
    }
}
```

All methods return types must be of type IList<T>

```
[TestFixture]
public class GlobalContextTests
{
    [Test]
    public void FluentConfigurationBuilder()
    {
        CodeWatcherConfig config = CodeWatcherConfig.Create()
            .WithWatcher(c => new MethodReturnTypeWatcher(c).Configure(typeof(IList<object>)))
            .WatchAssembly(typeof(DomainModel).Assembly)
            .Build();

        //This will throw exception if any public method will return something else than IList<T>
        config.Execute();
    }
}
```

## I miss a feature....

**You are very welcome to add a [pull request][1].**

[1]: https://github.com/pawelklimczyk/CodeWatch/compare

