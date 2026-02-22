# QAA1
Here I will collect all my knowledge on QAA with C#, CI/CD pipelines in Teamcity, Jenkins, docker, etc.
First thing that I did is I installed Visual Studio, created a project of type "class library", installed nuget packages: 
Selenium.Webdriver ; Selenium.Support ; NUnit;  Nunit3TestAdapter; Microsoft.Net.Test.SDK ; DotNetSeleniumExtras.WaitHelper (here conditions live like SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible).
I wrote the simplest test to open the google translate site.
Git repository was created and pushed by VS via few clicks inside of VS

Added a Page Object file for the google translate page, Base Page Object for any general functionalities for all Page Objects. All it does now is storing a ChromeDriver link for every page so that functional style could be implemented like PO1.InputWord("horse").ClickTranslate() - here in this chain of method calls (that is called a functional style) each method can return a new PO or the same PO, it does not matter, what matters is that a general single ChromeDriver is available for each PO.

The next step will be addition of automatic launches with TeamCity.

All the steps about connecting to TeamCity are recorded in 3 videos. It is all done intuitively and works surprisingly well:
1 video) In TeamCity Click "Connections". Now the address of the link is  http://localhost:8111/admin/editProject.html?projectId=Qaa1&tab=oauthConnections . Choose Github.com, follow instructions on registering TeamCity on Github adding the fields: 1) Home page URL (localhost:8111 - where my teamcity runs now); and 2) Authorization Callback. Receive Client ID and Client Secret ID from github after registering and add them  to TeamCity. The connection is Ready. Apparently now any repository from github is accesible via TeamCity. 
2 video) Now to run a project in TeamCity click  the plus sign to the right of "Projects" button. Find the QAA1 in the repositories list and choose it. It will create a project with all the steps automatically. The builds are done also automatically (after each commit to master on githb), because a trigger is also created automatically. The branches to check can be filtered as it is described here https://www.jetbrains.com/help/teamcity/2023.11/branch-filter.html?Branch+Filter#Branch+Filter+Format 

