INSERT INTO materials (
    name,
    project_id,
    volume,
    unit,
    delivery_date)
VALUES (
           @Name,
           @ProjectId,
           @Volume,
           @Unit,
           @DeliveryDate);