# TODO List
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

### Frontend
BLAZOR??
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

- [x] Set up ASP.NET Core Web API project
- [x] Create JobListing model
- [x] Set up Entity Framework Core
- [x] Create JobListingController with basic CRUD operations
- [x] Configure database connection
- [x] Apply initial migrations
