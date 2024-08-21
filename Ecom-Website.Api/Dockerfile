#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage1: asp.net is the runtime that is needed to run the application in the production environment and it is the base layer  - this will run the application as the binary language
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
# current working directory called /app - In the virtual machine we launch a container in which the /app directory is created
WORKDIR /app
 # exposing port 8080 for http request
EXPOSE 8080
# exposing port 8081 for https request
EXPOSE 8081

# Stage2: after running the application we have to build the application and can be done using the sdk - the application has to be build inorder to ship it with the source code to the docker container
# basically compiling the file
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
# directing to the current working directory
WORKDIR /src
# in /src, we are copying the existing .csproj and creating a new folder in the docker Ecom-Website.Api/ and placing the copied file in this newly created folder
COPY ["Ecom-Website.Api/Ecom-Website.Api.csproj", "Ecom-Website.Api/"]
COPY ["Ecom-Website.DataAccess/Ecom-Website.DataAccess.csproj", "Ecom-Website.DataAccess/"]
# we use restore command uses nuget package manager console to install the dependencies
RUN dotnet restore "./Ecom-Website.Api/Ecom-Website.Api.csproj"
# copy everything into newly created folder in /src
COPY . .
# change the directory to the newly created folder as it contains all the required files and the dependencies related to the application
WORKDIR "/src/Ecom-Website.Api"
# -c is command, basically the csproj is build in the binary form and the output(-o) is placed in /app/build
RUN dotnet build "./Ecom-Website.Api.csproj" -c Release -o /app/build

# Stage3: after building and storing the result in build folder we need to publish this folder by running .csproj present in this folder
# run the file
#run the build folder and store the result in the /app/publixh folder
FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecom-Website.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage4 : As we got the publish version of the file we copy all the content from the /app/publish directory to the /app directory
FROM base AS final
WORKDIR /app
# Copying the /app/publish of the publish stage and copy it to /app
COPY --from=publish /app/publish .
# we tell where to start the applicationby specifying that dotnet .dll file of the application
ENTRYPOINT ["dotnet", "Ecom-Website.Api.dll"]