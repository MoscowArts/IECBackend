SELECT
    id                      AS ID,
    name                    AS Name,
    coordinates             AS Coordinates,
    start_date              AS StartDate,
    end_date                AS EndDate,
    assigned_contractor_id  AS ConstractorId,
    assigned_supervisor_id  AS SupervisorId,
    created_at              AS CreatedAt,
    updated_at              AS UpdatedAt
FROM projects WHERE id = @Id;