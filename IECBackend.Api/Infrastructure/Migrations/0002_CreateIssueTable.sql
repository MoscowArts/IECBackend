CREATE TABLE issues (
                       id                     SERIAL PRIMARY KEY,
                       description            TEXT NOT NULL,
                       coordinates            TEXT NOT NULL,
                       term_of_elimination    TIMESTAMP NOT NULL,
                       image                  BYTEA ,
                       created_at             TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                       updated_at             TIMESTAMP
);