How To Run 

- change the fields in env.example
- run `docker compose up -d`
- run `dotnet user-secrets init`
- change the password and run `dotnet user-secrets set "ConnectionStrings:db" "Server=localhost;User=root;Password=YOUR_PASSWORD;Port=3306;Database=UnitManagement"`
