# NET 7 Minimal API Using Docker Dotnet CLI

### Add the Microsoft.NET.Build.Containers nuget package using package manager console

```
add package Microsoft.NET.Build.Containers --version 0.2.7
```

### Publish the Docker image using dotnet CLI

```
dotnet publish command --os linux --arch x64 -p:PublishProfile=DefaultContainer
```

### Run the Container Image with Docker Command
```
docker run -it --rm -p 8080:80 weatherforecast-api:1.0.0
```
