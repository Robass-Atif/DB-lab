CREATE VIEW ShowPagesView AS 
SELECT PageID, WebsiteID, (SELECT WebsiteURL FROM Website W WHERE W.WebsiteID = P.WebsiteID) AS WebsiteURL, PageName, (SELECT Value FROM Lookup WHERE Id = PageType) AS PageType, PageViews, TimeSpent
FROM Pages P