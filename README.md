Port ContosoUniversity Tutorial Project to Mac

Setup Environment

1. Install dotnet runtime in Mac
https://www.microsoft.com/net/core#macos

2. Install Visual Studio 2017 for Mac, if you want to develop or debug in Visual Studio
https://www.visualstudio.com/vs/visual-studio-mac/

3. Download the source code of this project (e.g. ~/workdir/ContosoUniversity-Mac)
cd ~/workdir
git clone https://github.com/henryhuanghgs/ContosoUniversity-Mac.git

How to run
1. change current directory
cd ~/workdir/ContosoUniversity-Mac

2. build
dotnet restore
dotnet build

3. unit test
dotnet test ContosoUniversityTests/ContosoUniversityTests.csproj

4. create/update database
cd ContosoUniversity
dotnet ef database update

The database is sqllite by default. Its file is /tmp/ContosoUniversity.db.

5. run
dotnet run

6. browse
http://localhost:5000


Note:
1. The project is ported from the dotnet tutorial 
Tutorial: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
code: https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-mvc/intro/samples/cu-final

2. Multiple databases are supported
*Sqlite
*MySql
*MsSql

The code is using Sqlite by default. Its db file is in /tmp/ContosoUniversity.db

To use MySql:
  1. Comment out the Sqlite line in Startup.cs
    #services.AddDbContext<SchoolContext>(opt => opt.UseSqlite(Configuration.GetConnectionString("Sqlite")));
  2. Remove comment on MySql line in Startup.cs
    services.AddDbContext<SchoolContext>(opt => opt.UseMySql(Configuration.GetConnectionString("MySql")));
  3. Recreate migrations
    cd ~/workdir/ContosoUniversity/ContosoUniversity
    dotnet ef migrations remove
    dotnet ef migrations add "Initial"
  4. Update database
    dotnet ef database update
  5. run
    dotnet run
  
4. Unit tests project (ContosoUniversityTests) is added



