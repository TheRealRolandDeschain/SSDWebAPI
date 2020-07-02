Github Repository Adress: https://github.com/TheRealRolandDeschain/SSDWebAPI

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

<h1>WikiMediaHelperService</h1>
Uses a simple search term as input and returns sanitized article information. This information contains title, descriptions
as well as the summary (first part of the article before sections start) and a url to the first image of the article. 
Search input must match article title. 


<h1>MapHelperService</h1>
Uses four parameters consting of latitude and longitude information and span over a certain area 
and returns all map nodes from OpenStreetMap which are usually light sources (villages, industrial, shops,...)

Important: especially in city areas, if the search area is too big, the service could take a while, or 
even refuses to response (timeout limit). 



<h1>WeatherHelperService</h1>
Dummy service, since for OpenWeatherMap extra registration would have been necessary. 
The service has a bunch of presaved weather data stored in a json file and returns one randomly. 
Input parameters of starttime, endtime, longitude and latitude are necessary nonetheless!


<h1>CelestialBodyHelperService</h1>
Dummy service as well. Has several models of celestial bodies stored in a json file and will return 
them randomly as well. Again it still requires actual input parameters of Right Ascention, Declination and a searchangle. 



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

- Sometimes a process from Visual Studion would block project files, making them unable to access for docker deployment (this would only affect
the zipping step in the sqlserver container). The only solution I have found for this, was either to stop VS2019, or unload the 
Database project temporarily

- The Dependency Injection System used by the Asp.NET Framework is quite difficult to wrap one's head around, if one is not used to it. 

- Controller Methods in Asp.NET project can either return IActionResult or the actual datatype one has to return. IActionResult has the 
advantage that one can control HTTP codes, which are returned directly, but on the other hand the code gets harder to read, since it is 
not immediately obvious what should be returned. 

- Problems with .dockerignore which turned out to be problems of COPY . . 