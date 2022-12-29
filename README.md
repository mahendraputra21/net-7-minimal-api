# NET 7 Minimal API Using Docker Dotnet CLI

### Add the Microsoft.NET.Build.Containers nuget package using package manager console

```
add package Microsoft.NET.Build.Containers --version 0.2.7
```

### Publish the Docker image using dotnet CLI

```
dotnet publish command --os linux --arch x64
```

### Add container properties in the PropertyGroup element in the project file
```
<PropertyGroup>
  <TargetFramework>net7.0</TargetFramework>
  <Nullable>enable</Nullable>
  <ImplicitUsings>enable</ImplicitUsings>
  <ContainerBaseImage>mcr.microsoft.com/dotnet/aspnet:7.0</ContainerBaseImage>
  <ContainerImageName>todo-min-api</ContainerImageName>
  <ContainerImageTag>v1</ContainerImageTag>
</PropertyGroup>
```

### Run the Container Image with Docker Command
```
docker run -it --rm -p 8080:80 weatherforecast-api:1.0.0
```

### Create a Dummy Token using dotnet CLI
```
dotnet user-jwts create
```
