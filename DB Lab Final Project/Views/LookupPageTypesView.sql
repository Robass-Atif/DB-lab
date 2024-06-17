CREATE VIEW LookupPageTypesView AS
SELECT Id, Value
FROM Lookup
WHERE Category='PAGE_TYPE';