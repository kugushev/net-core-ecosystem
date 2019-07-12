Show presentation #3
Show presentation #2

Ubuntu in docker	
	docker pull ubuntu:latest
	docker create -it --name my ubuntu /bin/bash
		-i - interactive
		-t - tty (console attach)
	docker start my
	docker ps
	docker start -i my
	docker ps -a
	
	!!!image vs container
	
	docker images
	docker rm my	
	
	docker run -it ubuntu /bin/bash	
	
	docker run --rm ...
	
Redis in docker
	go to https://hub.docker.com/
	!!!tags
	docker run -d --name my_redis redis:latest
		-d - detached
		
Elasticseaerch in docker
	go to https://hub.docker.com/
	go to docker.elastic.co
	
	docker pull docker.elastic.co/elasticsearch/elasticsearch:6.4.0
		external repository
	docker run -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" docker.elastic.co/elasticsearch/elasticsearch:6.4.0
		-e - environment variables
	=> create index => go to _cat/indices
	docker stop <hash> => elastic doesn't work
	docker start <hash> => go to _cat/indices
	docker rm -f <hash>
	docker run .. => go to _cat/indices
	!!!volumes (can be local, network, cloud, etc.)
	docker run -v $PWD/elastic:/usr/share/elasticsearch/data ... => go to folder => create index => go to folder
	docker rm -f $(docker ps -aq) => check index => docker run ...
	 
Kibana in docker:
	Internal network, docker DNS, Use container name as DNS name
	docker network create <name>
	docker run  elastic ... --network=<networkname>
	docker run -p 5601:5601 --network=my-network -e "ELASTICSEARCH_URL=http://elastic:9200" docker.elastic.co/kibana/kibana:6.4.1

Logs:
	docker logs
	
Docker compose
	https://docs.docker.com/compose/overview/
	don't forget about docker compose build/up
	elasticsearch + kibana
		redis + postgres - homework
	
version: '3'
services:
    elastic:
        image: docker.elastic.co/elasticsearch/elasticsearch:6.4.0
        ports:
            - "9200:9200"
            - "9300:9300"
        environment:
            - "discovery.type=single-node"
        volumes:
            - "C:/Projects/training/lectures/2018/net-core-ecosystem/module25-docker/test/elastic:/usr/share/elasticsearch/data"
            
    kibana:
        image: docker.elastic.co/kibana/kibana:6.4.1
        ports:
            - "5601:5601"
        environment:
            - ELASTICSEARCH_URL=http://elastic:9200
	
	

Build net core application in docker => next module


