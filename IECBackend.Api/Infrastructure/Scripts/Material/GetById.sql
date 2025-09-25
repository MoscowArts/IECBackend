SELECT
    id              AS Id,
    name            AS Name,
    project_id      AS ProjectId,
    volume          AS Volume,
    unit            AS Unit,
    delivery_date   AS DeliveryDate,
    created_at      AS CreatedAt
FROM materials WHERE id = @Id;