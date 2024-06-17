create VIEW UserDetailView AS 
SELECT 
  
    u.FirstName, 
    u.LastName, 
    u.Email, 
    u.RegistrationDate, 
    u.LastLoginDate, 
    ud.City, 
    ud.Country, 
    ud.Age, 
    ud.Gender, 
    l.Value AS AgeCategory
FROM 
    Users u
JOIN 
    UserDemographics ud ON u.UserID = ud.UserID
JOIN 
    [WebsiteTraffic].[dbo].[Lookup] l ON ud.AgeCategory = l.[ID];
