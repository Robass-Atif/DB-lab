USE [WebsiteTraffic]
GO
/****** Object:  StoredProcedure [dbo].[stpDeletePage]    Script Date: 5/5/2024 10:48:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stpDeleteReferrer]
	-- Add the parameters for the stored procedure here
	@ReferrerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRAN
	
		BEGIN TRY

			DELETE FROM Referrers WHERE ReferrerID = @ReferrerID;
			
		COMMIT TRAN;
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN;
	END CATCH;
END
