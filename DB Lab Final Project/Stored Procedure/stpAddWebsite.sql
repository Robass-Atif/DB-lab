USE [WebsiteTraffic]
GO
/****** Object:  StoredProcedure [dbo].[stpAddWebsite]    Script Date: 5/4/2024 12:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[stpAddWebsite] 
	-- Add the parameters for the stored procedure here
	@WebsiteName  varchar(255),
	@WebsiteURL   varchar(255),
	@WebsiteIndustry int,
	@Description text
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Website 
	Values (@WebsiteName , @WebsiteURL , @WebsiteIndustry , @Description ,0 , 0 ,'00:00:00',0,0,0)
END
