Projet School 2023

## Introduction

Bienvenue dans le **Projet School 2023**, une initiative ambitieuse visant à créer une interface MAUI complète pour la gestion des données scolaires. Dans le cadre de cet exercice, nous avons revisité les concepts explorés lors du laboratoire 2 (dispo sur https://quentin.lurkin.xyz/courses/poo/labs/lab2/index.pdf) pour concevoir une application offrant les fonctionnalités suivantes :

- Création et enregistrement d'enseignants.
- Création et enregistrement d'activités éducatives.
- Liaison entre les activités et les enseignants.
- Création et enregistrement des étudiants.
- Attribution d'évaluations (notes ou appréciations) pour les cours des étudiants.
- Affichage du bulletin des étudiants.

En plus des fonctionnalités essentielles, nous avons incorporé deux fonctionnalités supplémentaires pour améliorer l'expérience utilisateur :

1. **Thèmes Visuels Personnalisés :** Offrant une personnalisation visuelle, les utilisateurs peuvent choisir parmi différents thèmes pour adapter l'interface à leurs préférences et assurer un confort visuel optimal.

2. **Suppression Directe :** Pour une gestion pratique, les utilisateurs ont la possibilité de supprimer directement des enseignants, des étudiants, ou d'autres éléments directement au sein de l'application. Cela permet une manipulation efficace et rapide des données.

## Captures d'écrans

Pour une illustration complète de l'application, vous trouverez des captures d'écran dans le dossier *Screenshots*. Veuillez noter que l'ensemble du code a été développé et testé sur Windows, et les captures d'écran reflètent l'aspect de l'application sous cet OS.

![Acceuil](https://github.com/Mister-IZ/School_project_3BE/blob/main/Screenshots/MAUI%20(1).png?raw=true)

# 

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



# Diagramme UML :

Voici notre diagramme de classe afin de mieux comprendre les échanges entre nos classes Model et Repository :

![Image 3](https://github.com/Mister-IZ/School_project_3BE/blob/main/Images/Capture%20d%E2%80%99e%CC%81cran%202024-01-22%20a%CC%80%2021.56.40.png)

À noter que les couleurs n'ont pas de significations particulières, c'est juste pour la visibilité.
Les flèches normales sont bien des relations d'héritages.


Voici notre diagramme de séquence concernant le chargement des notes pour les étudiants :

![Image 4](https://github.com/Mister-IZ/School_project_3BE/blob/main/Images/Capture%20d%E2%80%99e%CC%81cran%202024-01-22%20a%CC%80%2021.56.48.png)

Certains messages n'ont pas de méthodes spécifiques car il s'agit juste d'un échange de données.

