FROM debian:10.13-slim

RUN	apt-get update && apt-get install -y dnsutils apt-transport-https dirmngr gnupg ca-certificates
RUN	apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
RUN	echo "deb https://download.mono-project.com/repo/debian stable-buster main" | tee /etc/apt/sources.list.d/mono-official-stable.list
RUN	apt update && apt install -y mono-devel mono-complete mono-dbg referenceassemblies-pcl ca-certificates-mono mono-xsp4 mono-fastcgi-server4

WORKDIR /

COPY ./docker-entrypoint.sh /

EXPOSE 9000

STOPSIGNAL SIGQUIT

ENTRYPOINT [ "/bin/sh", "docker-entrypoint.sh" ]

