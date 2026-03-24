
CREATE DATABASE ProductDB;

USE ProductDB;




-- TABLE CREATION

CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);
GO

----------- INSERT STORED PROCEDURE---------------------

CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products (ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price);
END
GO

-------------- GET ALL PRODUCTS-----------------

CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price
    FROM Products;
END
GO


---------- UPDATE PRODUCT-------------------
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET 
        ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
END
GO


--------------- DELETE PRODUCT----------------

CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId;
END
GO
--------------Get Product Id-----------------------
CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price
    FROM Products
    WHERE ProductId = @ProductId;
END
GO
-- Insert---------
EXEC sp_InsertProduct 'Laptop', 'Electronics', 50000;
EXEC sp_InsertProduct 'Mobile', 'Electronics', 20000;


EXEC sp_GetAllProducts;


EXEC sp_UpdateProduct 1, 'Smart Mobile', 'Electronics', 25000;

EXEC sp_GetAllProducts;

EXEC sp_DeleteProduct 1;

EXEC sp_GetAllProducts;

