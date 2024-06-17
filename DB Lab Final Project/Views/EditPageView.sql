CREATE VIEW EditPageView AS 
SELECT PageID, (SELECT WebsiteURL FROM Website W WHERE W.WebsiteID = P.WebsiteID) AS WebsiteURL, PageName
FROM Pages P;