Dockerfile
	open https://github.com/wsargent/docker-cheat-sheet
	Class work:
		A container that uses just built dlls
		Create a container that builds solution from sources
		Multistage build
	
Scaffolding issues	
	Review Output (debug/release):
		Entrypoint
		Target - app
		Leaky containers
	Go deeper:
		docker exec -it my-test2 bash
		docker top <container>	
	
Compose:
	Review output
	Support multiple bases
	! docker compose build vs docker compose up !
-----------------------------------------------------------------
version: "3.6"

services:
  application:
    environment:
      - ASPNETCORE_URLS=https://+:443
    container_name: application
    image: ${DOCKER_REGISTRY:-}application:${IMAGE_VERSION:-dev}
    build:
      context: .
      dockerfile: Application/Dockerfile
    ports:
      - "52431:443"
    networks:
      - dev-postgres-net	

  test-postgres:
    image: postgres:10
    container_name: test-postgres
    networks:
      - test-postgres-net
    labels:
      - local.dev.postgres

networks:
  test-postgres-net:
    name: test-postgres-net
-----------------------------------------------------------------	