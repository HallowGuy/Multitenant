# frontend/Dockerfile

# Étape de build
FROM node:20-alpine AS builder
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build

# Étape de production
FROM node:20-alpine AS runner
WORKDIR /app

ENV NODE_ENV=production

# Copie uniquement les fichiers nécessaires
COPY --from=builder /app/.next .next
COPY --from=builder /app/public public
COPY --from=builder /app/package.json package.json
COPY --from=builder /app/node_modules node_modules

EXPOSE 3000
CMD ["npx", "next", "start"]
