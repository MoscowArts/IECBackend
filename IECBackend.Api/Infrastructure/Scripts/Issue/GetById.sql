SELECT id                   AS Id,
       description          AS Description,
       coordinates          AS Coordinates,
       term_of_elimination  AS TermOfElimination,
       image                AS Image,
       created_at           AS CreatedAt,
       updated_at           AS UpdatedAt
FROM issues
WHERE id = @Id;