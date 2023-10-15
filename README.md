# A/B Testing API
A web API that enables the validation of marketing hypotheses through A/B testing. Developed as a test assignment for ABP company.
## Table of contents
[Endpoints](#endpoints)\
[How to run](#how-to-run)\
[Database tables and queries](#database-tables-and-queries)
## Endpoints
### Get "Button color" experiment data
+ URL: `GET /experiment/button-color`
+ Request parameters:
  + `device-token` (string, required) - User device token
+ Successful response (HTTP 200)
  + Response type: JSON
  + Returns experiment key and value 
+ Invalid data (HTTP 400)
  + Response type: JSON
  + Returns error message
+ Not found (HTTP 404)
  + Response type: JSON
  + Returns error message
___
### Get "Price" experiment data
+ URL: `GET /experiment/price`
+ Request parameters:
  + `device-token` (string, required) - User device token
+ Successful response (HTTP 200)
  + Response type: JSON
  + Returns experiment key and value 
+ Invalid data (HTTP 400)
  + Response type: JSON
  + Returns error message
+ Not found (HTTP 404)
  + Response type: JSON
  + Returns error message
___
### Get "Button color" experiment statistics
+ URL: `GET /experiment/GetColorStatistics`
+ No request parameters
+ Successful response (HTTP 200)
  + Response type: JSON
  + Returns devices amount, distribution statistics grouped by option value and experiment list
+ Not found (HTTP 404)
  + Response type: JSON
  + Returns error message
___
### Get "Price" experiment statistics
+ URL: `GET /experiment/GetPriceStatistics`
+ No request parameters
+ Successful response (HTTP 200)
  + Response type: JSON
  + Returns devices amount, distribution statistics grouped by option value and experiment list
+ Not found (HTTP 404)
  + Response type: JSON
  + Returns error message
## How to run
To run the application, follow the steps below:
+ **Clone the Repository**\
`git clone https://github.com/oleh-dumanskyi/AbpApplication`
+ **Open the Project in Your Development Environment**\
Open the project in your preferred development environment, such as Visual Studio, Visual Studio Code, or others.\
Make sure you have the necessary extensions and dependencies for C# and ASP.NET installed.
+ **Configure the Settings**\
You need to modify `appsettings.json` configuration file:
  + Add `"ConnectionString"` field containing connection string to database you want to use.
+ **Run the Application**\
Run the application in debug mode or build and run it. Typically, you can do this using the F5 command in Visual Studio or by running the dotnet run command in the command line.\
Running project in debug mode will open [Swagger UI](https://github.com/swagger-api) page.
## Database tables and queries
Since I'm not sure if the use of EF Core is allowed according to the assignment's requirements, I provide a [link to a document](https://docs.google.com/document/d/17A11hF38BF_loNLkuIx_lB2fxRl51B82/edit?usp=sharing&ouid=111169753199799050473&rtpof=true&sd=true) where you can find alternatives to the application's queries written in pure SQL, which I would use instead of EF Core + LINQ.
