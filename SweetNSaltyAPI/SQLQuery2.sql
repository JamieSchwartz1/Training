CREATE DATABASE SweetnSalty;


CREATE TABLE Person
(
	PersonID int PRIMARY KEY NOT NULL IDENTITY (1,1),
	Fname nvarchar(20),
	Lname nvarchar(20),
);

CREATE TABLE Flavor
(
	FlavorID int PRIMARY KEY NOT NULL IDENTITY (1,1),
	FlavorName nvarchar(30)
);

CREATE TABLE PersonFlavorJunction
(
	PersonID INT NOT NULL FOREIGN KEY REFERENCES Person(PersonID),
	FlavorID INT NOT NULL FOREIGN KEY REFERENCES Flavor(FlavorID)
);