CREATE VIEW DeleteReferrerView as

SELECT ReferrerID ,  (SELECT WebsiteName
                  FROM      dbo.Website
                  WHERE   (WebsiteID = dbo.Referrers.WebsiteID)) AS WebsiteName, ReferrerName,
                      (SELECT Value
                       FROM      dbo.Lookup
                       WHERE   (ID = dbo.Referrers.ReferrerType)) AS ReferrerType, ReferrerURL, ReferralVisits, TrafficCount
FROM     dbo.Referrers