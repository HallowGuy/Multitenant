-- docker/postgres/init.sql

-- 1. Extension pour les UUID
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE EXTENSION IF NOT EXISTS "pgcrypto";

-- 2. Création de la table "Tenants"
CREATE TABLE IF NOT EXISTS "Tenants" (
  "Id" UUID PRIMARY KEY,
  "Name" TEXT NOT NULL,
  "CreatedAt" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

ALTER TABLE "Tenants" ADD CONSTRAINT unique_name UNIQUE ("Name");
-- 3. Insertion de deux tenants de test
INSERT INTO "Tenants" ("Id", "Name")
VALUES 
  ('11111111-1111-1111-1111-111111111111', 'Default Tenant'),
  ('22222222-2222-2222-2222-222222222222', 'Another Tenant')
ON CONFLICT DO NOTHING;
