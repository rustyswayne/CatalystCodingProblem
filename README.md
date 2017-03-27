# Catalyst Coding Problem

## The People Search Application

### Business Requirements

- The application accepts search input in a text box and then displays in a pleasing style a list of people where any part of their first or last name matches what was typed in the search box (displaying at least name, address, age, interests, and a picture). 
- Solution should either seed data or provide a way to enter new users or both
- Simulate search being slow and have the UI gracefully handle the delay

### Technical Requirements
- An ASP.NET MVC Application 
- Use Ajax to respond to search request (no full page refresh) using JSON for both the request and the response
- Use Entity Framework Code First to talk to the database
- Unit Tests for appropriate parts of the application

## About the Solution

### Directory Structure

- **/Data** - contains raw demo data json file generated using [http://www.generatedata.com/]()
- **/src** - contains solution files and projects
- **/tests**  - contains test project (uses **nunit**)

### Setup and Application Build 

1. Clone the repository locally.  Branching structure follows the generic [git-flow](https://github.com/nvie/gitflow) workflow 
   * Current release (1.0.0) is in **master**
   * Development in **develop**
   * Features in **Features/[branch name]**
   * etc.
2. Open **/src/Catalyst.sln** in Visual Studio
3. Set **Catalyst.Web** as the *Startup Project* 
4. Build (with NuGet package restore)  


### Database

The connection string is set to use **Catalyst.sdf** (SqlCE).  This should be automatically created when the application is built and launched for the first time.  Actually file should be found in the App_Data directory.

You can change the ConnectionString to use MS Sql Server - just make sure the user has permissions to create the database (handled by EntityFramework).



### Client Side Scripting

**Catalyst.Web.Ui.Client** is used for client side scripts only and can be safely removed from the solution if not using Visual Studio to do JavaScript editing.  The scripts have already been built and added to the main **Catalyst.Web** project:

     /scripts/lib/catalyst/peeps.min.js

Build uses **Gulp**

To setup:  

     // npm console
     Cataylyst.Web.Ui.Client> npm install

     // to run the scripts - use 'gulp' (the default)
     gulp



 

