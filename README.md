# Principes SOLID

Les principes SOLID sont un ensemble de cinq principes de conception logicielle qui visent à créer des systèmes logiciels plus compréhensibles, flexibles et maintenables. Ce sont des principes clés pour le développement logiciel orienté objet.

## Principe 1 : Single Responsibility Principle

Les classes et les méthodes ne doivent être responsables que d'une chose. Cela permet d'avoir une grande cohésion.

## Principe 2 : Open/Closed Principle

- Open: Le code doit être ouvert aux extensions. On doit pouvoir ajouter des fonctionnalités.
- Closed: Le code doit être fermé aux modifications (sans modifier le code existant).

## Principe 3 : Liskov Substitution Principle

Un type devrait pouvoir être remplacé par un sous-type. LSP impose qu'un remplacement par un sous-type doit toujours avoir du sens.

## Principe 4 : Interface Segregation Principle

Il est préférable d'avoir plusieurs interfaces spécifiques qu'une seule interface générique. Une classe ne devrait pas être forcée d'implémenter des interfaces qu'elle n'utilise pas.

## Principe 5 : Dependency Inversion Principle

Les modules de haut niveau ne devraient pas dépendre des modules de bas niveau. Les deux devraient dépendre de l'abstraction. De plus, les abstractions ne devraient pas dépendre des détails, mais les détails devraient dépendre des abstractions.

## Illustration via notre projet

Lors de la réalisation de notre projet, nous avons utilisé certains de ces principes. Voici quelques exemples et explications.

### Exemple du SRP :

![Exemple du SRP](https://github.com/Mister-IZ/School_project_3BE/blob/main/Images/Capture%20d%E2%80%99e%CC%81cran%202023-12-21%20a%CC%80%2021.46.06.png?raw=true)

Comme vous pouvez le constater, la classe `ActivityRepository` dans le fichier `Activity.repository.cs` suit le SRP en se concentrant sur la responsabilité unique de sauvegarder les activités dans un fichier texte (`SaveActivitys`). Elle ne s'occupe pas d'autres responsabilités, telles que l'affichage ou la manipulation d'objets d'activité.

### Exemple du LSP :

![Image 1](https://github.com/Mister-IZ/School_project_3BE/blob/main/Images/Capture%20d%E2%80%99e%CC%81cran%202023-12-21%20a%CC%80%2021.49.24.png?raw=true) ![Image 2](https://github.com/Mister-IZ/School_project_3BE/blob/main/Images/Capture%20d%E2%80%99e%CC%81cran%202023-12-21%20a%CC%80%2021.51.31.png?raw=true)


Dans la classe `ActivityPage` par exemple, on utilise l'héritage pour étendre les fonctionnalités de `ContentPage` afin de créer des pages spécifiques à notre application. Les instances de `ActivityPage` et `ActivityPage2` peuvent être utilisées partout où une instance de `ContentPage` est attendue, comme lors de la navigation dans l'application. Ces sous-classes peuvent être utilisées de manière transparente à la place de la classe de base (`ContentPage`) sans affecter la validité du programme.
