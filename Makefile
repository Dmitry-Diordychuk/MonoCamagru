#csc *.cs */*.cs
#mono --debug CamagruMain.exe

all: down clear build up

build:
	docker build --tag kdustin/nginx				./src/Docker/nginx/
	docker build --tag kdustin/fastcgi-mono-server	./src/Docker/fastcgi-mono-server/

up:
	cd ./src/Docker ; docker-compose up -d

down:
	cd ./src/Docker ; docker-compose down

clear:
	docker stop `docker ps -qa` || true
	docker rm `docker ps -qa` || true
	docker rmi -f `docker images -qa` || true
	docker volume rm `docker volume ls -q` || true
	docker network rm `docker network ls -q` || true

.PHONY: all build up down clear destroy
