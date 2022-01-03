
SELECT Inventory.ProductID, ProductName, ProductPrice, ProductDescription FROM FullProductList
LEFT OUTER JOIN Inventory 
ON Inventory.ProductID = FullProductList.ProductID
LEFT OUTER JOIN StoresList
ON StoresList.StoreID = Inventory.StoreID
WHERE Inventory.StoreID = 1

SELECT * FROM FullProductList
SELECT * FROM Inventory

SELECT ProductID AS ProductID, ProductPrice AS ProductPrice FROM FullProductList 
WHERE ProductID = '1';

SELECT StoreID FROM StoresList AS storeID
SELECT * FROM Customer

INSERT INTO ShoppingCart(StoreID, CustomerID)
VALUES (
(SELECT StoreID FROM StoresList WHERE StoreID = 1), 
(SELECT CustomerID FROM Customer WHERE CustomerID = 1)
);

select * from ShoppingCart

INSERT INTO ItemsInCart(CartID, ProductID, ProductTotal) 
SELECT s.CartID, f.ProductID, f.ProductPrice
FROM ShoppingCart s
INNER JOIN Inventory i on s.StoreID = i.StoreID
INNER JOIN FullProductList f on i.ProductID = f.ProductID
where f.ProductID = 1

select * from ItemsInCart


