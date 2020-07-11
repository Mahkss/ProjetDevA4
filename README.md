# ProjetDevA4


- Ouvrir CSharpClient dans visual studio
- Ouvrir MiddlewareCSharp dans visual studio
- Ouvrir ReceptionJEE et TraitementJEE dans netbeans en tant que projets

Pour le client:
- Modifier si nécessaire les références de services connectés (service du middleware)

Pour le middleware:
- Mettre en place une bdd SQLServer avec une table users et y introduire un enregistrement
- Modidfier la chaine de connection dans UsersDAO
- Modifier si nécéssaires les références de service connectés (service JEE)

Pour JEE:
-Créer 2 domaines Glassfish: Reception et Traitement
-Créer 2 qeues JMS dans Réception: receptionQueue et traitementQueue
-Vérifier la présence de la dépendance au fichier à l'ojdbc, si besoin, l'ajouter manuellement

