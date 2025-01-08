# ![Formation GoLogic Example de Projet](Gologic.png)

## Pré-requis pour exemple de projet 

(Anglais à suivre)

Nous sommes ravis d'explorer GitHub Copilot avec vous à travers des exemples pratiques. Pour assurer le bon déroulement, veuillez préparer votre poste de travail de la manière suivante :

- Installer Visual Studio Code : [https://code.visualstudio.com/download](https://code.visualstudio.com/download)

- Une fois Visual Studio Code installé sur votre système, installez le plugin SonarLint (Ouvrir VSCode, Ctrl+Shift+X, saisir "SonarLint" dans la barre de recherche, cliquer sur "Install").

- Installer le .NET Core SDK (Version 8) : [https://www.microsoft.com/net/download/core](https://www.microsoft.com/net/download/core)

- (OPTIONNEL) Installer Postman pour faciliter les requêtes au backend : [https://www.postman.com/downloads/](https://www.postman.com/downloads/)


## Démarrer l'application

- Ouvrir VSCode et ouvrir une nouvelle fenêtre (Ctrl+Shift+N).

- Dans l'accueil, cliquer sur "Clone Git Repository...", entrer l'URL de ce dépôt (à savoir : [https://github.com/gologic-ca/Exemple-NetCore8-GHCopilot.git](https://github.com/gologic-ca/Exemple-NetCore8-GHCopilot.git)) et confirmer en cliquant sur "Clone from the URL". Cliquer sur "Open".

- Une fois le projet ouvert, ouvrir un nouveau terminal (Shift+Ctrl+\`). Exécuter la commande :
`dotnet run -p src/Conduit/Conduit.csproj`

Félicitations, le projet devrait maintenant être en cours d'exécution sur  `http://localhost:5000/`.
Ajoutez une requête à la fin de l'URL pour voir les résultats.

## URL Swagger

- `http://localhost:5000/swagger`

## GitHub Actions build

![Build and Test](https://github.com/gothinkster/aspnetcore-realworld-example-app/workflows/Build%20and%20Test/badge.svg)

## [Source et documentation](https://github.com/gothinkster/realworld)

La base de code ASP.NET Core contient des exemples concrets (CRUD, authentification, modèles avancés, etc.) qui respectent la spécification et l'API [RealWorld](https://github.com/gothinkster/realworld-example-apps).

Cette base de code a été créée pour montrer une application full-stack complète construite avec ASP.NET Core (avec une orientation fonctionnalité) incluant des opérations CRUD, de l'authentification, du routage, de la pagination, et plus encore.

Nous avons fait de notre mieux pour adhérer aux guides de style et aux meilleures pratiques de la communauté ASP.NET Core.

Pour plus d'informations sur le fonctionnement avec d'autres frontends/backends, rendez-vous sur le dépôt [RealWorld](https://github.com/gothinkster/realworld).


# ![Formation GoLogic Example de Projet](Gologic.png)


## Prerequisites 


We couldn't be more excited to explore GitHub Copilot with you via practical examples. To ensure a smooth process, please prepare your workstation as follows:

- Install Visual Studio Code : [https://code.visualstudio.com/download](https://code.visualstudio.com/download)

- Once Visual Studio Code is installed on your system, install the SonarLint plugin (Open VSCode, click Ctrl+Shift+X, insert "SonarLint" in the search bar and click on "Install").

- Install the .NET Core SDK (Version 8) : [https://www.microsoft.com/net/download/core](https://www.microsoft.com/net/download/core)

- (OPTIONAL) Install Postman to facilitate testing API calls to the backend : [https://www.postman.com/downloads/](https://www.postman.com/downloads/)


## Start the application

- Open VSCode and open a new window (Ctrl+Shift+N).

- On the landing page, click on "Clone Git Repository...", enter the URL of the example repository ([https://github.com/gologic-ca/Exemple-NetCore8-GHCopilot.git](https://github.com/gologic-ca/Exemple-NetCore8-GHCopilot.git)) and confirm your selection by clicking "Clone from the URL". Then, click on "Open".

- Once the project is open, open a new terminal (Shift+Ctrl+\`). Execute the following command :
`dotnet run -p src/Conduit/Conduit.csproj`

Congratulations, the project is now running locally on your machine at :  `http://localhost:5000/`.
Add a request endpoint at the end of the URL to view the results.

## Swagger URL

- `http://localhost:5000/swagger`

## GitHub Actions build

![Build and Test](https://github.com/gothinkster/aspnetcore-realworld-example-app/workflows/Build%20and%20Test/badge.svg)

## [Source et documentation](https://github.com/gothinkster/realworld)

The ASP.NET Core codebase contains concrete examples (CRUD, authentication, advanced patterns, etc.) that comply with the [RealWorld](https://github.com/gothinkster/realworld-example-apps) specification and API.

This codebase was created to showcase a complete full-stack application built with ASP.NET Core (feature-oriented) including CRUD operations, authentication, routing, pagination, and more.

We have done our best to adhere to the community's ASP.NET Core style guidelines and best practices.

For more information about operating with other frontends/backends, visit the [RealWorld](https://github.com/gothinkster/realworld) repository.
