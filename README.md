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
