CREATE VIEW showSessionDataView AS 
SELECT S.SessionID, UserID, StartTime, EndTime, IPAddress, Device, Browser, PageID
FROM Sessions S JOIN 
SessionPages SP ON SP.SessionID = S.SessionID