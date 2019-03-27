# Property Management System

## About

*This is a tutorial of some sort containing an Angular Application that consumes a REST API service written using ASP.NET Core in Property Management System scenario. Users can create, edit, update and delete apartments by calling the API service via Angular. Additional features:

*- Filter apartments based on price (From -> To), address etc...
*- Support for paging (+ API call to fetcha specific page of apartments, i.e by page number and page size)

*Since this project is for demonstrations purposes and nothing else, authentication has not been implemented.

## How to run

1. Fetch dependencies:

```
npm install
```

2. Open and run PropertyManagement/PropertyManagementAPI.sln 

The server runs on http:localhost:5000 by default.

3. Finally, test the Angular app locally:

```
ng serve
```

## Reinitialize the dummy data

1. Open the ASP.NET Core project
2. Go to the SQL Server tab in Visual Studio
3. Go to Localdb > Databases > PropertyInfoDB
4. Delete this database and run the project again. It will recreate the database and fill it with dummy data again.

## Examples of API calls

Here's a list of API calls we can test using POSTMAN for example:

| METHOD   | URL                                      |
| -------- |:----------------------------------------:|
| GET      | http:localhost:5000/apartments           | 
| GET      | http:localhost:5000/apartments/{id}      |




