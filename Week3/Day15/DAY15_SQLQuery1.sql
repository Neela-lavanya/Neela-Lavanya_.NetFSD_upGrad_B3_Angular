CREATE DATABASE EcommDb;
USE EcommDb;
CREATE TABLE categories(
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100) NOT NULL
);

INSERT INTO categories (category_name) VALUES
('Sedan Cars'),
('Sports Bikes'),
('SUV Vehicles'),
('Electric Vehicles'),
('Car Accessories');

CREATE TABLE brands(
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(100) NOT NULL
);

INSERT INTO brands (brand_name) VALUES
('Hyundai'),
('Kawasaki'),
('Mahindra'),
('Tata'),
('Audi');

CREATE TABLE products(
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

INSERT INTO products (product_name, brand_id, category_id, model_year, list_price) VALUES
('Hyundai Verna',1,1,2023,18000),
('Kawasaki Ninja',2,2,2022,15000),
('Mahindra Scorpio',3,3,2024,22000),
('Tata Nexon EV',4,4,2023,20000),
('Audi Q7',5,3,2024,75000);

CREATE TABLE customers(
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(15)
);
INSERT INTO customers (first_name, last_name, city, phone) VALUES
('Anji','Kumar','Hyderabad','9000001111'),
('Lavanya','Reddy','Bangalore','9000002222'),
('Indu','Priya','Chennai','9000003333'),
('Sudha','Lakshmi','Hyderabad','9000004444'),
('Likitha','Rao','Vijayawada','9000005555'),
('Anvitha','Sai','Guntur','9000006666'),
('Anusha','Devi','Warangal','9000007777'),
('Kalyan','Varma','Vizag','9000008888');

CREATE TABLE stores(
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100),
    city VARCHAR(50)
);
INSERT INTO stores (store_name, city) VALUES
('Anji Auto Mart','Hyderabad'),
('Lavanya Vehicles','Bangalore'),
('Indu Car World','Chennai'),
('Sudha Motors','Vijayawada'),
('Kalyan Auto Hub','Vizag');

---- Write SELECT queries to retrieve all products with their brand and category names.
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

-----Retrieve all customers from a specific city.----

SELECT *
FROM customers
WHERE city = 'Hyderabad';

----- Display total number of products available in each category.
SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p 
ON c.category_id = p.category_id
GROUP BY c.category_name;

--------------------------------------------------------------
CREATE VIEW vw_ProductDetails AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

DROP VIEW vw_ProductDetails;

CREATE VIEW vw_ProductDetails AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;





SELECT * FROM INFORMATION_SCHEMA.TABLES

CREATE TABLE orders (
order_id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT,
order_date DATE,
store_id INT,
staff_id INT,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO orders (customer_id,order_date,store_id,staff_id) VALUES
(1,'2024-02-10',1,1),
(2,'2024-02-11',2,2),
(3,'2024-02-12',3,3),
(4,'2024-02-13',4,4),
(5,'2024-02-14',5,5);

CREATE TABLE staffs (
staff_id INT PRIMARY KEY IDENTITY(1,1),
first_name VARCHAR(50),
last_name VARCHAR(50),
store_id INT,
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO staffs (first_name,last_name,store_id) VALUES
('Kalyan','Kumar',1),
('Anji','Reddy',2),
('Lavanya','Devi',3),
('Indu','Priya',4),
('Sudha','Lakshmi',5);

CREATE VIEW vw_OrderSummary AS
SELECT
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name,
o.order_date
FROM orders o
JOIN customers c ON o.customer_id = c.customer_id
JOIN stores s ON o.store_id = s.store_id
JOIN staffs st ON o.staff_id = st.staff_id;
----we can drop this and create also bit i am using alter--
ALTER VIEW vw_OrderSummary AS
SELECT
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name,
o.order_date
FROM orders o
JOIN customers c ON o.customer_id = c.customer_id
JOIN stores s ON o.store_id = s.store_id
JOIN staffs st ON o.staff_id = st.staff_id;

SELECT * FROM vw_OrderSummary;

CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);

SELECT *
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id;



DROP VIEW vw_ProductDetails;

CREATE VIEW vw_ProductDetails AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
JOIN brands b ON p.brand_id = b.brand_id
JOIN categories c ON p.category_id = c.category_id;

SELECT * FROM vw_ProductDetails;