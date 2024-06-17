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
CREATE PROCEDURE stpDeleteWebsite 
	-- Add the parameters for the stored procedure here
	@WebsiteID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRAN
	
		BEGIN TRY

    -- Insert statements for procedure here
	DELETE FROM SessionPages WHERE PageID in (SELECT PageID FROM Pages WHERE WebsiteID = @WebsiteID);
	DELETE FROM Events WHERE PageSectionID IN (SELECT PageSectionID FROM PageSection WHERE PageId IN (SELECT PageID FROM Pages WHERE WebsiteID = @WebsiteID));
	DELETE FROM PageSection WHERE PageID in (SELECT PageID FROM Pages WHERE WebsiteID = @WebsiteID);
	Delete from Pages where WebsiteID=@WebsiteID;
	Delete from Referrers where WebsiteID=@WebsiteID;
	Delete from Website where WebsiteID=@WebsiteID;

	COMMIT TRAN;
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN;
	END CATCH;
END
GO
