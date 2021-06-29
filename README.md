# Books Reviewer App

This suite of applications process the review file from the FTP server transform and pushes the aggregated data into the RDS table, which is then rendered in the front end UI using a C# Web API.

## Architecture

![image](https://user-images.githubusercontent.com/23555294/123542817-f6bf6b80-d78e-11eb-8fcc-7eaaa4e1e255.png)

#### FTP Server ####
The CSV file with the rating against each book gets placed in the FTP folder every day in FTP folder.

#### Loading CSV file to S3 ####
The books rating CSV file gets pushed to the S3 bucket

#### Lambda process the file ####
The CSV file from the S3 bucket is loaded into the ***Review table*** in Postgres DB which is partitioned with *bookid*
Another Lambda service will process the loaded data from the review table and aggregate each book's rating to process the average rating. This data gets loaded into ***ReviewAggregate table***


#### RDS- Postgres DB ####
There are two tables used for this APP. ***Review table***: which acts as a staging table to load the CSV file and ***ReviewAggregate table***: aggregates as an average rating of each book. This table is used as a back end table for the C# web API.

#### WEB API ####
The backend Web API is built on .Net Core. This API exposes a controller for finding the top writers by average rating. The API uses the Entity framework for Core to connect to Postgres DB. Route 53 is used to configure the URL to be accessible to the Internet. This runs on docker using the ECS service. 
The API definition can be accessible through the Swagger URL as below 
> http://localhost:52313/swagger/index.html

***NB: The API is currently using the In-memory DB as a MOCK. Also instead of the angular App UI, swagger UI is enabled for viewing the API results.***

#### Front UI ####
The front end UI is build using the angular app. The angular app is deployed to S3 which is configured as a web host and connected to the CloudFront which exposes the website to the Internet.


## Assumptions
* The input books' rating CSV file is a batch load.
* A single book gets a rating by the same customer only once.
