CREATE VIEW ShowReferrerView as 
Select (Select WebsiteName from Website where Website.WebsiteID=Referrers.WebsiteID) as WebsiteName , ReferrerName ,  (Select Value from Lookup where Lookup.ID=Referrers.ReferrerType) as ReferrerType,
ReferrerURL , ReferralVisits,TrafficCount
from Referrers