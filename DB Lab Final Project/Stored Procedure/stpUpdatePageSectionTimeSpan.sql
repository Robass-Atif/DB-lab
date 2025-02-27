USE [WebsiteTraffic]
GO
/****** Object:  StoredProcedure [dbo].[stpUpdatePageSectionTimeSpan]    Script Date: 07/05/2024 11:49:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[stpUpdatePageSectionTimeSpan]
	-- Add the parameters for the stored procedure here
	@TimeSpan time(7),
	@pageSectionId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE PageSection SET TimeSpan =@TimeSpan  WHERE PageSectionID = @pageSectionId;

END
