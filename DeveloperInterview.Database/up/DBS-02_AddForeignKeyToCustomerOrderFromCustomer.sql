DELETE co
FROM dbo.CustomerOrder co
WHERE co.CustomerId > (SELECT MAX(c.Id) from dbo.Customer c)

ALTER TABLE dbo.CustomerOrder
ADD	CONSTRAINT FK_CustomerOrderId
FOREIGN KEY (CustomerId)
REFERENCES dbo.Customer(Id)
