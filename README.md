-using .net core 3.0 with visual studio 2019

-Run User.sql script file in your database

-DB connection string need to update in appsettings.json of UserRegistrationWebApi project 
(eg: "UserDBContext": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")

-Firstly run the WebApi Project

-Copy WebApi URL and replace the URL in appsettings.json of WebUserRegistration
(eg:"UserApiURL": "https://localhost:44330/User")

-And then, run the WebUserRegistration project



