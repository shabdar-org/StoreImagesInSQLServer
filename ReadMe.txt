-This sample demonstrates how to store images in SQL Server database
-If somehow you can not use provided FileStore.mdf database then you can generate necessary table using scripts provided in "FileStore.sql" file.
-Change connection string on both forms to point to correct path for mdf file.
-For detailed instructions visit -> https://shabdar.org/2021/09/01/store-image-in-sql-server-datab/

Usage:
1. Before running, change connection string in Connection String textbox to point to correct path for ImageStore.mdf file.
2. Run project then click Connect button. This should display existing images stored in sql server database.
3. Click on "Store New Image" button to store a new image. This will pop up a new form where you can select location of image to upload.
4. To delete image record from database, select entire row on data grid, i.e. click on very first cell of row. Then click "Delete Selected Image"