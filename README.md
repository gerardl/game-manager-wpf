## **Game Manager** - IT4400 Final
---
### By Gerard Lucas  

The Game Manager application allows users to add, update, and delete users, players, npcs (mobs), and inventory items for a fake MMORPG game.
The project is split between a front-end WPF application and a back-end library that handles data access and business logic.

## Requirements & Settings

This project uses MS SQL Server to store data. The connection string is configured in the App.xaml.cs file. The database is created automatically
when the application is run, or can be created via migrations. The database is automatically seeded with needed reference data in GameDbContext.

The default connection string is configured to use LocalDB. It can be installed with Visual Studio Installer as part of Data Storage and Processing workload,
ASP.net and web development workload, or as an individual component. It can also be installed via the [Microsoft SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) installer.
More info can be found at this link: [LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16)

The project also uses json files to store inventory data. Files will be automatically created in the current application directory at runtime in an inventory folder, similar to creaturekingdom. This can be changed in the InventoryService.cs file if needed.

## GameManager.Lib

The Lib project contains the models, services, and repositories for the application. It uses Entity Framework Core to connect to the database. Migrations were used
to create the database in a code-first style. All models start with a base EntityBase class that contains an Id property a deleted flag. I am employing soft deletes
and filtering out deleted records in the DbContext.

The project uses the following packages:

+ Microsoft.EntityFrameworkCore
+ Microsoft.EntityFrameworkCore.Design
+ Microsoft.EntityFrameworkCore.SqlServer
+ Microsoft.EntityFrameworkCore.Tools
+ System.Text.Json

## GameManager.UI

The UI project is a WPF application that handles CRUD operations on Users, Players, Mobs, and Items. It references the Lib project
and uses Dependency Injection to inject services into the view models. The view models are used as controllers and handle the logic for the views.

The project uses the following packages:

+ Microsoft.EntityFrameworkCore
+ Microsoft.EntityFrameworkCore.Design
+ Microsoft.EntityFrameworkCore.SqlServer
+ Microsoft.EntityFrameworkCore.Tools
+ System.Text.Json

## Feature Targets

+ Min: Create a front-end WPF applica�on that handles CRUD operations for a game database and
the underlying tables needed to manage Users, User types, Characters associated to users, and
non-playable character entities via Entity Framework and a local SQL Database. - Done
+ Target: Add the ability to manage a collection of unique items associated to each player and
store these values in local files in JSON format. - Done
+ High : Add authentication to the application, either through a “.NET” way or potentially via a generic SQL account
and the connection string. - Modified.
+ New High: Add Dependency Injection and Repositories and Service pattern to loading data. - Done
+ New High: Use UserControls to create reusable menu components and load them dynamically into view via menu buttons. - Done

+ Reason: All current recommendations for authentication and WPF involve Azure AD or similar cloud hosted models. This seemed far out of
scope for this project, and too much to ask for the instructor/TA to set up. I have still created the user & user type tables and all
required data access, but did not tie in an authentication provider.

## Examples of Required Techniques

There are many examples of required techniques in this project. I will list an example of each below.

+ Loops: GameManager.UI/Views/PlayerView.xaml.cs
+ Methods: GameManager.UI.Models.PlayerViewModel
+ Classes: Models folder
+ Inheritance: GameManager.Lib.Models: EntityBase -> CharacterBase -> Player
+ Strings, Array or Lists: GameManager.UI.ViewModels.UserViewModel
+ Model-View-Controller (MVC) software architecture: GameManager.Lib.Models contains models, ViewModels in UI act as controllers, and the views are in the Views folder
+ Multithreading: PlaverView.xaml.cs for dispatcher. async/await in many places
+ Searching and Sorting, or LINQ: Searching happens in the repository (finding things by id). Sorting/Linq in MainWindow.xaml.cs
+ Exception Handling: GameManager.UI.Models.PlayerViewModel, but also in service, repo, etc.

## Issues

+ Enum options need to be represented in the database as rows in a table, but when I load these into combo boxes it causes issues
with the binding. I ended up using a custom EnumBinding extension that I found via stack overflow. I provided a link in the class.
+ DI does not work with UserControls because they need to be parameterless. I ended up passing the injected service into the view models.
+ Running migrations from a WPF project is not well documented. I ended up creating a GameContextFactory to handle this in the Lib.
This means I can run with Lib as the startup project and do not require Host like in a web app. (and which does not exist in WPF)