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
CREATE PROCEDURE stpDeleteSession
	-- Add the parameters for the stored procedure here
	@SessionID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRY
		BEGIN TRAN
			UPDATE Pages SET PageViews -= (SELECT COUNT(*) FROM SessionPages WHERE SessionID = @SessionID AND SessionPages.PageID = Pages.PageID) WHERE PageID IN (SELECT PageID FROM SessionPages WHERE SessionID = @SessionID);
			DELETE FROM SessionPages WHERE SessionID = @SessionID;
			DELETE FROM Sessions WHERE SessionID = @SessionID;
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		ROLLBACK;
	END CATCH

END
GO
