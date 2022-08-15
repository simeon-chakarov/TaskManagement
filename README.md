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
