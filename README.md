# RecipeBox
##### An ASP.Net Core 2.2 Web Application, which utilizes various Azure services to create an interactive recipe organiztion solution
<br/>
##### The purpose of this application is to implement and familiarize myself with as many Azure services as possible
<br/>
#Requirements
<br/>
1. Manage user accounts
..1. Secure user passwords
..2. Allow multi-factor authentication
..3. Confirm accounts via Email
..4. Encrypt user data at rest
2. Personal Page
..1. Page shows user's recipes
..2. User can add new recipe
..3. User can edit recipe
..4. User can remove recipe
..5. Recipes for other users not shown
..6. User cannot add or edit unless logged in
..7. User can mark recipe to publish
2. Users
..1. Users can create account
..2. Users can log in to their account
..3. Users can log out of their account
3. Published
..1. Recipes will display if marked published
..2. Recipes will be removed if published is unchecked
<br/>
#Currently Implemented
###Azure SQL Server with 2 databases
1. Application Database
Used to store user created data such as recipes and ingredients. Contains all data and tables required for business logic.
<br/>
2. User Authentication Database
Contains all the ASP.NET Identity tables and user information, maintained separately from the application database to reduce how often user data is in transit.
<br/>
3. Entity Framework Core
Code first model scaffolding to keep precise entity relationships. Grants users permission to utilize CRUD operations in order to store their customized recipes.
<br/>
4. User-Secrets Manager
Protect application secrets in the producation environment.
<br/>
5. ASP.NET IDENTITY (full UI scaffolded to add further constraints to account behavior)
Safe user account management as to avoid writing my own hash algorithms and improperly storing user passwords. The full suite of functions is not currently being utilized, future implementations may occur as needed.
<br/>
6. SendGrid API
Allows accounts to be confirmed through email confirmation.
<br/>
7. BootStrap 4
Utilized for the basic stylizing and animations of the application.
<br/>
#Test Plan
|     Requirement             |     Test Method        |         Test Procedures           |      Current Status |
| ----------------------------|:----------------------:|:---------------------------------:| -------------------:|
|  Page shows user's recipes  |     Inspection         | Login Successful, page redirects to page that displays recipes | Passed |
|  User can add new recipe  |     Demonstration         | Click on the add recipe link on the user's main page, the add recipe page displays. After submitted, the main page shows the new recipe | Not Passed |
|  User can edit new recipe |     Demonstration         |  Click edit at the right side of the recipe. All parts of the recipe can be edited. After update button is selected, the main page shows the updated recipe | Not Passed |
|  User can remove recipe   |     Demonstration         |   Click delete at the right side of the recipe. The recipe will disappear from the list | Not Passed |
| Recipes for other users not shown |  Inspection   | Confirm no other recipes besides ones you have added are shown | Passed | 
| User cannot add or edit unless logged in | Demonstration | Verify not logged in to an account. If user's page url is attempted to be navigated to manually, an unauthorized page will appear | Passed|
| User can mark recipe to publish  |  Demonstration  | Box next to each recipe is checked, and will display on the 'published' page |  Not Passed |
| User can create an account  | Demonstration | Click register. Fill out all fields and click register. Account should be created | Passed |
| User can log in to their account | Demonstration | Click login. Fill out the fields with account information created. Click login. User name should display at top of the page | Passed |
| User can log out of their account | Demonstration | Click logout. Username should be removed from top of page and login available again | Passed |
| Recipes will display if marked as published | Inspection | Verify only published recipes display | Not Passed |
| Recipes will be removed if published is unchecked | Demonstration | Unchecked box, published page updates correctly when loaded | Not Passed |

