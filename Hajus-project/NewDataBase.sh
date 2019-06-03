#!/bin/sh


dotnet ef database drop --project DAL.App.EF --startup-project WebApp
y
dotnet ef migrations remove --project DAL.App.EF --startup-project WebApp
dotnet ef migrations add InitialDbCreation --project DAL.App.EF --startup-project WebApp
dotnet ef database update --project DAL.App.EF --startup-project WebApp