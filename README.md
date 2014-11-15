Shop.NET
========

Е-commerse solution made up using ASP.NET MVC5

Features
------------

### The basics

Crud operations on all products and categories. Products and categories have SEO friendly urls with Meta information.

### User Roles

There are three user roles in the application

1. Administrator
2. Emplpoyee
3. Customer

The administrator can attribute user roles and delete users.
The employee has crud opperations over the orders, products, categories and reviews.
The customer can view his own orders, shipping address and also create new orders.

Each user has a shoping cart that is kept in the database and retrieved when the user returns (until he/she deletes it)
The customer can create an order (thus converting the shopping cart into an order), also has order history.

### Product pages

1. Product pages have pictures (active and selectable pictures).
2. There are reviews on the page that are loaded with "endless scrolling"
3. The sopping cart is ajax enabled, so the customer can buy items without leaving the product page.
4. Each page is SEO optimized with META DESCRIPTION, META TITLE nad META KEYWORDS
5. Both categories and products are implemented using SEO firendly urls.
6. On each product page there are social sharing buttons (for Facebook and Twitter)
7. The user reviews are made only by customers who have bought the said item. 

### Category Pages

1. Each page is SEO optimized with META DESCRIPTION, META TITLE nad META KEYWORDS
2. Both categories and products are implemented using SEO firendly urls.
3. The categories list configurable ammout of items with server side paging.
4. There's a brief description for the category on each page.

### Administration

1. Employees can view orders. Kendo grid is used with details view for each order (avalible as nested grid). Sorting/Paging/Filtering are all enbabled.
2. Users can also view their own orders (implemented in the same way as with the Employee, but with all the sesitive information removed)
