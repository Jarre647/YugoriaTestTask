CREATE OR ALTER PROCEDURE SearchAnimal 
	(@kinds nvarchar(max),
	@skinColorIds nvarchar(max),
	@regionIds nvarchar(max))
AS
BEGIN
SELECT a.AnimalName,
		k.KindAnimalName,
		l.LocationName,
		r.RegionName,
		s.SkinColorName
FROM Animals AS a
	JOIN KindAnimals as k
		ON a.KindAnimalId = k.Id
	JOIN Locations AS l 
		ON a.LocationId = l.Id
	JOIN Regions as r
		ON a.RegionId = r.Id
	JOIN SkinColors as s
		ON a.SkinColorId = s.Id
WHERE k.Id IN (SELECT value FROM string_split(@kinds, ','))
	AND r.Id IN (SELECT value FROM string_split(@regionIds, ','))
	AND s.Id IN (SELECT value FROM string_split(@skinColorIds, ','));
END