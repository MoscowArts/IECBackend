CREATE TABLE work_task (
                           id              SERIAL PRIMARY KEY,
                           project_id      INTEGER NOT NULL REFERENCES projects(id),
                           name            TEXT NOT NULL,
                           planned_start   DATE NOT NULL,
                           planned_end     DATE NOT NULL,
                           status          TEXT NOT NULL,
                           created_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                           updated_at      TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);