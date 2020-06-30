How to run:
After cloning the repo, from a terminal within the solution folder simply run 'docker-compose up' (or docker-compose up --build --force-recreate to rebuild)
All WebAPIs should build and run in their own containers. 
APIs are accessible with the following ports:  
  
- WikiMediaHelperService => p:2000
- MapHelperService => p:2001
- WeatherMediaHelperService => p:2002
- CelestialBodyHelperService => p:2003
- MS-SQL Server (user-data) => p:2004
- AstrophotographyHelperService (main service) => p:2005

WikiMediaHelperService
=================================================================================



MapHelperService
=================================================================================



WeatherHelperService
=================================================================================


CelestialBodyHelperService
=================================================================================




<h1>Pitfalls and other notes</h1>

- Started out with ASP.NET 4.7.2 project, which doesn't have a lot of documentation, 
doesn't run in linux containers and results in much bigger containers - had to migrate to ASP.NET Core 3.1

- Unfortunately, ASP.NET Core doesn't implement the out of the box user authentification that the old framework had. 
This is, so one has the freedom to use external schemes, however meant reading into JWT Tokens and Password hashing. 
As of now, I'm still don't think this authentification scheme is save (even leaving out the paintext secrets and password here)

- Automated deployment of SQL Database project: This actually did cost quite a bit of time. 
At long last I found <a href="https://www.wintellect.com/devops-sql-server-dacpac-docker/">this blog</a> which help me
create a docker and docker-compose file, so that I would only have to build my database project and create a dacpac file first. 
Adding a postscript to copy the dacpac file to the dockerfile, I could automate the process at least a bit. 

