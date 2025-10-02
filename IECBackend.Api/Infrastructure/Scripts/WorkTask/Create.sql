INSERT INTO work_task (
    project_id,
    name,
    planned_start,
    planned_end,
    status)
VALUES (
           @ProjectId,
           @Name,
           @PlannedStart,
           @PlannedEnd,
           @Status);