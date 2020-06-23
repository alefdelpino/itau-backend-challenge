# ---- Run Build ----
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY ./src /app/
WORKDIR /app/FrameworksAndDrivers
RUN dotnet restore
RUN dotnet publish -c Release -o out

# ---- Run App ----
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as release
ENV SWAGGER_YAML_FILE "swagger.yaml"
WORKDIR /app
COPY --from=build /app/FrameworksAndDrivers/out .
COPY swagger.yaml .
ENTRYPOINT ["dotnet", "FrameworksAndDrivers.dll"]