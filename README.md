# 🧱 Multitenant Middleware Project

Ce projet sert de couche d'abstraction **multitenant** pour une application initialement **monotenant**, en s’appuyant sur un modèle de **colonne `TenantId`** dans une base PostgreSQL.

> Technologies utilisées :  
> `.NET 9 (WebAPI)` · `PostgreSQL` · `Next.js` · `Kibana/Elasticsearch` · `Docker`

---

## 🔧 Structure du projet

/my-multitenant-wrapper
├── backend/ → API .NET 9 exposant les endpoints REST
├── frontend/ → Interface utilisateur Next.js
├── database/ → Scripts d'init PostgreSQL
├── observability/ → Elastic + Kibana pour les dashboards
├── docker-compose.yml
├── README.md

yaml
Copier
Modifier

---

## 🚀 Démarrage rapide

### 📦 Prérequis
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Git](https://git-scm.com/)
- (Facultatif) .NET SDK 9 & Node.js si lancement manuel

---

### ▶️ Lancer le projet

1. Clonez le dépôt :
```bash
git clone https://votre-repo-git.git
cd my-multitenant-wrapper
Lancer les services :


docker-compose up --build
Avant de démarrer, copiez le fichier `.env.example` vers `.env` et ajustez la variable
`ConnectionStrings__DefaultConnection`. Le backend lit **uniquement** cette
variable d'environnement pour se connecter à PostgreSQL.
Accès :

API Backend (.NET) : http://localhost:5000

Frontend (Next.js) : http://localhost:3000

PostgreSQL : localhost:5432, utilisateur dev, mot de passe devpass

Kibana : http://localhost:5601

🗂️ Fonctionnalité multitenant
Le système repose sur :

Un middleware .NET (TenantResolverMiddleware) qui extrait un identifiant de tenant depuis :

un sous-domaine, un header, ou un jeton JWT

Pour tester l'application vous pouvez :
* renseigner l'en-tête `X-Tenant-Id` dans vos requêtes HTTP
* utiliser un nom de domaine de la forme `tenant.votreapp.local`
* ou fournir un token JWT contenant la claim `tenant_id`

Toutes les requêtes vers la base sont automatiquement filtrées avec le TenantId

L’authentification et les droits peuvent être étendus par tenant

🛠 Environnement de développement
Pour reconstruire un service :


docker-compose build backend
Pour n’exécuter qu’un seul service :



docker-compose up frontend
📈 Observabilité
L’environnement Kibana permet de :

Visualiser les logs du backend

Tracer les appels API et erreurs

Créer des dashboards par tenant

📋 À faire
 Ajouter l’authentification (JWT ou Keycloak)

 Ajouter la persistance multitenant (ex. EF Core avec filtre global)

 Sécuriser les endpoints par tenant

 Intégrer la CI/CD (GitHub Actions, GitLab CI...)

👨‍💻 Auteur
Projet initialisé par Hadi ABDALLAH – Intalio France
Contact : +33 7 60 58 85 32