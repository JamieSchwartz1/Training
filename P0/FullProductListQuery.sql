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
CartTotal decimal(6, 2) NOT NULL)			-- sum ProductTotal

--able to add and delete single items from this table
CREATE TABLE ItemsInCart(		--credit Craig Coles
CartItemID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CartID INT NOT NULL FOREIGN KEY REFERENCES ShoppingCart(CartID),
LineID uniqueidentifier NOT NULL,
ProductID INT NOT NULL FOREIGN KEY REFERENCES FullProductList(ProductID),
ProductTotal decimal(6, 2) NOT NULL,		-- ProductPrice inserts into productTotal
ItemQuantity INT NOT NULL)

CREATE TABLE Orders(			--credit Craig Coles
OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customer(CustomerID),
StoreID INT NOT NULL FOREIGN KEY REFERENCES StoresList(StoreID),
CartID INT NOT NULL FOREIGN KEY REFERENCES ShoppingCart(CartID),
OrderTotal decimal(6,2) NOT NULL)

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

INSERT INTO Inventory VALUES (1, 1, 20)
INSERT INTO Inventory VALUES (2, 2, 11)
INSERT INTO Inventory VALUES (3, 3, 15)
INSERT INTO Inventory VALUES (4, 4, 5)
INSERT INTO Inventory VALUES (1, 5, 20)
INSERT INTO Inventory VALUES (2, 6, 11)
INSERT INTO Inventory VALUES (3, 7, 15)
INSERT INTO Inventory VALUES (4, 8, 5)
INSERT INTO Inventory VALUES (1, 9, 20)
INSERT INTO Inventory VALUES (2, 10, 11)
INSERT INTO Inventory VALUES (3, 11, 15)
INSERT INTO Inventory VALUES (4, 12, 5)

