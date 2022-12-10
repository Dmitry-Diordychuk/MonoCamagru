#adduser nginx
#addgroup nginx
#chown -R nginx:nginx /var/www/html

# openssl req \
# 		-x509 \
# 		-nodes \
# 		-days 365 \
# 		-subj "/C=RU/ST=Moscow/O=42School, Inc./OU=IT/CN=kdustin.42.fr" \
# 		-addext "subjectAltName=DNS:kdustin.42.fr" \
# 		-newkey rsa:2048 \
# 		-keyout /etc/ssl/private/nginx-selfsigned.key \
# 		-out /etc/ssl/certs/nginx-selfsigned.crt;

sed -i -e "s/<MONO IP>/$(dig +short mono):${MONO_PORT}/g" /etc/nginx/nginx.conf

nginx -g "daemon off;"
