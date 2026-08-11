
### *How To Run*

***make sure you Have:***
- docker
- dotnet version 8.0
---
**step by step**
- change the fields in env.example
- run `docker compose up -d`
***note*** if this not working, you might running another container listen on port 3306 (you can change the port number in docker compose and down)

- run
`dotnet user-secrets init`
- change the password and run 
`dotnet user-secrets set "ConnectionStrings:db" "Server=localhost;User=root;Password=YOUR_PASSWORD;Port=3306;Database=UnitManagement"`
- run `dotnet ef migrations add Init`
- run `dotnet ef database update`
- run `dotnet run`


---
### **notes and explaining about that project**
- I make every business role as Exception so in future I be able to mange all in Middle Ware 





