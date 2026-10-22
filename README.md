# CSV Folder Processor -- CSV file processing and database registration


A background service that watches a folder for csv files, validates them, and saves the data to a database

When a file is dropped in the folder, the service checks it against a set of validation rules. Valid files are saved 
in the database and moved to "/Ok". Files that break a rule are moved to "/Invalid"

**Built with:** C#, .NET Worker Service, SQLite
