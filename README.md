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
- Task - list of tasks that can be maintainable. You can add new task, delete a task, edit existing one and add comments to a task. There can be a multiple comments for every task. The comments for a specific task can be displayed by click on "Comments" action link in "Actions" column. You can also add a new comment for the selected task.
- Comments - list of all created comments for every existing task. First column of the table display the related task for every comment. You can edit or delete comments from this list. Double click on a comment redirect to corresponding task.
- Developers - a predefined list of developers. You can assign a developer to each task (either by creating it or by editing it). There can be a multiple tasks assigned to one developer. In the "Developers" table you can inspect the assigned tasks for every developer.
