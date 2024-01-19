##Borrar la imagen vieja
docker rm $(docker stop $(docker ps -a -q --filter ancestor='jwt_image' --format="{{.ID}}"))
docker rmi $(docker images -q jwt_image)

##Crear Imagen
docker build --rm -f Jwt/Dockerfile -t jwt_image .
##Crear Contenedor
docker run --add-host host.docker.internal:host-gateway --rm -d -p 5000:80 --name jwt_container jwt_image