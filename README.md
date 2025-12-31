# ER-Stock-Management

ER-Stock-Management is my full stack project for managing products and categorizing them in the supermarket.

Project contains:
### Frontend files
- Frontend functionality is implemented using plain JavaScript without frameworks. It is designed to be as light as possible.

### ER-Stock-Management-API
-  This is API part of the project. There are three controllers: CategoryController, StoreController and ProductController. Required endpoints can be found in these files.

### ER-Stock-Management-DAL
- This is data access layer. Here you can find three folders in "Repositories" folder: CategoryRepository, StoreRepository and ProductRepository. Inside of these folders are GET, POST, PUT and DELETE files that contains database logic for these operations. DBContext and migration files are also in this project.

### ER-Stock-Management-DataLibrary
- Here you can find database objects and DTO objects. DTO objects are simplified versions of database objects. Methods.cs file contains shorthand methods. Result.cs is used to return the result of an HTTP call from the database to the API.

### ER-Stock-Management-Tests
- Here you can find unit tests for API and for database object constructors.

## Common info & how to use
Object structure:
- Store contains basic store info and list of products.
- Products contains basic product info, timestamp and list of category id:s (only id numbers, no names).
- Product categories are stored separately.

On top of every page, you can find language flags: Finnish & English. Page will change language and reload when you click the flag.
There is also darkmode image (moon). Click it to switch between dark and light mode.

#### Index.html
- This is the start page. Here You can navigate to "Add Store" or "Product categories". If there is added stores, they are displayed as buttons. Click them to open their data.

#### AddStore.html
- Here you can add new store. Fill the info and add new one.

#### ProductCategories.html
- Here you can add, modify and delete product categories. Only name is needed. Click the confirmation checkbox, if you want to delete it.

#### BrowseStore.html
- Here you can see the store data. Basic info is displayed first, "View products" button is under that. Below that is Chart.js component that draws pie chart from product quantities. There are "Modify store info" and "Delete store" buttons. If you click the "Delete store", warning text and new delete button will appear. 

#### ViewProducts.html
- Here you can add, modify and delete products. Minimum data is name, amount in number and at least one category. Product can have multiple categories. Page will reload every time you click modify or delete. So do only one at a time.

#### ModifyStoreInfo.html
- Here you can modify basic store data. Fill the info and click the modify button.

### How to use
1. Open index file and add new store.
2. Add few product categories. You can not add product without an category.
3. Open the store and navigate to "View products" page.
4. Add few products. Minimum data is name, amount in number and at least one category.
5. Navigate back to store page. Now you can see the pie chart containing the products and their quantities. You can hover mouse over it to see quantities.
#### Additional info
- You can modify basic store info on its own page.
- When deleting store, all its products are deleted too.
- If you delete category, it is removed from every products category id list. No "ghost data".

## Languages and frameworks used
### Frontend
- JavaScript, Chart.Js, Bootstrap, basic HTML and CSS
### ER-Stock-Management-API
- ASP.NET Core Web API (.net 8.0, C#)
### ER-Stock-Management-DAL
- Microsoft EntityFrameworkCore (.net 8.0, C#), Microsoft SQL Server
### ER-Stock-Management-DataLibrary
- Common .NET class library (.net 8.0)
### ER-Stock-Management-Tests
- .Net Framework (8.0), NUnit unit testing, Moq
