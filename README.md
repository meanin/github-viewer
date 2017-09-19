# GithubViewer

ASP.NET MVC and WebAPI2 application for user profile search and repositories listing

In this project used are:

* Visual Studio 2017 
* C# 6.0 and C# 7.0 features
* ASP.net
* MVC 5
* WebAPI2
* Identity Server 3
* Owin
* Unity IoC
* Swashbuckle
* Swashbuckle.Examples (https://github.com/mattfrear/Swashbuckle.Examples)
* XUnit
* NSubtitute
* FluentAssertions

For use only restore nuget packages.



# Task (from: https://github.com/sdesyllas/github-explorer/blob/master/README.md)
Create an ASP.Net MVC website with a page containing a text box to enter a name in and a submit button to search GitHub for the name.

Have the back end call the GitHub users API (e.g. https://api.github.com/users/sdesyllas) and get the users name, location and avatar url from the returned json. Use the repos_url value to get a list of all the repos for the user.

On the results page, show the username, location, avatar and the 5 repos with the highest stargazer_count.
As an alternative to ASP.NET MVC client you can write your application using a console app project.

Use this opportunity to show us what you know, even if you wouldn’t ordinarily use the concepts in such a trivial example.

Upload your work to GitHub and send us the url of the repository. If you don’t have a GitHub account you can register for a free one at https://github.com/join. Please make sure that your repository is a public one.