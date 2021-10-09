# SoccerNetCore:
This is a CRUD basic of Soccer. With two table (Player and Team).
__________________________________________________________________

It is necessary to run the scripts -> database_script.sql
The connectionString is changed in appsettings.json (to associate the database)

## Run the service:
*To run the local service:

```
dotnet run
``` 
https://localhost:5001/api/players
http://localhost:5000/api/players

*To run the service with docker:

```
docker build -t soccer-net-core .
docker run -p 7001:80 --name soccer-net-core soccer-net-core
```
http://localhost:7001/api/players


Articles about the repository:
https://medium.com/@agustinafassina_92108/implement-an-send-emails-service-with-mailkit-and-smtpclient-23327ebc9294
https://medium.com/@agustinafassina_92108/soccer-microservice-on-asp-net-entity-framework-mysql-and-insomnia-11953ccabd8e
