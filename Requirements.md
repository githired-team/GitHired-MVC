# Software Requirements

## Vision
This product will tackle the problem of find jobs and managing the process of finding a job for software developers. Developers are talent and talent needs a manager. Our 
target audience are junior software developers who are breaking into a new career market, becoming a developer unconventionally is hard enough, why stress about the job application proccess too?


## Scope (In/Out)
~ IN
    Our product will allow users to become members.
    Members will be able to fill out forms to search for jobs.
    Members will be able to add jobs they are interested in to the Canban Board.
    Members will be able to add their Github repos to the Job Cards on their Canban Board.
    Members will be able to add and move columns on their Canban Board.
    Our API will act as a melting pot for job listing APIs 
    Our API will send a single json object of all job listings relevant to the request fields
    
    
~ OUT
    Our product will not send applications to companies.
    Our product will not create deliverables (resume, cover letter, github account).
    Our product will not let members get in contact contact with companies.
    
### MVP
Our MVP will be to allow a user to create a new profile or log into their already created profile. Members will be able to search for jobs relevant to their stack, location, and other searchables. The results will populate a view page where the member will be able to select which job listings they want to add to their Canban Board. When the user navigates to the Board View they will see Cards of job listings they have selected through the search form. Members will be able to move Cards from one column to another inside the Canban Board.

### Stretch
Canban Board for technical skills. File upload and retrieval using Azure. Seed our API with actual jobs from Indeed, Monster , LinkedIn, etc APIs. Reminders about deadlines or long time between communications.

## Functional Requirements
- A user edit their profile
- A user can search jobs
- A user can add jobs to a canban board
- A user can add Github repos to cards on the canban board
- A user can move cards to different columns on the canban board
- A user can create new columns on the canban board
- A user can move columns on the canban board

## Non-Functional Requirements
- Deployablility
    * This application should be used and accessed by people from the internet, thus this application will be deployed on Azure

- Testability
    * Testing our models and proving we can use CRUD methods with those models in our Enitity Framework Database

## Data Flow
A user comes to our website and creates a user login
A profile and a board are created and the member can now navigate to the search page
The member selects which listing they are interested in and and new cards are created and added to the board
The member can navigate to the board and create new columns, move cards around, and/or view card details.
The member can add relevant GitHub repos to cards when looking at the details.
The member can log out

