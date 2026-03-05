CREATE DATABASE StoringDB
USE StoringDB

CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(15),
    email VARCHAR(100)
);
INSERT INTO customers (first_name, last_name, phone, email) VALUES
('Lavanya', 'Rao', '9876543210', 'lavanya@gmail.com'),
('Indu', 'Priya', '9123456780', 'indu@gmail.com'),
('Sudha', 'Kumari', '9988776655', 'sudha@gmail.com'),
('Anji', 'Reddy', '9012345678', 'anji@gmail.com');

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);
INSERT INTO orders (customer_id, order_date, order_status) VALUES
(1, '2026-03-01', 1),  -- Lavanya Pending
(2, '2026-03-02', 4),  -- Indu Completed
(3, '2026-03-03', 2),  -- Sudha Processing (won’t show)
(4, '2026-03-04', 4),  -- Anji Completed
(1, '2026-03-05', 1);  -- Lavanya Pending


CREATE TABLE brands (
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(100) NOT NULL
);
INSERT INTO brands (brand_name) VALUES
('Nike'),
('Adidas'),
('Puma'),
('Apple'),
('Samsung');

CREATE TABLE categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100) NOT NULL
);
INSERT INTO categories (category_name) VALUES
('Shoes'),
('Electronics'),
('Clothing');
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(150) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);
INSERT INTO products (product_name, brand_id, category_id, model_year, list_price) VALUES
('Nike Air Max', 1, 1, 2023, 750),
('Adidas Ultraboost', 2, 1, 2022, 680),
('Puma Running Pro', 3, 1, 2023, 450),
('iPhone 14', 4, 2, 2023, 1200),
('Samsung Galaxy S23', 5, 2, 2023, 950),
('Nike T-Shirt', 1, 3, 2022, 300);

--1. Display product_name, brand_name, category_name, model_year, and list_price.----------

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id;

    ------------2. Filter products with list_price greater than 500.--------------
    SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id
WHERE p.list_price > 500;

-------3. Sort results by list_price in ascending order.---------------

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id
ORDER BY p.list_price ASC;


CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(50)
);
INSERT INTO stores (store_name) VALUES
('Hyderabad Store'),
('Bangalore Store'),
('Chennai Store'),
('Mumbai Store');

CREATE TABLE orders1 (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
INSERT INTO orders1 (store_id, order_status) VALUES
(1, 4),
(2, 4),
(3, 1),
(1, 4),
(4, 4);
CREATE TABLE order_items (
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);
INSERT INTO order_items (order_id, quantity, list_price, discount) VALUES
(1, 2, 1000, 0.10),   
(1, 1, 500, 0.05),    
(2, 3, 800, 0.00),    
(3, 5, 600, 0.10),    
(4, 4, 700, 0.20),    
(5, 2, 1500, 0.15);

-- Use INNER JOIN between stores, orders, and order_items tables.
---Use GROUP BY clause.
-- U-se aggregate functions such as SUM().
-- Us-e WHERE clause for filtering.
-- Use ORDER BY clause.



SELECT 
    st.store_name,
    SUM(item.quantity * item.list_price * (1 - item.discount)) AS total_sales
FROM stores st
INNER JOIN orders1 ord
    ON st.store_id = ord.store_id
INNER JOIN order_items item
    ON ord.order_id = item.order_id
WHERE ord.order_status = 4
GROUP BY st.store_name
ORDER BY total_sales DESC;

---------------------------------------
CREATE TABLE products_All (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100) NOT NULL
);
INSERT INTO products (product_name) VALUES
('Laptop'),
('Mobile'),
('Headphones'),
('Tablet');

CREATE TABLE store (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100) NOT NULL
);
INSERT INTO stores (store_name) VALUES
('Hyderabad Store'),
('Bangalore Store');

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO stocks (store_id, product_id, quantity) VALUES
(1, 1, 50),   -- Laptop in Hyderabad
(1, 2, 100),  -- Mobile in Hyderabad
(1, 3, 80),   -- Headphones in Hyderabad
(2, 1, 40),   -- Laptop in Bangalore
(2, 4, 60);   -- Tablet in Bangalore

CREATE TABLE order_item (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);
INSERT INTO order_item (store_id, product_id, quantity) VALUES
(1, 1, 10),  -- 10 Laptops sold in Hyderabad
(1, 2, 25),  -- 25 Mobiles sold in Hyderabad
(2, 1, 15);  -- 15 Laptops sold in Bangalore

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock_quantity,
    ISNULL(SUM(oi.quantity), 0) AS total_quantity_sold
FROM stocks st
INNER JOIN products_All p
    ON st.product_id = p.product_id
INNER JOIN store s
    ON st.store_id = s.store_id
LEFT JOIN order_item oi
    ON st.product_id = oi.product_id
    AND st.store_id = oi.store_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY 
    p.product_name ASC;