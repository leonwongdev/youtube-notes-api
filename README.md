# YouTube Note Taking App - Backend

This repository contains the backend code for building a REST API for my YouTube note-taking app.

## Deployment Information

- **Deployment Platform:** Azure App Service
- **Database:** Azure SQL Database

The backend is deployed on Azure using Azure App Service, and it utilizes Azure SQL Database for data storage.

## Frontend Information

The corresponding React CRUD web app is deployed on Netlify. You can access it here: [https://youtubenotes.netlify.app/](https://youtubenotes.netlify.app/).

## Frontend Code Repository

For the frontend code, please refer to the following repository:

[Frontend Code Repository](https://github.com/leonwongdev/react-crud-videonote-app)

## Getting Started

To set up and run the backend locally, follow these steps:

1. Clone this repository:

   ```bash
   git clone https://github.com/your-username/your-backend-repo.git
2. Change the `DefaultConnection` string in appsettings.json to use your local sql server
3. Open Nuget Package Manager Console to run the migration
   ```bash
   update-database
4. Run the application via Visual Studio

  
