SELECT COUNT(Id) FROM person

SELECT AVG(Age) FROM person

SELECT DISTINCT LastName FROM person
ORDER BY LastName ASC

SELECT LastName, COUNT(LastName) AS count
FROM person
GROUP BY LastName

SELECT LastName FROM person
WHERE LastName LIKE '%б%'

SELECT * FROM person
WHERE Id_Street = 0 /*must be NULL*/

SELECT FirstName, LastName, Age 
FROM person AS P 
INNER JOIN street AS S /*inner join could bereplaced with FROM person, street*/
ON S.Name = 'проспект Правды' 
AND S.Id = P.Id_Street
AND P.Age < 18

SELECT Name, COUNT(Name) AS Quantity
FROM street AS S
INNER JOIN person AS P
ON P.Id_Street = S.Id
GROUP BY Name

SELECT Name FROM street
WHERE LENGTH(Name) = 6

SELECT Name
FROM street AS S
INNER JOIN (
	SELECT Id_Street, COUNT(Id_Street) AS Quantity
	FROM person
	WHERE Id_Street > 0
	GROUP BY Id_Street
) AS Temp
ON S.Id = Temp.Id_Street
AND Temp.Quantity < 3
