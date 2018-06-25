WITH CTE AS(
  select ProductId, CustomerOrderId, RN = ROW_NUMBER() OVER(PARTITION BY CustomerOrderId, ProductId ORDER BY ProductId)
  from dbo.OrderProduct
)
DELETE FROM CTE WHERE RN > 1

ALTER TABLE dbo.OrderProduct
ADD CONSTRAINT UQ_CustomerOrderId_OrderId UNIQUE(CustomerOrderId, ProductId)
