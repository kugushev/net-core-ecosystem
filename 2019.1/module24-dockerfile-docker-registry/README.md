Dockerfile
	hub.docker.com => microsoft/dotnet
	
	FROM microsoft/dotnet:2.1-aspnetcore-runtime
	WORKDIR /app
	EXPOSE 80
	COPY bin/Release/netcoreapp2.1/publish/. .
	ENTRYPOINT ["dotnet", "WebApp.dll"]
	
	docker build -t test1 .
	docker run -p 80:80 --name my-test1 test1
	
Dockerfile ex	
	Use VS scaffolding
	docker build -t test2 -f .\WebApplicationDocker\Dockerfile .
	docker run -p 80:80 --name my-test2 test2

	docker exec -it my-test2 bash
	
	
TODO: 
- add to docker registry
- launch on linux machine
- ??? kubernetes ???
