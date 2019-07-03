# Nuget
- Go to https://www.nuget.org/
- Find Newtonsoft.Json
  - Project Site
  - Source repository
  - License
    - https://choosealicense.com/
    - Note about BSD
    - dual license
- How to install
  - Create Console App
  - Show options on site
    - Package Manager Console
    - csproj -> <ItemGroup>
    - Cli
    - VS UI
  - Pay attention to versions
- NuGet Hell
  - Draw on desk
    - Solutions: use a particular library/use the last library
- Download NuGet package
  - Show internals
  - Go to csproj and explain mapping
- Create NuGet package
  - Properties -> Package -> Update Something
  - Go to project and show changes
  - Pack
  - Show what cahnged
- Add custom NuGet Source
  - via VS
  - Show NuGet.config

# Newtonsoft.Json
- Show help: https://www.newtonsoft.com/json
- JsonConvert.SerializeObject(new { Test = "test" });
- Reference to the previous lecture

# SonarAnalyzer
- https://www.nuget.org/packages/SonarAnalyzer.CSharp/
- Show analyzers
  - Help Link
  - Reproduce issue
  - Change severity
    - Open ruleset in XML editor
  - Suppress
- Explore analyzers

# Automapper
- Ask student for manual mapping
- Getting Started
  - IMapper mapper = new Mapper(...
  - AssertConfigurationIsValid
- Flattering
  - Normal
  - Include Members
    - Rename from CapabilityCanRead to CanRead
- Projection
  - ForMember
- Collections
- Values Converters
- Di and 
  
# Polly
- https://github.com/App-vNext/Polly
- Ask student for assistance with retry
- Show diagram
```
            Policy
                .Handle<NotImplementedException>()
                .Retry(3)
                .Execute(() =>
                {
                    System.Console.WriteLine("Test");
                    throw new NotImplementedException();
                });
```
- https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly

# Swashbuckle
https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio