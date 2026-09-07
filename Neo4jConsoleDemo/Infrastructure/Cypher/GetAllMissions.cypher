MATCH (p:Personne)-[r:A_TRAVAILLE_SUR]->(m:Mission)-[:POUR]->(c:Client)
RETURN p.nom AS personne, c.nom AS client, r.role AS role,
       m.date_debut AS date_debut, m.date_fin AS date_fin
ORDER BY p.nom, m.date_debut