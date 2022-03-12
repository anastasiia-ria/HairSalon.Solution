# Eau Claire's Salon

#### Tracks Eau Claire's Salon stylists, clients, and appointments

#### By [Anastasiia Riabets](https://github.com/anastasiia-ria)

## Technologies Used

- CSS
- HTML
- C#
- .NET 5.0
- ASP.Net
- Razor
- dotnet script REPL
- MySQL
- Workbench
- EF Core

## Description

Eau Claire's Salon lets owner to add and track her stylists, their clients, and their appointments.

## Setup/Installation Requirements

- Clone this repository to your Desktop:
  1. Your computer will need to have GIT installed. If you do not currently have GIT installed, follow [these](https://docs.github.com/en/get-started/quickstart/set-up-git) directions for installing and setting up GIT.
  2. Once GIT is installed, clone this repository by typing following commands in your command line:
     ```
     ~ $ cd Desktop
     ~/Desktop $ git clone https://github.com/anastasiia-ria/HairSalon.Solution.git
     ~/Desktop $ cd HairSalon.Solution
     ```
- Install the [.NET 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- Install Packages for EF Core:
  ```
  ~/Desktop/HairSalon.Solution $ dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0
  ~/Desktop/HairSalon.Solution $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2
  ```
- Setup Database:
  - Install [MySQL Community Server and MySQL Workbench](https://www.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-04-installing-and-configuring-mysql). Remember your PASSWORD.
  - Open MySQL Workbench and access Local instance 3306 under MySQL Connections
  - Click on the "Administration Tab", and select "Data Import/Restore" from the list
  - Select "Import from Self-Contained File" and find file named "anastasiia_riabets.sql" located at Desktop/HairSalon/anastasiia_riabets.sql
  - Start Import
- Create .gitignore file:
  ```
   ~/Desktop/HairSalon.Solution/ $ touch .gitignore
   ~/Desktop/HairSalon.Solution/ $ echo "*/obj/
   */bin/
   */appsettings.json" > .gitignore
  ```
- Create appsettings.json file:
  ```
   ~/Desktop/HairSalon.Solution $ cd HairSalon
   ~/Desktop/HairSalon.Solution/HairSalon $ touch appsettings.json
   ~/Desktop/HairSalon.Solution/HairSalon $ echo '{
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=anastasiia_riabets;uid=root;pwd=[PASSWORD];"
      }
    }' > appsettings.json
  ```
  [PASSWORD] is your password
- Build the project:
  ```
   ~/Desktop/HairSalon.Solution/HairSalon $ dotnet build
  ```
- Run the project
  ```
   ~/Desktop/HairSalon.Solution/HairSalon $ dotnet run
  ```
- Visit [http://localhost:5000](http://localhost:5000) to try this application

## Known Bugs

- Layout is not adjusted for the small screens

## License

[ISC](https://opensource.org/licenses/ISC)

Copyright (c) 03/11/2022 Anastasiia Riabets
