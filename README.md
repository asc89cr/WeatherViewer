# WeatherViewer
Weather Viewer

## Installation

### Database
This app is currently using Azure SQL database for user authentication. For local developments please feel free to change the appsettings.json file to change the DefaultConnection 
and point it to another sql server instance.

After doing so, please run Update-Database command to run EF migrations.

### API
Default connection to API to get data from weather service is pointing to Azure Service App. To debug in local environments please change the WeatherAPI key in appsettings.json and
point it to a local url.

## Usage
After change urls, connections and have a database ready with migrations, you will be able to run the applications. To Start using it you will need to create an account
with email and password. For now there's no service for sending emails, but you will get an link to confirm the email.

## VS Configuration
For visual studio configuration please set as startup projects both projects inside the solution. One is the API and the other one is the front-end app.
