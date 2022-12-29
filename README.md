# .NET 7 Minimal API Build Image Docker using Dotnet CLI

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
dotnet publish --os linux --arch x64
```
![image](https://user-images.githubusercontent.com/31196162/209962610-493fed2c-35dc-4066-b73a-562cc9d3d54f.png)
![image](https://user-images.githubusercontent.com/31196162/209962887-45c9fb48-9ae6-4e5f-8d67-e37b1532ce12.png)


### Run the Container Image with Docker Command
```
docker run -it --rm -p 8080:80 todo-min-api:v1
```
![image](https://user-images.githubusercontent.com/31196162/209968830-1a42cf48-b486-4239-9c77-70dd19e419b3.png)


### Type in the browser http://localhost:8080/swagger
![image](https://user-images.githubusercontent.com/31196162/209963554-ef21ff5c-8c7f-4b49-85c0-2a430efdbbe5.png)

### Push into Docker Hub 
```
docker tag todo-min-api:v1 dewamahendra31/todo-minimal-api7:v1
```
```
docker login --username dewamahendra31
```
![image](https://user-images.githubusercontent.com/31196162/209971038-881031e4-b4f2-4380-b2ec-fd4a0dcb7f47.png)
```
docker push dewamahendra31/todo-minimal-api7:v1
```
![image](https://user-images.githubusercontent.com/31196162/209971707-9d671683-eda5-44a5-9118-a89ed075bd70.png)
![image](https://user-images.githubusercontent.com/31196162/209971940-59e830f9-29a7-4a53-ab1c-c255d47392a2.png)


## References
- https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2204
- https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70
- https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-7.0&tabs=windows

#### Create JSON Web Tokens in development using dotnet CLI (for development purpose only)
```
dotnet user-jwts create
```
![image](https://user-images.githubusercontent.com/31196162/209964196-c9ddfd77-90a4-484b-bff0-3cec1b060b69.png)

