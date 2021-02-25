# Project Babelfish

## Running locally

- First time: `docker-compose up`
- Rebuilding images: `docker-compose up --build`

## Local Endpoints

Service | Local Port | Description
---|---|---
babel-fish | [8080](http://localhost:8080) | Frontend
translation-station | [8888](http://localhost:8888) | Backend
kibana | [5601](http://localhost:5601) | APM monitoring
grafana | [3000](http://localhost:3000) | prometheus metrics *Note: Temp password admin:admin*