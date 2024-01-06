# Stage 1: Build the application
FROM node:latest AS builder
WORKDIR /app
COPY package*.json ./
RUN yarn install
COPY . .

FROM node:alpine
WORKDIR /app
COPY --from=builder /app /app
EXPOSE 5173
CMD ["yarn", "dev"]