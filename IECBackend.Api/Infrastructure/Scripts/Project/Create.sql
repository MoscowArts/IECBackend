INSERT INTO projects (
    name,
    coordinates,
    start_date,
    end_date,
    assigned_contractor_id,
    assigned_supervisor_id)
VALUES (
           @Name,
           @Coordinates,
           @StartDate,
           @EndDate,
           @AssignedContractorId,
           @AssignedSupervisorId);