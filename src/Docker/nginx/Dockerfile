FROM debian:10.13-slim

RUN	apt-get update && apt-get install -y nginx dnsutils

WORKDIR /

COPY ./docker-entrypoint.sh		/
COPY ./conf/templates			/etc/nginx/templates
COPY ./conf/nginx.conf			/etc/nginx/nginx.conf
COPY ./conf/fastcgi_params		/etc/nginx/fastcgi_params

EXPOSE 80

STOPSIGNAL SIGQUIT

ENTRYPOINT [ "/bin/sh", "docker-entrypoint.sh" ]
