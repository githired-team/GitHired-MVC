# User Stories

## 1.  As a busy job seeker, I want to manage my job applications in a simple graphical format that allows me to track their progress.

### Tasks:

Build data models/base that represent a Trello-like board, as well as columns and cards that exist on that board
Build front end logic that displays the data from these objects correctly
Build an interface that allows us to move cards, and create/reorder columns

### Acceptance Tests:

Columns/cards display in correct order/location on board
Board, column, and card data is created, modified and retrieved correctly from database
Interface correctly moves/creates cards and columns, and these changes persist after user reloads the board


## 2. As a job seeker I want to quickly access the resources I need to apply, such as a relevant resume and cover letter templates, or relevant Github repositories, for different types of positions.

### Tasks:

Allow users to create multiple FocusProfiles for different types of positions (i.e. front-end dev) that store data on profile-specific links to cover letter templates, resume templates, the user’s relevant skills and Github repositories that demonstrate them
Create logic that builds a new Board each time a FocusProfile is created
Build interface for user to navigate between each of their FocusProfile/Boards

###	Acceptance Tests:

Verify that FocusProfile information is correctly stored for each FocusProfile creation/edit
Verify that creating a new FocusProfile builds a new Board
Navigating between boards, each board only displays cards/columns associated with that FocusProfile/Board


## 3.  As a job seeker, I want to quickly and easily see whether I have filled out a resume and cover letter template for a given position.

### Tasks:
Build a portion of the job posting cards that displays whether or not the user has completed a cover letter/resume for that job posting
Build functionality that links users to the templates for their FocusProfile and allows them to mark these tasks as completed

###	Acceptance Tests:
State of cover letter/resume is correctly displayed, and links to templates function
User can successfully mark and unmark resume/cover letter completion
Changes persist after reload

## 4. As a user, I want to view and modify my application management resources, and not the resources of other users.

###	Tasks:
Build “login” page that allows users to log in to their account or sign up if they don’t already have one
Build a “sign up” page and associated database logic to create a user profile
Build a “view account details” page that allows users to view and modify the information stored for their account
Build a “My Boards” page that allows users to view the FocusProfile/Boards specific to their profile

### Acceptance Tests:
“Sign Up” successfully creates a user account that can be accessed later through the “log in” page
Duplicate login credentials are not accepted - each username is unique to ensure users do not log in to another user’s account
Changes made to account details persist after user logs in later
“My Boards” page only displays links to the FocusProfile/Boards specific to that user, and those Boards only display that user’s information

## 5. As a job seeker, I want to be able to search for active job postings and add them to any of my Boards

###	Tasks:
Add search page that allows users to get and display job posting data from our API
Add functionality that allows users to select a job posting and add it to one of their Boards
Build a new Card that contains the job posting data and add it to the correct board

###	Acceptance Tests:
Search page correctly displays search results from our API when user searches for a position
When the user selects a job posting to add to one of their boards, a new card is created on the correct board
The new card contains the correct data for the job posting
