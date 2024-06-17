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
CREATE PROCEDURE stpUpdateGlobalRank
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH RankedWebsites AS (
    SELECT
        WebsiteID,
        ROW_NUMBER() OVER (ORDER BY WebsiteVisits DESC) AS GlobalRank
    FROM
        Website
)
UPDATE w
SET GlobalRank = rw.GlobalRank
FROM Website w
JOIN RankedWebsites rw ON w.WebsiteID = rw.WebsiteID;
END
GO
