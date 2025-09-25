UPDATE projects SET
                    name                    = @Name,
                    coordinates             = @Coordinates,
                    start_date              = @StartDate,
                    end_date                = @EndDate,
                    assigned_contractor_id  = @AssignedContractorId,
                    assigned_supervisor_id  = @AssignedSupervisorId,
                    updated_at              = CURRENT_TIMESTAMP
WHERE id = @Id;