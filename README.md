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

The Administrator can attribute user roles and delete users.
The Employee has Crud opperations over the orders, products, categories and reviews.
The Customer can view his own orders, shipping address and also create new orders.

Each user has a shoping cart that is kept in the database and retrieved when the user returns (until he/she deletes it)
The user can create an order (thus converting the shopping cart into an order)
