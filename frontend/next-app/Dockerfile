# Étape de build pour Next.js
FROM node:20-alpine AS builder
WORKDIR /app

COPY package.json ./
COPY package-lock.json ./
RUN npm install

COPY . .
RUN npm run build

# Étape de production minimale
FROM node:20-alpine
WORKDIR /app

COPY --from=builder /app . 
ENV NODE_ENV=production
EXPOSE 3000
CMD ["npm", "start"]
