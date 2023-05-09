## **Game Manager** - IT4400 Final
---
### By Gerard Lucas  

[Video Walkthrough](https://www.youtube.com/watch?v=F9ZlS_k0NhE)

Game Manager allows authorized users to add and update characters and npcs for an MMORPG. It is split into two separate projects, a backend server using nodejs and express, and a front-end react single page application that acts as the user interface.  

## GameManager.Lib

The backend project is an express server running on nodejs. It stores player information in a Mongo database. The connection string is configured
in the .env file, along with the port and session secret key. Sessions & authorization are managed by Passport and express session and stored with an
encrypted password in the database via Passport Local Mongoose. Mongoose is used throughout the project to communicate with the database. I used the
CORS module to allow my front-end to communicate with my backend across different domains, and nodemon is used to automatically push any changes during
development. API endpoints are configured in the controllers folder and added to express routing. Models & schemas for mongoose are in the models folder.
The server.js file is the main entry point of the application. The application requires authentication for all requests aside from counts of objects, and
returns 401 responses for any unauthorized users.  

The project uses the following packages:

+ Express
+ Express-Session
+ Express Async Handler
+ Mongoose
+ CORS
+ Passport
+ Passport Local Mongoose
+ dotenv (dev)
+ nodemon (dev)  