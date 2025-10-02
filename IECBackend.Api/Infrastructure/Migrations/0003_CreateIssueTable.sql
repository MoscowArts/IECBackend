CREATE TABLE issues (
                       id                     SERIAL PRIMARY KEY,
                       projectId              INTEGER,
                       description            TEXT NOT NULL,
                       coordinates            TEXT NOT NULL,
                       term_of_elimination    TIMESTAMP NOT NULL,
                       image                  TEXT,
                       created_at             TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                       updated_at             TIMESTAMP
);