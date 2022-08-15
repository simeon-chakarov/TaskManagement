Instalation
1. Clone the repo (or download the zip file and extract on the local mashine)
2. Open the solution with Visual Studio 2022
3. Open "Web.config" file and specify your "connectionString" property to the local database
4. Open "Package Manager Console" (Tools -> NuGet Package Manager -> Package Manager Console) and execute fallowing commands:
- enable-migration - this is to enable migrations for this project.
- update-database - this is to execute all migrations to the local database
5. Rebuild and start the project. 

Note: If you recieve an error like this - "Could not find a part of the path ... bin\roslyn\csc.exe" - open "Package Manager Console" and execute: 
"Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"


Features
1. The app represent simple task management system with three main tables:
- Task - list of tasks that can be maintainable. You can add new task, edin existing one and add comments to a task. There can be a multiple comments for every task. The comments for a specific task can be displayed by click on "Comments" action link in "Actions" column.
- Comments - list of all created comments for every existing task
- Developers
