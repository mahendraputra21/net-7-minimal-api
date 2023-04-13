# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the code into the container
COPY . ./

# Restore NuGet packages
RUN dotnet restore ./MyFristWebApp/MyFristWebApp.sln

# Build the application
RUN dotnet build ./MyFristWebApp/MyFristWebApp.sln --configuration Release --no-restore

# Test the application
RUN dotnet test ./TodoTestProject/TodoTestProject.csproj --configuration Release --no-build

# Publish the application
RUN dotnet publish ./MyFristWebApp/MyFristWebApp.csproj --configuration Release --no-build --output /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Expose ports 80 and 443
EXPOSE 80 443

# Set the entry point to run the application
ENTRYPOINT ["dotnet","MyFristWebApp.dll"]