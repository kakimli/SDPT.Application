Introduction
---

- SDPT.Application.Api receives form data (creating demand or housing post) and then publish to the topic
- SDPT.Application.MailService subscribes to the topic and send notification email to matched users
- SDPT.Application.GraphQL provides a GraphQL endpoint to query all the data in the database


Prerequisites
---
1. Install Dapr - https://docs.dapr.io/getting-started/install-dapr-cli/
2. Install Docker - https://docs.docker.com/get-docker/

Start the Server
---

1. Run the mssql server<br>
<code>docker-compose up -d</code>
2. Run the application<br>
<code>./start-redis.bat</code> or <code>./start-redis.sh</code>

Endpoints
---

1. To access the GraphQL Api: https://localhost:6001/graphql
2. To access the Demand Api: http://localhost:6002/swagger/index.html

Other
---

1. Update Database<br>
in ./SDPT.Application.Data.Migrations<br>
<code>
dotnet ef migrations add AddIntro --startup-project "..\SDPT.Application.GraphQL\"
</code><br>
in ./SDPT.Application.GraphQL<br>
<code>
dotnet ef database update
</code>
