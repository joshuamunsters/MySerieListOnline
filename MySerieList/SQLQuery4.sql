SELECT  TOP 4 a.serieid, b.[name], b.[description], b.overallrating, COUNT(serieid) AS MOST_FREQUENT
from WatchListSeries AS a
INNER JOIN Serie AS b
ON b.id = a.serieid
GROUP BY serieid, b.[name], b.[description], b.overallrating
ORDER BY COUNT(serieid) desc

