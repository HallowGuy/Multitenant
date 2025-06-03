# Fichier Makefile pour projet Multitenant

APP_NAME = multitenant
DOCKER_COMPOSE = docker-compose
MIGRATION_IMAGE = multitenant-migrations
NETWORK_NAME = multitenant_default

.PHONY: up down reset build rebuild build-migrations migrate new-migration logs ps clean-docker env-check status shell-backend shell-db logs-backend logs-postgres

# Vérifie si le fichier .env existe
env-check:
	@test -f .env || (echo "❌ Fichier .env manquant. Veuillez exécuter : cp .env.example .env" && exit 1)

# Démarre tous les services
up: env-check
	$(DOCKER_COMPOSE) up -d

# Stoppe tous les services
down:
	$(DOCKER_COMPOSE) down

# Stoppe et supprime les volumes (PostgreSQL notamment)
reset:
	$(DOCKER_COMPOSE) down -v

# Build complet (y compris si Dockerfile a changé)
build:
	$(DOCKER_COMPOSE) build

# Rebuild propre + restart
rebuild: reset build up

# Build de l’image dédiée aux migrations
build-migrations:
	docker build -f backend/Dockerfile.migrations -t $(MIGRATION_IMAGE) .

# Applique les migrations EF Core
migrate:
	docker run -it --rm --network=$(NETWORK_NAME) $(MIGRATION_IMAGE) dotnet ef database update

# Crée une nouvelle migration EF Core
new-migration:
	@read -p "Nom de la migration ? " name && \
	docker run -it --rm --network=$(NETWORK_NAME) $(MIGRATION_IMAGE) dotnet ef migrations add $$name

# Logs complets
logs:
	$(DOCKER_COMPOSE) logs -f

# Logs du backend uniquement
logs-backend:
	$(DOCKER_COMPOSE) logs -f backend

# Logs de PostgreSQL uniquement
logs-postgres:
	$(DOCKER_COMPOSE) logs -f postgres

# Statut des conteneurs
ps:
	$(DOCKER_COMPOSE) ps

# Nettoyage complet des images et conteneurs inutilisés
clean-docker:
	docker system prune -f

# Statut rapide
status:
	$(DOCKER_COMPOSE) ps

# Shell dans le conteneur backend
shell-backend:
	$(DOCKER_COMPOSE) exec backend /bin/bash

# Shell dans PostgreSQL (client psql)
shell-db:
	$(DOCKER_COMPOSE) exec -T postgres psql -U $$POSTGRES_USER -d $$POSTGRES_DB
