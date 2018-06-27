SELECT DISTINCT c.Id, c.FirstName+' '+c.LastName AS 'Names of People without Orders'
FROM dbo.Customer c
LEFT JOIN dbo.CustomerOrder co ON c.Id = co.CustomerId
WHERE co.Id IS NULL