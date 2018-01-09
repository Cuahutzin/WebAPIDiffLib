Architecture overview (centralized approach): [overview.PNG]

Two byte arrays (base64 encoded) are sent to host1 and host2 respectively, from a  client. Both host1 
(worker) and host2 (worker), send data to host3 (central).

Host3 (central) will process the request by decoding, and performing a diff between these 2 byte arrays, 
and a result will be given to the client. To see an example go to ConsoleApp\Program.cs or Tests\IntegrationTest.cs

Server base addresses:
	Worker: http://localhost:49778/
	Central: http://localhost:49782/

In order to have a second worker server, it must be published and hosted separately from Visual Studio. And
the client will have to point to a different server when requesting to host2.

- Worker project needs a base address to Central server
- ConsoleApp and Tests projects base addresses are hardcoded
- Api routes are found inside Utils\RouteConf.cs

How to run:
	- Open visual studio solution
	- Run Central and Worker projects (IIS Express)
	- Run automated tests (Tests project) or run ConsoleApp project

External libraries used:
	- Unity container (DI)
	- Moq (Unit testing)

Target .NET Framework version: v.4.6.1
Created from Visual Studio 2017 v15.4.5

Project overview:
Tests
	- Unit and integration tests

ConsoleApp
	- Demonstration of how it works

Central
	- AspNet Web Api that handles create, complete and getdiff api requests
	- When the application starts (Application_Start), an object of CentralServerState is created and
		- inserted into the HttpContext current cache.
	- Create: recieves base64 encoded data and returns an id
	- Complete: recieves an id and base64 encoded data and returns the same id
	- GetDiff: recieves an id and returns a diff result between the decoded data

Worker
	- AspNet Web Api that handles create and complete api requests, and passes them to a Central server

DiffLib
	- A library to contains interfaces and implementation to communicate and process requests.
	- Endpoints namespace: Contains the endpoints of Central and Worker servers
	- Packets namespace: Contains the request and response objects that clients, central and worker servers use.
	- Utils namespace: Contains ISender interface and WebApiSender implementation that endpoints use to send data
	- AspNetCentralServer: Diff Implementation
	- CentralServerState: Holds the created ids and data between requests
	- DiffResult: Actual result from diff

Utils
	- RouteConf.cs is used by both Central and Worker to get the api routes
