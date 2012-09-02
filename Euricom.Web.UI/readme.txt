GitHub
------

1. Create a free account
Create a free account on GitHub

2. Set Up Git
Download the native GitHub for Windows app
Install it
Sign in and setup git (name + e-mail)
Change the default storage location
Or alternatively follow the setup guide at GitHub.

3. Create Repository
Create a remote repository (initialize with README and .gitignore)
Start GitHub for Windows and clone the remote repository
Open a Shell for the local repository

4. Working with GitHub
Start Visual Studio and create a new solution
Perform an initial commit
  git status (untraced files)
  git add . (add untracked files)
  git commit -m "Description" (local commit)
  git push (push to remote repository)
  git log or git log --pretty=oneline (commit history)
Change some code
  git status
  git add .
  git commit -m "Description"
  Repeat the previous step
  Undo last local commit (git reset HEAD^) and push to the remote repository (git push)
  Clean up. Delete the remote and local repository

Twitter Bootstrap
-----------------

1. Download Twitter Bootstrap
Download the latest version of Twitter Bootstrap.

You can also customize the Twitter Bootstrap download. Choose the components, jQuery plugins and default look and feel.

2. Bootstrapping a Site
Start Visual Studio
Create a new ASP.NET MVC 4 project (empty template)
Add the bootstrap files (css, img and js) to the project
Include the latest jQuery version
Create a basic master layout (Views\Shared\_master.cshtml)
  Make to sure to set the HTML5 DOCTYPE
  Set to the viewport meta tag to support a responsive design
  Include the bootstrap CSS
    bootstrap.min.css
    custom.css
    bootstrap-responsive.min.css
  Include jQuery
  Include the bootstrap js library
Add a HomeController which has an Index action
Create a view for the Index action
Add a navbar which is fixed to the top
  Demonstrate Twitter Bootstrap's responsive design using the navbar
  Show effect of media queries in bootstrap-responsive.css

MongoDB
-------

1. Set Up MongoDB
Download MongoDB for Windows (32 or 64-bit)
Extract the archive to c:\mongodb (notice the bin subdirectory)
  MongoDB is self-contained and does not have any other system dependencies. You can run it from any folder you choose.
MongoDB requires a data folder to store its files. Start a Command Prompt and execute the following commands:
  cd \
  md data
  md data\db
To start MongoDB, execute the following commands from the Command Prompt:
  c:\mongodb\bin\mongod.exe

2. MongoDB as a Windows Service
Setup MongoDB as a Windows Service, so that the database will start automatically after each reboot
Open a Command Prompt (Run as Administrator) and execute the following commands:
  md c:\mongodb\log (stores MongoDB log files)
  echo logpath=c:\mongodb\log\mongo.log > c:\mongodb\mongod.cfg (Create MongoDB configuration file)
  c:\mongodb\bin\mongod.exe --config c:\mongodb\mongod.cfg --install (install the MongoDB service)
  net start MongoDB (run the service)

3. Manage MongoDB easily with MongoVUE
Download MongoVUE
Install it (be sure to allow the Windows Firewall exception)
Start MongoVUE and add a new connection
  Name: localhost
  Server: localhost
  Port: 27017

4. MongoDB C# driver
Download the MongoDB C# driver (NuGet) to work with MongoDB in .NET

Web API
-------

1. Reference Jef's session
2. Quick overview of Timesheet controller (show in browser)

Knockout
--------

1. Installation
Download the latest version of Knockout.
Reference the file using a <script> tag somewhere on your HTML pages
  <script type='text/javascript' src='knockout-2.1.0.js'></script>

AppHarbor
---------

1. Create a free account
Create a free account on AppHarbor

2. Continuous Deployment
Sign in to AppHarbor
Create an application
Find the "Create Build URL" button. This will copy the build URL into your clipboard.
  Example: https://appharbor.com:443/applications/euricomtunesiasession/builds?authorization=Ndo5LwHwjUuzdVgU0PbfQNRALBv%2fboFJp0dpNVAx078%3d
Sign in to GitHub
Go to your project's Admin section
Select the Service Hooks option
Select the AppHarbor service hook
Enter the following values:
  Application Slug: Name of application on AppHarbor
  Value of the "authorization" query parameter in the build URL
Make sure the option "Active" is checked and save the settings

Each time you push changes to the remote repository these will be pushed to AppHarbor which will automatically compile and publish your web project.