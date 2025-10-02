UPDATE issues 
SET description             = @Description,
    coordinates             = @Coordinates,
    term_of_elimination     = @TermOfElimination,
    image                   = @Image,
    updated_at              = CURRENT_TIMESTAMP
WHERE id = @Id;