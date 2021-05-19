# VeloMax Readme

## Sujet
[Lien du sujet](https://github.com/remSCS/VeloMax/blob/master/SujetV%C3%A9loMax.pdf)

## Membres de l'équipe :
- [Christophe NGUYEN](https://github.com/christopheng)
- Gwendoline MAREK
- [Rémi LOMBARD](https://github.com/remSCS)

## Schéma E/A de la base de données
![](/DB%20Hierarchical.svg)

## Connexion MySQL
![](/ScreenShotLogin.png)

### Option 1 : A distance
- Sélectionner "84.102.235.128" pour l'adresse du serveur de Rémi ou entrez l'adresse d'un serveur distant contenant la base de données
- Sélectionner "RemoteUser" pour l'identifiant
- Entrer "Password@123" pour le mot de passe

### Option 2 : En local
- Ouvrir MySQLWorkbench en local
- Se connecter à votre serveur MySQL
- [Exécuter le script](/VeloMaxDump.sql)
- Lancer le programme
- Sélectionner "localhost" pour l'adresse du serveur
- Sélectionner "root" pour l'identifiant si il est configuré sur votre serveur. Sinon, entrer un identifiant
- Entrer le mot de passe associé à l'identifiant
