#!/bin/sh
cd WebApp

dotnet aspnet-codegenerator controller -name AwardsController -actions -m Award -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name BreedsController -actions -m Breed -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name CompetitionsController -actions -m Competition -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name DogsController -actions -m Dog -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name LocationsController -actions -m Location -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name MaterialsController -actions -m Material -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ParticipantsController -actions -m Participant -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name RegistrationsController -actions -m Registration -dc AppDbContext -outDir ApiControllers -api --useAsyncActions  -f
dotnet aspnet-codegenerator controller -name SchoolingsController -actions -m Schooling -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ShowsController -actions -m Show -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
cd ..
