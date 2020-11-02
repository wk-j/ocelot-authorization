# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101 as build
WORKDIR /app
COPY src/Service1 src/Service1
RUN dotnet build src/Service1

# Stage 2
FROM build as publish
WORKDIR /app
RUN dotnet publish src/Service1 -c Release -o /app -r linux-x64

# Stage 3
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD dotnet Service1.dll