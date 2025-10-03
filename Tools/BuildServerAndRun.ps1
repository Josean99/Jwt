##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='solution-jwt' --format="{{.ID}}"))
docker rm $(docker stop $(docker ps -a -q --filter ancestor='solution-angular-app' --format="{{.ID}}"))
docker rm $(docker stop $(docker ps -a -q --filter ancestor='postgres' --format="{{.ID}}"))
docker rmi $(docker images -q solution-jwt)
docker rmi $(docker images -q solution-angular-app)
docker rmi $(docker images -q postgres)

##construir
cd ../Solution/
docker-compose up
