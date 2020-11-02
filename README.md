## Ocelot Authorization

- [x] Auto attach authorize header

```bash
docker-compose build
docker-compose up
```

## Gateway

```bash
http http://localhost/s1/wf
http http://localhost/secure-web/wf --auth api:or2020api
http http://localhost/secure-web/wf
http http://localhost/api/token/authorize
```

## Resource

- https://kdrenski.com/wp/jwt-authentication-with-asp-net-core-and-identityserver4
- https://medium.com/swlh/building-net-core-api-gateway-with-ocelot-6302c2b3ffc5