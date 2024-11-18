CREATE TABLE "customer"(
    "name" VARCHAR(255) NOT NULL,
    "costumerId" INT NOT NULL,
    "loyality" INT NOT NULL,
    "phone" BIGINT NOT NULL
);
ALTER TABLE
    "customer" ADD CONSTRAINT "customer_costumerid_primary" PRIMARY KEY("costumerId");
CREATE TABLE "products"(
    "ProductId" INT NOT NULL,
    "price" BIGINT NOT NULL,
    "category" VARCHAR(255) NOT NULL,
    "stock" INT NOT NULL,
    "name" VARCHAR(255) NOT NULL
);
CREATE INDEX "products_productid_index" ON
    "products"("ProductId");
ALTER TABLE
    "products" ADD CONSTRAINT "products_productid_primary" PRIMARY KEY("ProductId");
CREATE TABLE "order"(
    "costumerId" INT NOT NULL,
    "payment" VARCHAR(255) NOT NULL,
    "OrderId" INT NOT NULL,
    "totalPrice" BIGINT NOT NULL,
    "OrderDetails" VARCHAR(255) NOT NULL,
    "OrderTime" TIMESTAMP NOT NULL
);
ALTER TABLE
    "order" ADD CONSTRAINT "order_orderid_primary" PRIMARY KEY("OrderId");
CREATE TABLE "OrderDetails"(
    "PricePerUnit" BIGINT NOT NULL,
    "costumerId" INT NOT NULL,
    "TotalOrder" INT NOT NULL,
    "OrderId" INT NOT NULL,
    "OrderDetailsId" INT NOT NULL,
    "ProductId" INT NOT NULL
);
ALTER TABLE
    "OrderDetails" ADD CONSTRAINT "orderdetails_orderdetailsid_primary" PRIMARY KEY("OrderDetailsId");
ALTER TABLE
    "order" ADD CONSTRAINT "order_costumerid_foreign" FOREIGN KEY("costumerId") REFERENCES "customer"("costumerId");
ALTER TABLE
    "OrderDetails" ADD CONSTRAINT "orderdetails_productid_foreign" FOREIGN KEY("ProductId") REFERENCES "products"("ProductId");
ALTER TABLE
    "OrderDetails" ADD CONSTRAINT "orderdetails_costumerid_foreign" FOREIGN KEY("costumerId") REFERENCES "customer"("costumerId");
ALTER TABLE
    "OrderDetails" ADD CONSTRAINT "orderdetails_orderid_foreign" FOREIGN KEY("OrderId") REFERENCES "order"("OrderId");