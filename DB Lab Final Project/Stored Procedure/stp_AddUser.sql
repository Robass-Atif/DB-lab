USE [WebsiteTraffic]
GO
/****** Object:  StoredProcedure [dbo].[stpAddUser]    Script Date: 5/1/2024 8:10:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[stpAddUser]
    -- Add the parameters for the stored procedure here
    @FirstName nvarchar(255),
    @LastName nvarchar(255),
    @Email nvarchar(255),
    @RegistrationDate datetime,
    @LastLoginDate datetime
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    INSERT INTO Users (FirstName, LastName, Email, RegistrationDate, LastLoginDate)
    VALUES (@FirstName, @LastName, @Email, @RegistrationDate, @LastLoginDate);
END
