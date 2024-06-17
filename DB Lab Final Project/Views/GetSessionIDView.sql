CREATE VIEW GetSessionIDView AS
SELECT MAX(SessionID) AS SessionID
FROM Sessions;