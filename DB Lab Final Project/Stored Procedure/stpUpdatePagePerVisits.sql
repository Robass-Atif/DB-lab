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
CREATE PROCEDURE stpUpdatePagePerVisits
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Website
SET pagePerVisit = COALESCE((
    SELECT pageViews * 1.0 / session_page_count
    FROM (
        SELECT p.websiteid, SUM(pageViews) AS PageViews, COUNT(s.pageid) AS session_page_count
        FROM pages p
        INNER JOIN sessionPages s ON p.pageid = s.pageid
        GROUP BY p.websiteid
    ) AS subquery
    WHERE subquery.websiteid = Website.websiteid
GROUP BY websiteID, session_page_count, pageViews
),0)
END
GO
