INSERT INTO issues (
            description,
            coordinates,
            term_of_elimination,
            image)
VALUES (
        @Description, 
        @Coordinates, 
        @TermOfElimination, 
        @Image)