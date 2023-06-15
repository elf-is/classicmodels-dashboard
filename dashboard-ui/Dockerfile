FROM node:latest AS build
WORKDIR /app
COPY package.json yarn.lock ./
RUN npm i -g @angular/cli@14.2.11
RUN yarn --dev
COPY . .
RUN yarn build

FROM nginx:latest AS final
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/dist/dashboard-ui/ /usr/share/nginx/html
EXPOSE 80
