# SAE_BD_S3A_Guimbeau_Leveque
## SQL dans un langage de programmation
## __Objectif__
A partir d'une base de donnée, d'effectué des requetes en C#, en utilisant du "mapping" objet-relationnel 

## __Livrable__
Une application (avec le code) effectuant 2 requete d'intérogation. 

## __Contrainte__
- Seules les commandes SQL  SELECT, FROM, JOIN, WHERE et ORDER BY sont autorisées tandis que les clauses GROUP BY et 
HAVING (et donc CUBE, GROUPING SETS et ROLLUP) et fonctions de fenêtrage (ROW_NUMBER, RANK et donc OVER()) sont __interdites__.
- A partir d'une base de donnée, d'effectué des requetes en C#, en utilisant du __"mapping" objet-relationnel__.


## __Les requetes__
1. Afficher la moyenne des notes et le
nombre de notes des 42 premiers élèves (par rapport à son ID) pour chacun des DS n°1, 2, et 3 et afficher en plus le cumuls par élève et épreuve, par élève, et pour tous les élèves \
- <u>La requete</u> :
>SELECT EPR_REF_ELV , EPR_Abrv , AVG(EPR_Note) Moy_Epr_Note , COUNT(*) Nb_Epr_Elv \
FROM T_Epreuve_EPR \
-- sans JOIN T_Eleve_ELV ON ELV_Id = EPR_REF_ELV \
WHERE EPR_REF_ELV < 42 AND EPR_Abrv BETWEEN 'CC1' AND 'CC3' \
GROUP BY ROLLUP( EPR_REF_ELV , EPR_Abrv ) \
ORDER BY EPR_REF_ELV DESC , EPR_Abrv DESC

2. Afficher l’identifiant, le nom de l’élève, un n° de ligne (pourquoi pas), le rang pour l’ordre des identifiants des élèves,
l’année de récompense et le numéro d’ordre de la récompense pour chaque élève de la classe Hadron et ont un ID au moins égal à 837. Le résultat est trié par identifiant d’élève et année de récompense. 
- <u>la requete</u> :
>SELECT ELV_Id , \
&nbsp;&nbsp;&nbsp;&nbsp;ELV_Nom ,\
&nbsp;&nbsp;&nbsp;&nbsp;ROW_NUMBER() OVER(ORDER BY ELV_Id DESC) Num_Ligne, \
&nbsp;&nbsp;&nbsp;&nbsp;RANK() OVER(ORDER BY ELV_Id DESC) Rg_Id , \
&nbsp;&nbsp;&nbsp;&nbsp;RCP_Annee , \
&nbsp;&nbsp;&nbsp;&nbsp;RANK() OVER(PARTITION BY ELV_Id ORDER BY RCP_Annee) Rg_Annee_par_Id \
FROM T_Classe_CLS \
JOIN T_Eleve_ELV ON CLS_Num = ELV_REF_CLS \
JOIN T_Recompense_RCP ON ELV_Id = RCP_REF_ELV \
WHERE CLS_Intit = 'Hadron' AND ELV_Id >= 837 \
ORDER BY ELV_Id DESC , RCP_Annee 
## __Avancement__
- 07/11/2022 : \
Création du git et du ReadMe \
Début du code : Class Eleve, (à complété)
