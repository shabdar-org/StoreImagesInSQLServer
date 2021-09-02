This is a C# project developed using Visual Studio 2019 Community Edition.
This project demonstrates how to store/delete image in SQL Server table. 
It uses a simple windows form to display images from database in a data grid. 
It also allows you to upload and store new images in SQL Server database. 
Finally you can also Delete image record from table.

Usage:
1. Before running, change connection string in Connection String textbox to point to correct path for ImageStore.mdf file.
2. Run project then click Connect button. This should display existing images stored in sql server database.
3. Click on "Store New Image" button to store a new image. This will pop up a new form where you can select location of image to upload.
4. To delete image record from database, select entire row on data grid, i.e. click on very first cell of row. Then click "Delete Selected Image"