FROM nginx:alpine
ARG source
RUN mkdir /app
WORKDIR /app
COPY ${source:-dist} ./
COPY ${source:-env}/nginx.conf /etc/nginx/conf.d/default.conf
RUN ln -sf /dev/stdout /var/log/nginx/access.log; ln -sf /dev/stderr /var/log/nginx/error.log
CMD ["nginx", "-g", "daemon off;"]