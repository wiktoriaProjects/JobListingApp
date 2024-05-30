# TODO List
- [ ] Create JobListing model
- [ ] Set up Entity Framework Core
- [ ] Create JobListingController with basic CRUD operations
- [ ] Configure database connection
### Backend

- [ ] Implement authentication and authorization
  - [ ] User registration
  - [ ] User login
  - [ ] Role-based access control
- [ ] Add validation for job listing fields
  - [ ] Title (required, max length 100)
  - [ ] Description (required)
  - [ ] Company (required, max length 100)
  - [ ] PostedDate (required, valid date)
- [ ] Implement pagination for GET /api/JobListings
- [ ] Add logging and error handling
- [ ] Create unit tests for API endpoints
- [ ] MiddlewareRequest exception - WebApi 

### Frontend
BLAZOR
- [ ] Design and implement the user interface
  - [ ] Job listings page
  - [ ] Job listing details page
  - [ ] Create job listing form
  - [ ] Edit job listing form
- [ ] Integrate frontend with backend API
- [ ] Add client-side routing

## Medium Priority

### Backend

- [ ] Implement search functionality for job listings
- [ ] Add filtering options (e.g., by company, date range)
- [ ] Implement email notifications for new job postings

### Frontend

- [ ] Implement responsive design
- [ ] Add user feedback messages (e.g., success, error)
- [ ] Implement loading indicators for API calls

## Low Priority

### Backend

- [ ] Set up automated deployment
- [ ] Create Dockerfile for containerization

### Frontend

- [ ] Add animations and transitions
- [ ] Improve overall UI/UX design

## Completed
- [x] make project doc "karta projektu"
- [x] Set up ASP.NET Core Web API project



ROLES --> do przerzucenia >>> polski ?
# Roles

## Project Roles

### 1. Developer - Wiktoria
- Set up and configure the project.
- Implement backend features and API endpoints.
- Design and develop the frontend interface.
- Write unit and integration tests.
- Ensure code quality and maintainability.

### 2. Developer - Piotr
- Assist with setting up and configuring the project.
- Implement authentication and authorization.
- Work on backend enhancements and optimizations.
- Integrate frontend with backend API.
- Handle deployment and environment setup.



# User Stories

## Admin User Stories

### 1. User Registration and Management
As an Admin, I want to be able to register new users and assign roles, so that I can manage access to the application.

### 2. Manage Job Listings
As an Admin, I want to manage all job listings, so that I can ensure the quality and appropriateness of the content.

### 3. View Reports
As an Admin, I want to view usage reports, so that I can monitor the application's performance and user engagement.

## Employer User Stories

### 1. Create Job Listings
As an Employer, I want to create job listings, so that I can attract potential candidates.

### 2. Edit Job Listings
As an Employer, I want to edit my job listings, so that I can update the information as needed.

### 3. Delete Job Listings
As an Employer, I want to delete my job listings, so that I can remove outdated or filled positions.

### 4. View Applications
As an Employer, I want to view applications for my job listings, so that I can review and contact candidates.

## Job Seeker User Stories

### 1. View Job Listings
As a Job Seeker, I want to view job listings, so that I can find potential job opportunities.

### 2. Search Job Listings
As a Job Seeker, I want to search for job listings by keywords and filters, so that I can find jobs that match my skills and preferences.

### 3. Apply for Jobs
As a Job Seeker, I want to apply for job listings, so that I can be considered for positions.



---


