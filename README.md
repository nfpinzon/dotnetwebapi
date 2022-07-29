# Webapi con .net core y EntityFramework
Api desarrollada en .net core con entity framework conectada a postgresql

# Docker
## Postgres
docker run -d --name mypostgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 postgres
## WebApi
docker build -t mywebapi .

docker run --name webapinet -p 80:80 --link mypostgres:postgres mywebapi

# EndPoints
## Creacion del modelo EntityFramework
http://localhost/api/v1/HelloWorld/createdb

## Consultas 
http://localhost/api/v1/categoria

<img width="382" alt="image" src="https://user-images.githubusercontent.com/17347628/181656790-473f21fd-eb92-4286-8117-272e9ac1c4dc.png">

http://localhost/api/v1/tarea

<img width="421" alt="image" src="https://user-images.githubusercontent.com/17347628/181656912-ed44b260-b8f8-4972-9b1a-fa27afcffffc.png">
