
SELECT Inventory.ProductID, ProductName, ProductPrice, ProductDescription FROM FullProductList
LEFT OUTER JOIN Inventory 
ON Inventory.ProductID = FullProductList.ProductID
LEFT OUTER JOIN StoresList
ON StoresList.StoreID = Inventory.StoreID
WHERE Inventory.StoreID = 1

SELECT * FROM FullProductList

SELECT StoreID FROM StoresList AS storeID
SELECT CustomerID FROM Customer AS custID

INSERT INTO ShoppingCart(StoreID, CustomerID)
VALUES (
(SELECT StoreID FROM StoresList WHERE StoreID = 1), 
(SELECT CustomerID FROM Customer WHERE CustomerID = 1)
);

select * from ShoppingCart;