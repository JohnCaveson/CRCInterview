SELECT DISTINCT c.Id, c.FirstName+' '+c.LastName as FullName, SUM(p.Price) AS TotalSum
FROM dbo.Customer c
LEFT JOIN dbo.CustomerOrder co ON c.Id = co.CustomerId
LEFT JOIN dbo.OrderProduct op ON co.Id = op.CustomerOrderId
LEFT JOIN dbo.Product p ON op.ProductId = p.Id
GROUP BY c.Id, FirstName+' '+LastName
ORDER BY TotalSum DESC