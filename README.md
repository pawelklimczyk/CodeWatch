## Gmtl.CodeWatch library ##

### Idea ###

Idea behind creating CodeWatch was to add quality layer in developed product. Developers may use different IDE and programming techniques in the same project. Some tools (like FxCop) are difficult to use outside expected IDE. Developers agree to follow "coding standards" and forget to do that later.

This tool is not a panacea. It's rather a complementary piece that can help you achieve better code quality. It does not think on your behave, but automates it a little.


### What CodeWatch can solve? ### 

- Automates rules checking during unit/integration testing
- Keep code conventions along with the project (in XML file)

### Sample usage ###

```
    public class GlobalContextTests
    {
        [Test]
        public void FluentConfigurationBuilder()
        {
            CodeWatcherConfig config = CodeWatcherConfig.Create()
                .WithWatcher(c => new FieldNamingWatcher(c).Configure(Naming.UpperCase))
                .WatchAssembly(typeof(DomainModel).Assembly)
                .Build();

            config.Execute();
        }
    }
```

### I miss a feature.... ###

You are very welcome to add a [pull request][1].

[1]: https://github.com/pawelklimczyk/CodeWatch/compare

