SELECT p.Name, op.Quantity
FROM dbo.Product p
JOIN dbo.OrderProduct op
ON p.Id = op.ProductId