CREATE TABLE users (
                       id              SERIAL PRIMARY KEY,
                       password_hash   TEXT NOT NULL,
                       full_name       TEXT NOT NULL,
                       email           TEXT UNIQUE,
                       phone           TEXT,
                       role            TEXT,
                       organization    TEXT,
                       is_active       BOOLEAN DEFAULT TRUE,
                       created_at      TIMESTAMP,
                       updated_at      TIMESTAMP
);