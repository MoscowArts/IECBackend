SELECT id               AS Id,
       password_hash    AS PasswordHash,
       full_name        AS Fullname,
       email            AS Email,
       phone            AS Phone,
       role             AS Role,
       organization     AS Organization,
       is_active        AS IsActive,
       created_at       AS CreatedAt,
       updated_at       AS UpdatedAt
FROM users
WHERE email = @Email;