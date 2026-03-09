CREATE DATABASE SalesReportDB;
USE SalesReportDB;
------------Problem 1: Stored Procedures and User-Defined Functions-------------

CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

INSERT INTO stores (store_name) VALUES
('Hyderabad Store'),
('Bangalore Store'),
('Chennai Store'),
('Mumbai Store');

CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    price DECIMAL(10,2)
);

INSERT INTO products (product_name, price) VALUES
('Laptop', 55000),
('Mobile', 20000),
('Headphones', 3000),
('Tablet', 25000),
('Smart Watch', 7000),
('Keyboard', 1500);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    customer_name VARCHAR(100)
);

INSERT INTO customers (customer_name) VALUES
('Lavi'),
('Indu'),
('Kalyan'),
('Sudha'),
('Anji');

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    store_id INT,
    order_date DATE,
    total_amount DECIMAL(10,2),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orders (customer_id, store_id, order_date, total_amount) VALUES
(1,1,'2024-01-10',55000),
(2,2,'2024-02-15',20000),
(3,1,'2024-03-05',3000),
(4,3,'2024-03-20',25000),
(5,4,'2024-04-02',7000),
(1,2,'2024-04-18',1500);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO order_items (order_id, product_id, quantity) VALUES
(1,1,1),
(2,2,2),
(3,3,3),
(4,4,1),
(5,5,2),
(6,6,4);
------------- Create a stored procedure to generate total sales amount per store.

CREATE PROCEDURE sp_TotalSalesPerStore
    @StoreID INT
AS
BEGIN
    SELECT 
        s.store_id,
        s.store_name,
        SUM(ISNULL(o.total_amount,0)) AS TotalSales
    FROM stores s
    LEFT JOIN orders o 
        ON s.store_id = o.store_id
    WHERE s.store_id = @StoreID
    GROUP BY s.store_id, s.store_name
END

EXEC sp_TotalSalesPerStore @StoreID = 1;
-------------- Create a stored procedure to retrieve orders by date range.----------

CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        customer_id,
        order_date,
        total_amount
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
END

EXEC sp_GetOrdersByDateRange 
    @StartDate = '2024-01-01',
    @EndDate = '2024-12-31';

   ---- -- Create a scalar function to calculate total price after discount.--------------
    CREATE FUNCTION fn_CalculateDiscountPrice
(
    @Price DECIMAL(10,2),
    @DiscountPercent DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @FinalPrice DECIMAL(10,2)

    SET @FinalPrice = @Price - (@Price * ISNULL(@DiscountPercent,0) / 100)

    RETURN @FinalPrice
END

SELECT 
product_name,
price,
dbo.fn_CalculateDiscountPrice(price,10) AS DiscountPrice
FROM products;

------------ Create a table-valued function to return top 5 selling products.-----------

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS TotalSold
    FROM order_items oi
    JOIN products p
        ON oi.product_id = p.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY TotalSold DESC
)

SELECT * 
FROM dbo.fn_Top5SellingProducts();

-------------------------------------------------------
-------------Problem 2: Stock Auto-Update Trigger--------

USE SalesReportDB;
CREATE TABLE stocks (
    product_id INT PRIMARY KEY,
    quantity INT NOT NULL,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO stocks (product_id, quantity) VALUES
(1,20),
(2,15),
(3,30),
(4,10),
(5,25),
(6,40);
USE SalesReportDB;

CREATE TRIGGER trg_UpdateStock1
ON order_items
AFTER INSERT
AS
BEGIN
BEGIN TRY

UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM stocks s
JOIN inserted i
ON s.product_id = i.product_id;

IF EXISTS (
SELECT 1
FROM stocks
WHERE quantity < 0
)
BEGIN
RAISERROR ('Stock is insufficient for this product',16,1);
ROLLBACK TRANSACTION;
END

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
THROW;
END CATCH

END;

INSERT INTO order_items (order_id, product_id, quantity)
VALUES (1,1,5);

SELECT * FROM stocks;


------------------------------------------------

-----------------Problem 3: Order Status Validation Trigger--------
CREATE TABLE orders1 (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    order_date DATE,
    shipped_date DATE,
    order_status INT
);

INSERT INTO orders1 (order_date, shipped_date, order_status) VALUES
('2024-01-10', NULL, 1),
('2024-02-15', '2024-02-20', 2),
('2024-03-05', NULL, 3);


CREATE TRIGGER trg_ValidateOrderStatus1
ON orders1
AFTER UPDATE
AS
BEGIN
BEGIN TRY

IF EXISTS (
SELECT 1
FROM inserted
WHERE order_status = 4 AND shipped_date IS NULL
)
BEGIN
RAISERROR ('Cannot set order status to Completed without shipped date',16,1);
ROLLBACK TRANSACTION;
END

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
THROW;
END CATCH

END;

UPDATE orders1
SET order_status = 4
WHERE order_id = 1;

UPDATE orders1
SET shipped_date = '2024-03-10',
order_status = 4
WHERE order_id = 3;