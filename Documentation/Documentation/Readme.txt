1- Steps to install and configure any prerequisites for the development environment

To test the intranet site, set the IntranetSite project as the startup project and run.
To test the two single page sites, set the SinglePageTestSite1 project as the startup project and run, then right click on the SinglePageTestSite2 > Debug > Start new instance

for the list of valid users and passwords, please refer to the online Ldap server site at: http://www.forumsys.com/en/tutorials/integration-how-to/ldap/online-ldap-test-server/

The development environment used for this project are 
	-visual studio community 2015 
	-Ldapadmin Ldap browser
	-An online Ldap test server. More info about the free test server on their site at: http://www.forumsys.com/en/tutorials/integration-how-to/ldap/online-ldap-test-server/

There are 7 projects in the solution, 4 of them are test environments, including unit testing. There are no other prerequisites to run the applications.

2- Steps to prepare the source code to build properly

The projects are independent and the libraries needed are imported into the project. note that only the web projects are able to run, the class libraries don't have a graphic environment.

In order for the unit test to run properly, set the IntratetSite project as the startup project and run the application. this will start the web service service and will be able to listen to calls to the endpoint. You can then stop the application and run the testcases.

The Http Module is referenced in the IIS via the web.config file, so no other work needs to be done to use the module. 

3- Any assumptions made and missing requirements that are not covered in the requirements

No authentication methods where specified in the requirements. For the intranet site and the http module the authentication method used was the form authentication.

4- Any feedback you wish to give about improving the assignment
perhaps instead of using HTTP Module you could ask for token based authentication or OAuth, but again, given the timeframe, it could be really challenging as well.