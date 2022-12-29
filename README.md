# NET 7 Minimal API Using Docker Dotnet CLI

### Add the Microsoft.NET.Build.Containers nuget package using package manager console

```
add package Microsoft.NET.Build.Containers --version 0.2.7
```
![image](https://user-images.githubusercontent.com/31196162/209952797-b0c92560-5d72-46d6-96fc-82f72b53318c.png)

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

### Publish the Docker image using dotnet CLI

```
dotnet publish command --os linux --arch x64
```

### Run the Container Image with Docker Command
```
docker run -it --rm -p 8080:80 weatherforecast-api:1.0.0
```

### Create a Dummy Token using dotnet CLI
```
dotnet user-jwts create
```
![image](https://user-images.githubusercontent.com/31196162/209952584-b83af0fd-936f-4616-a3f2-377ba4482ccd.png)

