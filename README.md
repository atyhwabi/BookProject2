Download the project

1. st step seperate the two projects : 
     Take the folder consumeBookKeepAPI outside the main project 
2. BooksKeeper project go to config file and change the connection string to your local database connection string
3. After change the connection string build the project and run the update database on nuget package console.
4. After running the update-database command check on your local database if the entity framework created the db according to the models under the folder models in the project. If not check your connection string and run the command again.

5. Then run the project BooksKeeper 1st and run the consumeBookAPI
 
