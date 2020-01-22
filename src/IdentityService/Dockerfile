# Stage 1
FROM mcr.microsoft.com/dotnet/core-nightly/sdk:3.1.101 as build
WORKDIR /app
COPY src/IdentityService src/IdentityService
RUN dotnet build src/IdentityService

# Stage 2
FROM build as publish
WORKDIR /app
RUN dotnet publish src/IdentityService -c Release -o /app -r linux-x64

# Stage 3
FROM mcr.microsoft.com/dotnet/core-nightly/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD dotnet IdentityService.dll