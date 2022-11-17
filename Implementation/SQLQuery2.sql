USE master;
GO
DROP DATABASE IF EXISTS GemueseHaendler;
CREATE DATABASE GemueseHaendler;
Go
Use GemueseHaendler;
GO
DROP TABLE IF EXISTS Vegetable_Origin;
CREATE TABLE Vegetable_Origin (
	Herkunft_ID int NOT NULL IDENTITY PRIMARY KEY,
	Vegetable_Origin CHAR(50) NOT NULL
); 

DROP TABLE IF EXISTS Vegetables;
CREATE TABLE Vegetables (
	Produkt_ID int NOT NULL IDENTITY PRIMARY KEY,
	Vegetable_Name CHAR(50) NOT NULL,
	Vegetable_Price_KG decimal(5,2) NOT NULL,
	Herkunft_ID int,
	FOREIGN KEY (Herkunft_ID) REFERENCES Vegetable_Origin (Herkunft_ID)
);
