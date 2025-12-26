# ER-Stock-Management

ER-Stock-Management is my full stack project for managing products and categorizing them in the supermarket.

##### Table of Contents  
[Headers](#headers)  
[Emphasis](#emphasis)  

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
