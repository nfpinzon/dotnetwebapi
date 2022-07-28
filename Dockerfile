FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
WORKDIR /app
COPY . .
RUN dotnet restore

RUN dotnet publish -c release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0  AS runtime
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

COPY --from=build /app .

# Optional: Set this here if not setting it from docker-compose.yml
# ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "mywebapi.dll"]
