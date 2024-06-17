CREATE VIEW SessionEditView AS
SELECT SessionID, UserID, StartTime, EndTime, IPAddress, Device, Browser
FROM Sessions