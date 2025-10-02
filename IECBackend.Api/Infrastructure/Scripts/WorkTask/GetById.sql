SELECT
    id              AS Id,
    project_id      AS ProjectId,
    name            AS Name,
    planned_start   AS PlannedStart,
    planned_end     AS PlannedEnd,
    status          AS Status,
    created_at      AS CreatedAt,
    updated_at      AS UpdatedAt
FROM work_task WHERE id = @Id;