-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE stpUpdateBounceRate 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

	SET NOCOUNT ON;

    
CREATE TABLE #BounceRates (
    WebsiteID NVARCHAR(50),
    BounceRate FLOAT
);


INSERT INTO #BounceRates (WebsiteID, BounceRate)
SELECT 
    SinglePageSessions.WebsiteID,
    ISNULL((CONVERT(FLOAT, SinglePageSessions) / NULLIF(TotalSessions, 0)) * 100, 0) AS BounceRate
FROM 
    (
       
        SELECT 
            w.WebsiteID,
            SUM(SinglePageSessions) AS SinglePageSessions
        FROM 
            Website w
        LEFT JOIN (
            SELECT 
                p.WebsiteID,
                COUNT(*) AS SinglePageSessions
            FROM 
                Pages p 
            JOIN 
                SessionPages sp ON p.PageID = sp.PageID
            GROUP BY 
                p.WebsiteID, sp.SessionID
            HAVING 
                COUNT(*) = 1
        ) AS SinglePageSessionCounts ON w.WebsiteID = SinglePageSessionCounts.WebsiteID
        GROUP BY 
            w.WebsiteID
    ) AS SinglePageSessions
JOIN 
    (
        
        SELECT 
            w.WebsiteID,
            COUNT(DISTINCT sp.SessionID) AS TotalSessions
        FROM 
            Website w
        JOIN 
            Pages p ON w.WebsiteID = p.WebsiteID
        JOIN 
            SessionPages sp ON p.PageID = sp.PageID
        GROUP BY 
            w.WebsiteID
    ) AS TotalSessions ON SinglePageSessions.WebsiteID = TotalSessions.WebsiteID;

UPDATE Website
SET BounceRate = #BounceRates.BounceRate
FROM Website
JOIN #BounceRates ON Website.WebsiteID = #BounceRates.WebsiteID;


DROP TABLE #BounceRates;
END
GO
