CREATE TABLE materials (
                           id              SERIAL PRIMARY KEY,
                           name            TEXT NOT NULL,
                           project_id      INTEGER NOT NULL REFERENCES projects(id),
                           volume          DECIMAL(10,2) NOT NULL CHECK (volume > 0),
                           unit            TEXT NOT NULL,
                           delivery_date   DATE NOT NULL,
                           created_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);