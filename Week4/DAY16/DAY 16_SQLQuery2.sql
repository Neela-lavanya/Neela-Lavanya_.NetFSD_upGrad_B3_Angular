--Level-2 Problem 3: Cursor-Based Revenue Calculation-----

USE SalesReportDB;
CREATE TABLE storess (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

INSERT INTO stores (store_name) VALUES
('Hyderabad Store'),
('Bangalore Store'),
('Chennai Store');

CREATE TABLE orderss (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
INSERT INTO orderss (store_id, order_status) VALUES
(1,4),
(1,4),
(2,4),
(3,3),
(2,4);
CREATE TABLE productss (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    price DECIMAL(10,2)
);
INSERT INTO products (product_name, price) VALUES
('Laptop',55000),
('Mobile',20000),
('Headphones',3000),
('Tablet',25000);
CREATE TABLE order_itemss (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(5,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO order_itemss (order_id, product_id, quantity, discount) VALUES
(1,1,1,10),
(1,3,2,5),
(2,2,1,5),
(3,1,1,8),
(5,4,1,10);

BEGIN TRY

BEGIN TRANSACTION

-- Temporary table to store revenue
CREATE TABLE #RevenueTemp (
    store_id INT,
    order_id INT,
    revenue DECIMAL(10,2)
)

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(10,2)

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orderss
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

SELECT @revenue =
SUM((p.price * oi.quantity) - ((p.price * oi.quantity) * oi.discount /100))
FROM order_itemss oi
JOIN products p
ON oi.product_id = p.product_id
WHERE oi.order_id = @order_id

INSERT INTO #RevenueTemp
VALUES (@store_id, @order_id, @revenue)

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor

-- Store wise revenue summary
SELECT store_id,
SUM(revenue) AS TotalRevenue
FROM #RevenueTemp
GROUP BY store_id

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION
PRINT 'Error occurred during revenue calculation'

END CATCH