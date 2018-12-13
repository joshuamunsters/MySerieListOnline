SELECT *
FROM Serie AS a
INNER JOIN Episode AS b
ON a.id = b.serieid
INNER JOIN Episoderating AS c 
ON b.id = c.episodeid
WHERE serieid = 3 AND userid = 2