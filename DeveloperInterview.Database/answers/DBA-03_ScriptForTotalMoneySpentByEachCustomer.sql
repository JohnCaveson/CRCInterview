SELECT DISTINCT c.FirstName+' '+c.LastName as FullName, SUM(p.Price) as TotalSpent
FROM dbo.Customer c
JOIN dbo.CustomerOrder co ON c.Id = co.CustomerId
JOIN dbo.OrderProduct op ON co.Id = op.CustomerOrderId
JOIN dbo.Product p on op.ProductId = p.Id
GROUP BY c.FirstName+' '+c.LastName, p.Price
ORDER BY TotalSpent