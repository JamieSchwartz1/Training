DROP TABLE Inventory
DROP TABLE Orders
DROP TABLE ItemsInCart
DROP TABLE ShoppingCart
DROP TABLE FullProductList
DROP TABLE StoresList
DROP TABLE Customer

--CREATE TABLES
CREATE TABLE Customer (
CustomerID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CustName nvarchar(30) NOT NULL, 
CustEmail nvarchar(45) NOT NULL,
CustPass nvarchar(45) NOT NULL)

CREATE TABLE StoresList (		--credit Craig Coles
StoreID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
StoreName nvarchar(25) NOT NULL)

CREATE TABLE FullProductList (
ProductID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
ProductName nvarchar(50) NOT NULL, 
ProductDescription nvarchar(75) NOT NULL,
ProductPrice decimal(6,2) NOT NULL)

-- the Cart
CREATE TABLE ShoppingCart(		--credit Craig Coles
CartID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
StoreID INT NOT NULL FOREIGN KEY REFERENCES StoresList(StoreID),
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
CartTotal decimal(6, 2))			-- sum ProductTotal

--able to add and delete single items from this table
CREATE TABLE ItemsInCart(		--credit Craig Coles
LineID uniqueidentifier PRIMARY KEY default NEWID(),
CartID INT NOT NULL FOREIGN KEY REFERENCES ShoppingCart(CartID),
ProductID INT NOT NULL FOREIGN KEY REFERENCES FullProductList(ProductID),
ProductTotal decimal(6, 2),		-- ProductPrice inserts into productTotal
ItemQuantity INT)

CREATE TABLE Orders(			--credit Craig Coles
OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
StoreID INT NOT NULL FOREIGN KEY REFERENCES StoresList(StoreID),
CartID INT NOT NULL FOREIGN KEY REFERENCES ShoppingCart(CartID),
OrderTotal decimal(6,2))

CREATE TABLE Inventory(			--credit Craig Coles
StoreID INT NOT NULL FOREIGN KEY REFERENCES StoresList(StoreID),
ProductID INT NOT NULL FOREIGN KEY REFERENCES FullProductList(ProductID),
ProductCount INT)

INSERT INTO StoresList VALUES ('Kiddie World')
INSERT INTO StoresList VALUES ('Scary City')
INSERT INTO StoresList VALUES ('Rich Penthouse')
INSERT INTO StoresList VALUES ('Rural Cabin')

INSERT INTO FullProductList
Values ('Lego Desk', 'DIY office space, instructions not included', 129.99)
INSERT INTO FullProductList
Values ('Metal Desk', 'More like a mortician''s table', 129.99)
INSERT INTO FullProductList
Values ('Raising Desk', 'If only it could raise your salary', 129.99)
INSERT INTO FullProductList
Values ('Wooden Desk', 'An heirloom that may or may not have woodmites', 129.99)
INSERT INTO FullProductList
Values ('Lego Chair', 'If it hurts to step on, it might hurt to sit on', 49.99)
INSERT INTO FullProductList
Values ('Metal Chair', 'It might leave marks on your floor', 49.99)
INSERT INTO FullProductList
Values ('Rolling Chair', 'Not for playing Go-Carts', 49.99)
INSERT INTO FullProductList
Values ('Wooden Chair', 'It doesn''t look all that sturdy', 49.99)
INSERT INTO FullProductList
Values ('Lego Lamp', 'How many legos does it take to screw in a light bulb?', 29.99)
INSERT INTO FullProductList
Values ('Metal Lamp', 'DON''T GO INTO THE LIGHT', 29.99)
INSERT INTO FullProductList
Values ('Smart Lamp', 'Clap on, clap off', 29.99)
INSERT INTO FullProductList
Values ('Antique Lamp', 'Make a wish, maybe a genie lives in there', 29.99)

--kiddie world inventory
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (1, 1, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (1, 5, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (1, 9, 10)

--Scary city inventory
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (2, 2, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (2, 6, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (2, 10, 10)

--Rich penthouse inventory
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (3, 3, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (3, 7, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (3, 11, 10)

--Rural Cabin inventory
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (4, 4, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (4, 8, 10)
INSERT INTO Inventory (StoreID, ProductID, ProductCount) 
VALUES (4, 12, 10)

INSERT INTO Customer VALUES ('jamie', 'email', 'test1')