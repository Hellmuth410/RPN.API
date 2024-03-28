# Roadmap

## Evolutions potentielles
- [ ] Actuellement, l'API est accessible sans login, par choix, car il n'y a aucun impact en dehors de la session donc ça ne me semblait pas pertinent.
	  Mais si on souhaite ajouter une authentification, on peut ajouter la gestion d'un JWT en tant que Bearer Token, qui est très bien géré avec Swagger notamment.
- [ ] La liste des opérateurs est actuellement fixe et définie dans le fichier RPN.Utils.Constants.
	  Pour rendre le code plus modulable, il faudrait que cette liste soit potentiellement dans une base de données, puis faire les calculs avec des évaluations (DataTable.Compute par exemple).
- [ ] De la même manière, j'ai utilisé un cache de 15min pour stocker les stack mais on pourrait les stocker en base de données si on souhaite les conserver à plus long terme.
- [ ] Concernant les services, pour le moment on peut les garder en static mais si la logic devient plus complexe, il faudrait enlever le static et les injecter dans les controller avec un AddTranscient probablement.