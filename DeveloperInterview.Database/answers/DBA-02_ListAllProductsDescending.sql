SELECT p.Id, p.Name, SUM(op.Quantity) AS ItemCount
FROM dbo.Product p
JOIN dbo.OrderProduct op
ON p.Id = op.ProductId
GROUP BY p.Name, p.Id
ORDER BY ItemCount DESC