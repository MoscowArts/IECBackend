UPDATE users 
SET password_hash   = @PasswordHash,
    full_name       = @Fullname,
    email           = @Email,
    phone           = @Phone
WHERE id = @Id;