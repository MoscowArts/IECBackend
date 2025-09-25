UPDATE projects SET
                    name                    = @Name,
                    coordinates             = @Coordinates,
                    start_date              = @StartDate,
                    end_date                = @EndDate,
                    assigned_contractor_id  = @ConstractorId,
                    assigned_supervisor_id  = @SupervisorId,
                    updated_at              = CURRENT_TIMESTAMP
WHERE id = @Id;