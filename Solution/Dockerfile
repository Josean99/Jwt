FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./../Jwt.sln .
COPY ./../Jwt/*.csproj ./Jwt/
COPY ./../Jwt.Service/*.csproj ./Jwt.Service/
COPY ./../Jwt.DAL/*.csproj ./Jwt.DAL/
COPY ./../Jwt.DTOs/*.csproj ./Jwt.DTOs/
COPY ./../Jwt.Entities/*.csproj ./Jwt.Entities/

RUN dotnet restore 

COPY ./../Jwt/. ./Jwt/
COPY ./../Jwt.Service/. ./Jwt.Service/
COPY ./../Jwt.DAL/. ./Jwt.DAL/
COPY ./../Jwt.DTOs/. ./Jwt.DTOs/
COPY ./../Jwt.Entities/. ./Jwt.Entities/

WORKDIR /app/Jwt
RUN dotnet publish -c Release -o ./out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/Jwt/out ./

#EXPOSE 5036
#EXPOSE 7036

ENTRYPOINT ["dotnet", "Jwt.dll", "--launch-profile Docker"]
