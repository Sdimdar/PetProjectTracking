.net 6    
database Postgres      
Open project > ProjectTrackig.API and change appsetings.json > DefaultConnectionString > check postgres port, userId and password.   
Update database with script   
```src\Services\ProjectTracking\ProjectTracking.Infrastructure> dotnet ef database update -p .\ProjectTracking.Infrastructure.csproj -s ..\ProjectTracking.API\ProjectTracking.API.csproj```

