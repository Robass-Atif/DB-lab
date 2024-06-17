SELECT 
    COUNT(Session.UserID) AS NumberOfUsers,
    MONTH(Date) AS Month,
    WebsiteName,
    Country,
    Users.Gender,
    Users.Age,
    Users.AgeCategory,
    Pages.PageType,
    Pages.PageView,
    Website.BounceRate,
    Website.CategoryRank,
    Website.GlobalRank,
    CONVERT(varchar, Website.AverageVisitDuration, 108) AS AverageVisitDuration,
    Session.Browser,
    Session.Device,
     CASE WHEN Referrers.TrafficCount IS NULL THEN 0 ELSE Referrers.TrafficCount  END AS TrafficCount,
     CASE WHEN Referrers.ReferrerViews IS NULL THEN 0 ELSE Referrers.ReferrerViews END AS ReferrerViews,
	 Website.WebsiteVisits
FROM
    Session
    JOIN SessionPage ON SessionPage.SessionID = Session.SessionID
    JOIN Pages ON Pages.PageID = SessionPage.PageID 
    JOIN Website ON Website.WebsiteID = Pages.WebsiteID
    JOIN Users ON Users.UserID = Session.UserID 
    LEFT JOIN Referrers ON Website.WebsiteID = Referrers.WebsiteID
GROUP BY
    MONTH(Date),
    WebsiteName,
    Country,
    Users.Gender,
    Users.Age,
    Users.AgeCategory,
    Pages.PageType,
    Pages.PageView,
    Website.BounceRate,
    Website.CategoryRank,
    Website.GlobalRank,
    Session.Browser,
    Session.Device,
    TrafficCount,
	AverageVisitDuration,
    ReferrerViews,
	Website.WebsiteVisits
