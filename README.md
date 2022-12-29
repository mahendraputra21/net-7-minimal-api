# .NET 7 Minimal API Using Docker Dotnet CLI

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
  <!--<ContainerBaseImage>mcr.microsoft.com/dotnet/aspnet:7.0</ContainerBaseImage>-->
  <ContainerImageName>todo-min-api</ContainerImageName>
  <ContainerImageTag>v1</ContainerImageTag>
</PropertyGroup>
```

### Publish the Docker image using dotnet CLI

```
dotnet publish command --os linux --arch x64
```
![image](https://user-images.githubusercontent.com/31196162/209962610-493fed2c-35dc-4066-b73a-562cc9d3d54f.png)
![image](https://user-images.githubusercontent.com/31196162/209962887-45c9fb48-9ae6-4e5f-8d67-e37b1532ce12.png)


### Run the Container Image with Docker Command
```
docker run -it --rm -p 8080:80 todo-min-api:v1
```
![image](https://user-images.githubusercontent.com/31196162/209963110-2e197c74-2d99-49ce-ab9d-fcf353184854.png)
![image](https://user-images.githubusercontent.com/31196162/209963554-ef21ff5c-8c7f-4b49-85c0-2a430efdbbe5.png)




### Create a Dummy Token using dotnet CLI
```
dotnet user-jwts create
```
![image](https://user-images.githubusercontent.com/31196162/209964196-c9ddfd77-90a4-484b-bff0-3cec1b060b69.png)


## References
- https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2204
- https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70
