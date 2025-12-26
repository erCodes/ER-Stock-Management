# ER-Stock-Management

ER-Stock-Management is my full stack project for managing products and categorizing them in the supermarket.

Project contains:
### Frontend files
- Frontend functionalities are coded with JavaScript with no frameworks. It is designed to be as light as possible.

### ER-Stock-Management-API
-  This is API part. There are three controllers: CategoryController, StoreController and ProductController. Required endpoints can be found in these files.

### ER-Stock-Management-DAL
- This is data access layer. Here you can find three folders in "Repositories" folder: CategoryRepository, StoreRepository and ProductRepository. Inside of these folders are GET, POST, PUT and DELETE files that contains database logic for these operations. DBContext and migration files are also in this project.

### ER-Stock-Management-DataLibrary
- Here you can find database objects and DTO objects. DTO objects are simpler versions of database objects. Methods.cs file contains shorthand methods. Result.cs is used when returning result of that http call from database to API.

### ER-Stock-Management-Tests
- Here you can find unit tests for API and for database object constructors.

## Common info & how to use
Object structure:
- Store contains basic store info and list of products.
- Products contain basic product info, timestamp and list of category id:s (only id numbers, no names).
- ProductCategories are stored separately.

On top of every page, you can find language flags: Finnish & English. Page will change language and reload when you click the flag.
There is also darkmode image (moon). Click it to change to darkmode or back to lightmode.

#### Index.html
- This is the start page. Here You can navigate to "Add Store" or "Product categories". If there is added stores, they are displayed as buttons. Click them to open their data.

#### AddStore.html
- Here you can add new store. Fill the info and add new one.

#### ProductCategories.html
- Here you can add, modify and delete product categories. Only name is needed. Click the confirmation checkbox, if you want to delete it.

#### BrowseStore.html
- Here you can see the store data. Basic info is displayed first, "View products" button is under that. Under is Chart.js component that draws pie chart from product quantities. There is "Modify store info" and "Delete store" buttons. If you click the "Delete store", warning text and new delete button will appear. 

#### ViewProducts.html
- Here you can add, modify and delete products. Minimum data is name, amount in number and at least one category. Product can have multiple categories. You can add/modify/delete only one product at the time. Page will reload every time you click modify or delete. So do only on at a time



