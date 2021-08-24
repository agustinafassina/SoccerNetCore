# SoccerNetCore:
This is a CRUD basic of Soccer. With two table (Pplayer and Team).
__________________________________________________________________

It is necessary to run the scripts -> database_script.sql
The connectionString is changed in appsettings.json (to associate the database)

## Run the service:
###*To run the local service:

```
dotnet run
``` 
https://localhost:5001/api/players
http://localhost:5000/api/players

###*To run the service with docker:

```
docker build -t soccer-net-core .
docker run -p 7001:80 --name soccer-net-core soccer-net-core
```
http://localhost:7001/api/players
