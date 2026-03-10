CREATE DATABASE TransactionsDb;
USE TransactionsDb;

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    stock_quantity INT NOT NULL
);

INSERT INTO products (product_id, product_name, stock_quantity) VALUES
(1,'Laptop',10),
(2,'Mobile',25),
(3,'Tablet',15),
(4,'Headphones',30),
(5,'Smart Watch',20);

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    order_date DATETIME DEFAULT GETDATE()
);
INSERT INTO orders (order_date) VALUES
(GETDATE()),
(GETDATE()),
(GETDATE());

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO order_items (order_id, product_id, quantity) VALUES
(1,1,2),
(1,2,3),
(2,3,1),
(2,4,5),
(3,5,2);

SELECT * FROM products;
SELECT * FROM orders;
SELECT * FROM order_items;

------ Create a trigger to reduce stock quantity after order insertion.-----

CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN

    -- Check if stock is insufficient
    IF EXISTS (
        SELECT 1
        FROM products p
        JOIN inserted i 
        ON p.product_id = i.product_id
        WHERE p.stock_quantity < i.quantity
    )
    BEGIN
        RAISERROR ('Insufficient stock',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE p
    SET p.stock_quantity = p.stock_quantity - i.quantity
    FROM products p
    JOIN inserted i
    ON p.product_id = i.product_id;

END;

----- Rollback transaction if stock quantity is insufficient.----------

BEGIN TRY

BEGIN TRANSACTION

DECLARE @OrderID INT

-- Insert order
INSERT INTO orders DEFAULT VALUES

SET @OrderID = SCOPE_IDENTITY()

-- Insert order items
INSERT INTO order_items (order_id, product_id, quantity)
VALUES
(@OrderID,1,2),
(@OrderID,2,3)

COMMIT TRANSACTION

PRINT 'Order placed successfully'

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Order failed due to insufficient stock'

END CATCH

INSERT INTO order_items (order_id, product_id, quantity)
VALUES (1,1,2);
SELECT * FROM products;

--Task 2-------------------------------------------
--2 Problem 2: Atomic Order Cancellation with SAVEPOINT-------------
USE TransactionsDb;

ALTER TABLE orders
ADD order_status INT DEFAULT 1;

BEGIN TRY

BEGIN TRANSACTION

DECLARE @OrderID INT = 1

-- SAVEPOINT
SAVE TRANSACTION BeforeStockRestore

-- Restore stock
UPDATE p
SET p.stock_quantity = p.stock_quantity + oi.quantity
FROM products p
JOIN order_items oi
ON p.product_id = oi.product_id
WHERE oi.order_id = @OrderID

-- Update order status
UPDATE orders
SET order_status = 3
WHERE order_id = @OrderID

COMMIT TRANSACTION

PRINT 'Order cancelled successfully'

END TRY

BEGIN CATCH

PRINT 'Error occurred during cancellation'
PRINT ERROR_MESSAGE()

ROLLBACK TRANSACTION BeforeStockRestore

ROLLBACK TRANSACTION

END CATCH

SELECT * FROM products;

SELECT order_id, order_status 
FROM orders;

SELECT * FROM order_items;