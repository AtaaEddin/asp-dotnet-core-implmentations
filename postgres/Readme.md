*The Idea:* was how asp dotnet core works with postgres context database.

Here it is a simple sample!!!

This Repo is a (WebApp)"RazorPage" monolithic simple web application, so every thing (data access, logic, static file rendering ...) is done on the server.


*Under the hood*
- Packet entity and feature entity are  in the business layer(folder)
- Postgres context code, configurations and migrations are in the data layer(folder)
- viewModel services and pages are in the UI layer(folder)

*how it works on linux(ubuntu 18)*
- install docker.
- on command line run: docker run --rm   --name pg-docker -e POSTGRES_PASSWORD=pass -e POSTGRES_USER=PacketTest -d -p 5432:5432 -v $HOME/docker/volumes/postgres:/var/lib/postgresql/data  postgres:10.11
- go to ./Web/ folder and run on command line $ dotnet run

on windows should work with the same configurations and commands.

