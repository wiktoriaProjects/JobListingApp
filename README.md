
This project is a Job Listing application built using ASP.NET Core Web API and Entity Framework Core. It allows users to create, read, update, and delete job listings. The application utilizes both Blazor Server and Blazor WebAssembly to provide a flexible and powerful client-server architecture. 
[JIRA](https://joblistingapp.atlassian.net/jira/software/projects/JBA/boards/34/timeline)
MORE
[KARTA PROJEKTU](https://docs.google.com/document/d/10jgVpblVkaSW4zHGEwVzKgBJ-58-4s3Qi8xNSz3aSGE/edit)
## screenshots
![jobapp_snap1](https://github.com/wiktoriaProjects/JobListingApp/assets/163647716/34c3b06c-1d11-4778-a230-035620f1b7c2)
![jobapp_snap2](https://github.com/wiktoriaProjects/JobListingApp/assets/163647716/0ea1c418-29db-46eb-bfbb-e4b374487dc9)
![jobapp_snap3](https://github.com/wiktoriaProjects/JobListingApp/assets/163647716/646b51e4-d38f-40d6-8ede-a9e7fe8cdf8c)
![jobapp_snap4](https://github.com/wiktoriaProjects/JobListingApp/assets/163647716/610586f2-ea32-42be-a5c2-1604fd50b8a2)
![jobapp_snap5](https://github.com/wiktoriaProjects/JobListingApp/assets/163647716/53238842-9aff-4668-ad85-d05924384e5a)


## Features

Server
- **Create Job Listings**: Add new job listings with details such as title, description, company, and posted date.
- **Read Job Listings**: Fetch and view all job listings or specific listings by ID.
- **Update Job Listings**: Modify existing job listings.
- **Delete Job Listings**: Remove job listings by ID.
Client
- **Apply to Job Listings**: Allows clients to apply directly to job listings. This includes functionality for uploading resumes, cover letters, and filling out any required application forms.
- **Save Job Listings**: Enables clients to bookmark job listings for future reference. Users can save listings to categories like 'Favorites' or 'Interested' for easy access.
- **Read Job Listings**: Provides the ability to view all job listings.
  
WebAPI Features
- **Listing Controller**:It handles all HTTP requests related to job listings, such as creating, retrieving, updating, and deleting listings. The endpoints defined in this controller allow for seamless integration with the frontend or other services.

- **Swagger Integration** The application is equipped with Swagger, a powerful tool for API development. Swagger provides an interactive documentation interface where you can test and describe all the API endpoints implemented by the Listing Controller. This integration helps developers understand the API's capabilities without diving into the codebase and provides a testing interface for immediate feedback on API interactions.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQLite]

## Getting Started

Follow these steps to set up and run the project locally.

### 1. Clone the Repository

```bash
git clone https://github.com/wiktoriaProjects/JobListingApp.git
cd JobListingApp
```
### 2. Check that your localhost settings in the wwwroot directory are correctly configured to match your development environment. 

