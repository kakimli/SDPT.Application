1. Run the mssql server<br>
<code>docker-compose up -d</code>
2. Run the application<br>
<code>./start-redis.bat


1. To access the GraphQL Api: https://localhost:6001/graphql


1. Update Database
<code>
dotnet ef migrations add MyFirstMigration
dotnet ef database update
</code>