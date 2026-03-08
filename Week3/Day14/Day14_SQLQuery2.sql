CREATE DATABASE AutoDb;
USE AutoDb;
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2)
);
INSERT INTO products (product_name, category_id, model_year, list_price) VALUES
('Mountain Bike',1,2018,800),
('Road Bike',1,2019,1200),
('Hybrid Bike',1,2020,1000),
('Electric Scooter',2,2019,1500),
('Electric Bike',2,2020,2000),
('Mini Scooter',2,2018,900),
('Kids Bicycle',3,2017,300),
('Teen Bicycle',3,2018,450),
('Sports Bicycle',3,2019,700);

SELECT 
    product_name + ' (' + CAST(model_year AS VARCHAR) + ')' AS Product_Details,
    list_price,
    list_price -
    (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS Price_Difference
FROM products p1
WHERE list_price >
(
    SELECT AVG(list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
);
--------------------------------------------------------------------------

CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
INSERT INTO customers (first_name, last_name) VALUES
('Lavanya','Neela'),
('Indu','Reddy'),
('Sudha','Rani'),
('Kalyan','Pavan'),
('Anji','Raj');

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_value DECIMAL(10,2)
);
INSERT INTO orders (customer_id, order_value) VALUES
(1,6000),
(1,5000),
(2,3000),
(2,1500),
(3,12000),
(4,4000);
USE AutoDb;
SELECT*FROM orders;

----1. Use nested query to calculate total order value per customer.-------------
SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS Full_Name,
    (
        SELECT SUM(o.order_value)
        FROM orders o
        WHERE o.customer_id = c.customer_id
    ) AS Total_Order_Value
FROM customers c;

----2. Classify customers using conditional logic:
   ---- 'Premium' if total order value > 10000
   ---- 'Regular' if total order value between 5000 and 10000
   ---- 'Basic' if total order value < 5000


SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS Full_Name,
    (
        SELECT SUM(o.order_value)
        FROM orders o
        WHERE o.customer_id = c.customer_id
    ) AS Total_Order_Value,
    
    CASE
        WHEN (
            SELECT SUM(o.order_value)
            FROM orders o
            WHERE o.customer_id = c.customer_id
        ) > 10000 THEN 'Premium'
        
        WHEN (
            SELECT SUM(o.order_value)
            FROM orders o
            WHERE o.customer_id = c.customer_id
        ) BETWEEN 5000 AND 10000 THEN 'Regular'
        
        WHEN (
            SELECT SUM(o.order_value)
            FROM orders o
            WHERE o.customer_id = c.customer_id
        ) < 5000 THEN 'Basic'
        
        ELSE 'No Orders'
    END AS Customer_Type

FROM customers c;
---3. Use UNION to display customers with orders and customers without orders.----

SELECT 
    c.first_name + ' ' + c.last_name AS Full_Name,
    SUM(o.order_value) AS Total_Order_Value
FROM customers c
JOIN orders o
ON c.customer_id = o.customer_id
GROUP BY c.first_name, c.last_name

UNION

SELECT 
    c.first_name + ' ' + c.last_name AS Full_Name,
    0 AS Total_Order_Value
FROM customers c
WHERE c.customer_id NOT IN
(
    SELECT customer_id FROM orders
);

-----4. Display full name using string concatenation.---
SELECT 
    first_name + ' ' + last_name AS Full_Name
FROM customers;

--------5. Handle NULL cases appropriately.-----------
SELECT 
    c.first_name + ' ' + c.last_name AS Full_Name,
    
    ISNULL(
        (SELECT SUM(o.order_value)
         FROM orders o
         WHERE o.customer_id = c.customer_id), 0
    ) AS Total_Order_Value

FROM customers c;

--------------------------------------------------------------------------------
CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

INSERT INTO stores (store_name) VALUES
('Hyderabad Store'),
('Chennai Store'),
('Bangalore Store');

CREATE TABLE products1 (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

INSERT INTO products1 (product_name, list_price) VALUES
('Mountain Bike',800),
('Road Bike',1200),
('Electric Scooter',1500);

CREATE TABLE orders1 (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT
);
INSERT INTO orders1 (store_id) VALUES
(1),
(1),
(2),
(3);
CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(10,2)
);
INSERT INTO order_items (order_id, product_id, quantity, discount) VALUES
(1,1,2,50),
(2,2,1,100),
(3,1,1,20),
(4,3,3,150);
CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT
);
INSERT INTO stocks (store_id, product_id, quantity) VALUES
(1,1,0),
(1,2,5),
(2,1,0),
(3,3,10);
-------------1. Identify products sold in each store using nested queries.------
SELECT 
    s.store_name,
    p.product_name,
    t.total_quantity_sold
FROM
(
    SELECT 
        o.store_id,
        oi.product_id,
        SUM(oi.quantity) AS total_quantity_sold
    FROM orders1 o
    JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY o.store_id, oi.product_id
) t
JOIN stores s 
    ON s.store_id = t.store_id
JOIN products1 p 
    ON p.product_id = t.product_id;

   --- 2. Compare sold products with current stock using INTERSECT and EXCEPT operators.

    SELECT product_id
FROM order_items

INTERSECT

SELECT product_id
FROM stocks
WHERE quantity > 0;
-----3. Display store_name, product_name, total quantity sold.

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold
FROM stores s
JOIN orders1 o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products1 p 
    ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name;

---4. Calculate total revenue per product (quantity × list_price – discount).

SELECT 
    s.store_name,
    p.product_name,
    SUM((oi.quantity * p.list_price) - oi.discount) AS total_revenue
FROM stores s
JOIN orders1 o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products1 p 
    ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name;
----5. Update stock quantity to 0 for discontinued products (simulation).----

UPDATE stocks
SET quantity = 0
WHERE product_id IN
(
    SELECT oi.product_id
    FROM order_items oi
    EXCEPT
    SELECT product_id
    FROM stocks
    WHERE quantity > 0
);

--------------------------------------------------------------
CREATE TABLE customers1 (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
INSERT INTO customers1 (first_name, last_name) VALUES
('Rahul','Sharma'),
('Priya','Reddy'),
('Arjun','Kumar'),
('Sneha','Patel');

CREATE TABLE orders2 (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT
);
INSERT INTO orders2 
(customer_id, order_date, required_date, shipped_date, order_status)
VALUES
(1,'2023-01-10','2023-01-15','2023-01-14',2),
(1,'2024-02-05','2024-02-10','2024-02-11',2),
(2,'2022-01-05','2022-01-10','2022-01-09',3),
(3,'2023-03-01','2023-03-05','2023-03-04',2),
(4,'2022-02-01','2022-02-05','2022-02-06',3);

-----1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    order_status INT
);





----2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
DELETE FROM orders2
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());
SELECT * FROM orders1;

---3. Use nested query to identify customers whose all orders are completed.--
SELECT customer_id
FROM orders2 o
WHERE NOT EXISTS
(
    SELECT *
    FROM orders1
    WHERE customer_id = o.customer_id
    AND order_status <> 1
);
-----4. Display order processing delay (DATEDIFF between shipped_date and order_date).
SELECT 
    order_id,
    order_date,
    shipped_date,
    DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders2;

----5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.
SELECT 
    order_id,
    order_date,
    required_date,
    shipped_date,
    CASE
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status
FROM orders2;