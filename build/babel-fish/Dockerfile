FROM node:12.16.1-alpine AS builder

WORKDIR /usr/src/app

COPY ./babel-fish/package.json ./babel-fish/package-lock.json ./

RUN npm update && \
    npm install --production && \
    npm install -g @angular/cli

COPY ./babel-fish .

RUN ng build --aot true

FROM nginx:1.15-alpine
COPY ./build/babel-fish/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /usr/src/app/dist/babel-fish /usr/share/nginx/html