# Job Listing App

This project is a Job Listing application built using ASP.NET Core Web API and Entity Framework Core. It allows users to create, read, update, and delete job listings.
MORE >> karta projektu [docs](https://docs.google.com/document/d/10jgVpblVkaSW4zHGEwVzKgBJ-58-4s3Qi8xNSz3aSGE/edit)

## Features

- **Create Job Listings**: Add new job listings with details such as title, description, company, and posted date.
- **Read Job Listings**: Fetch and view all job listings or specific listings by ID.
- **Update Job Listings**: Modify existing job listings.
- **Delete Job Listings**: Remove job listings by ID.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any other compatible database)

## Getting Started

Follow these steps to set up and run the project locally.

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/JobListingApp.git
cd JobListingApp
etc..

```
## API Endpoints
Here are the available API endpoints:

GET /api/JobListings: Fetch all job listings.
GET /api/JobListings/{id}: Fetch a specific job listing by ID.
POST /api/JobListings: Create a new job listing.
PUT /api/JobListings/{id}: Update an existing job listing by ID.
DELETE /api/JobListings/{id}: Delete a job listing by ID.
