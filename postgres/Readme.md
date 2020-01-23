***The Idea*** was how asp dotnet core works with postgres context database.

Here it is a simple sample!!!

This Repo is a (WebApp)"RazorPage" monolithic simple web application, so every thing (data access, logic, static file rendering ...) is done on the server.


### Under the hood
- Packet entity and feature entity are  in the business layer(folder)
- Postgres context code, configurations and migrations are in the data layer(folder)
- viewModel services and pages are in the UI layer(folder)

### Big Notes: 
- This sample uses postgres in container.Image pulled from postgres hub.
- This sample is should not be used in production scenarios. 

## how it works on linux(ubuntu 18)
### Installation
- install dotnet core sdk, runtime libraries.
go to https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1804 and follow the setps. (note: this project is tagreting 3.1 )
- install dotnet-ef tool for database creatation and migrations `$ dotnet tool install --global dotnet-ef `
- install docker.
### Run it
- on command line run: `$ docker run --rm   --name pg-docker -e POSTGRES_PASSWORD=pass -e POSTGRES_USER=PacketTest -d -p 5432:5432 -v $HOME/docker/volumes/postgres:/var/lib/postgresql/data  postgres:10.11`
- go to ./Data/ Folder and run `$ dotnet ef migrations add doMigratations -p Data.csproj -s ../Web/Web.csproj -c PacketContext -o migrations/` then `$ dotnet ef database update -p Data.csproj -c PacketContext -s ../Web/Web.csproj` 
- finally go to  ./Web/ Folder and on command line run `$ dotnet run`

### Windows 10
on windows should work with the same configurations and commands.


