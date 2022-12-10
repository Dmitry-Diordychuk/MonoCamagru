# adduser nginx
# addgroup nginx
# chown -R nginx:nginx /var/www/html

# nginx -g "daemon off;"

fastcgi-mono-server4 --applications=/:/var/www/www.monocamagru.ru/ --socket=tcp:0.0.0.0:9000 --loglevels=Debug --printlog
#fastcgi-mono-server4 /applications=www.monocamagru.ru:/:/var/www/www.monocamagru.ru/ /socket=tcp:0.0.0.0:9000 --loglevels=All --printlog --verbose

#nc -l -p 9000
