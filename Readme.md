How to run:
From a terminal within the solution folder simply run 'docker-compose up'
All WebAPIs should build and run in their own containers. 
APIs are accessible with the following ports:
WikiMediaHelperService							p:2000
MapHelperService								p:2001
WeatherMediaHelperService						p:2002
CelestialBodyHelperService						p:2004
MS-SQL Server (user-data)						p:2005
AstrophotographyHelperService (main service)	p:2006

Use the following requests to test:

WikiMediaHelperService
=================================================================================
http://localhost:2000/request?search=Moon  
(replace search parameter to any title of an wikipedia article. Title must match actual article title, including casing!)
http://localhost:2000/request/test  
(simple test to verify if the api is running and accessible, should return 'successful'


