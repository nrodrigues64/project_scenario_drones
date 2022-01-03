# project_scenario_drones
But: Repérer les voitures critiques (avec un objet particulier)

Des voitures se déplacent sur le terrain certaine un objet en particulier sur la banquette arrière (cube, capsule, sphere, cylindre).
Des drones survolent la zone et repèrent les voitures, si la voiture est un voiture critique, il la suit. Les drones communique entre eux lorsqu'ils rencontrent une voiture.
Si un drone perd une voiture critique de vu, il signale, aux autres drones à proximité, la dernière position à laquelle il l'a perdu.


Au commencement il y'a un menu de démarrage qui permet de choisir le nombre de voiture que l'on veut (max: 10 de chaques).
En suite les voitures spawnent, ainsi que les drones, la simulation commencent. On peut changer de caméra à l'aide des flèches droite gauche du clavier.
Si on drague avec la souris on a une caméra qui suit le curseur ce qui permet de suivre un point en particulier.
Pour mettre en pause la simulation on peut appuyer sur "Echap", sur le menu pause on peut choisir quel est l'objet critique entre cube, sphere, cylindre, capsule ainsi les drones changent de cible à rechercher.
On peut également reset la simulation pour changer le nombre de véhicule sur le terrain.
Il y a une console qui permet de voire l'ensemble des messages que se transmettent les drônes.


Texture terrain :
https://assetstore.unity.com/packages/2d/textures-materials/nature/terrain-textures-pack-free-139542
Prefab voiture :
https://assetstore.unity.com/publishers/31689
Prefab drone :
https://assetstore.unity.com/publishers/52508
