UPDATE materials SET
                     name           = @Name,
                     project_id     = @ProjectId,
                     volume         = @Volume,
                     unit           = @Unit,
                     delivery_date  = @DeliveryDate
WHERE id = @Id;