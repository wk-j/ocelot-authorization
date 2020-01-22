## Ocelot Authorization

```bash
docker-compose build
docker-compose up
```

## Gateway

```bash
open http://localhost/s1/wf
open http://localhost/WeatherForecast
open http://localhost/api/token/authorize
```

## Identity Service

```bash
docker-compose build identity-service
docker-compose up identity-service
open http://localhost:90/WeatherForecast
```

## Resource

- https://kdrenski.com/wp/jwt-authentication-with-asp-net-core-and-identityserver4
- https://medium.com/swlh/building-net-core-api-gateway-with-ocelot-6302c2b3ffc5