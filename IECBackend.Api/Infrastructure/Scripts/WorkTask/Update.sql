UPDATE work_task SET
                     project_id      = @ProjectId,
                     name            = @Name,
                     planned_start   = @PlannedStart,
                     planned_end     = @PlannedEnd,
                     status          = @Status,
                     updated_at      = CURRENT_TIMESTAMP
WHERE id = @Id;