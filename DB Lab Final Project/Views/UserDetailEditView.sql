create VIEW UserDetailDeleteView AS 
SELECT 
    u.UserID,
    u.FirstName, 
    u.LastName, 
    u.Email, 
    u.RegistrationDate, 
    u.LastLoginDate, 
    ud.City, 
    ud.Country, 
    ud.Age, 
    ud.Gender
    
FROM 
    Users u
JOIN 
    UserDemographics ud ON u.UserID = ud.UserID
JOIN 
    [WebsiteTraffic].[dbo].[Lookup] l ON ud.AgeCategory = l.[ID];
