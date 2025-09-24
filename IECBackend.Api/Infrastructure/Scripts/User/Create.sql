INSERT INTO users (
                   password_hash,
                   full_name,
                   email,
                   phone,
                   role,
                   organization,
                   is_active,
                   created_at)
VALUES (
        @PasswordHash, 
        @Fullname, 
        @Email, 
        @Phone, 
        @Role, 
        @Organization,
        @IsActive,
        @CreatedAt)
    
RETURNING id;