## Formation GoLogic Example de Projet
# ![Formation GoLogic Example de Projet](Gologic_icone_100.png)

## Pré-requis

Nous sommes excités d'explorer GitHub CoPilot avec vous dans le cadre d'exemples pratiques. Pour s'assurer le bon déroulement, assurez-vous de bien préparer votre poste de la manière suivante: 

- Installer Visual Studio Code [https://code.visualstudio.com/download](https://code.visualstudio.com/download)

- Une fois Visual Studio Code est sur votre système, installer le plugin SonarLint (Ouvrir VSCode, Ctrl+Shift+X, "SonarLint" dans la barre de recherche, cliquer "Install")

- Installer le .NET Core SDK (Version 8): [https://www.microsoft.com/net/download/core](https://www.microsoft.com/net/download/core)

- (OPTIONEL) Installer Postman pour assiter à faire des requêtes au backend : [https://www.postman.com/downloads/](https://www.postman.com/downloads/)


## Démarrer

- Ouvrir VSCode et ouvrir une nouvelle fenêtre (Ctrl+Shift+N)

- Dans le Welcome, cliquer sur "Clone Git Repository...", entrer le URL de ce repo (soit: [https://github.com/gologic-ca/Exemple-NetCore8-GHCopilot.git](https://github.com/gologic-ca/Exemple-NetCore8-GHCopilot.git)) et confirmer "Clone from the URL". Cliquer "Open". 

- Une fois le projet ouvert, ouvrir un nouveau terminal (Shift+Ctrl+`). Exécuter la commande: 
`dotnet run -p src/Conduit/Conduit.csproj`

Félicitations, le projet devrait maintenant être en train de rouler sur `http://localhost:5000/`
Ajouter une requête à la fin de l'URL pour voireles résultats

## URL Swagger

- `http://localhost:5000/swagger`

## GitHub Actions build

![Build and Test](https://github.com/gothinkster/aspnetcore-realworld-example-app/workflows/Build%20and%20Test/badge.svg)

## [Source et documentation](https://github.com/gothinkster/realworld)

ASP.NET Core codebase containing real world examples (CRUD, auth, advanced patterns, etc) that adheres to the [RealWorld](https://github.com/gothinkster/realworld-example-apps) spec and API.

This codebase was created to demonstrate a fully fledged fullstack application built with ASP.NET Core (with Feature orientation) including CRUD operations, authentication, routing, pagination, and more.

We've gone to great lengths to adhere to the ASP.NET Core community styleguides & best practices.

For more information on how to this works with other frontends/backends, head over to the [RealWorld](https://github.com/gothinkster/realworld) repo.
