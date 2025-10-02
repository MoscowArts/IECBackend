CREATE TABLE projects (
    id                          SERIAL PRIMARY KEY,
    name                        TEXT NOT NULL ,
    coordinates                 TEXT NOT NULL ,
    start_date                  DATE NOT NULL ,
    end_date                    DATE,
    assigned_contractor_id      INTEGER ,
    assigned_supervisor_id      INTEGER ,
    created_at                  TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at                  TIMESTAMP
);