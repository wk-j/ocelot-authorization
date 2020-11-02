# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.101 as build
WORKDIR /app
COPY src/SecureWeb src/SecureWeb
RUN dotnet build src/SecureWeb

# Stage 2
FROM build as publish
WORKDIR /app
RUN dotnet publish src/SecureWeb -c Release -o /app -r linux-x64

# Stage 3
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app .
CMD dotnet SecureWeb.dll