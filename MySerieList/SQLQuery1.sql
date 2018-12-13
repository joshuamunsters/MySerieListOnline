SELECT a.[name], b.[name], c.rating
FROM Serie AS a
INNER JOIN Episode AS b
ON a.id = b.serieid
INNER JOIN Episoderating AS c
ON b.id = c.episodeid
