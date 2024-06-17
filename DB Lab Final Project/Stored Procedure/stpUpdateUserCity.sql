CREATE PROCEDURE stpUpdateUserCity
    @UserID INT,
    @City NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE UserDemographics
    SET City = @City
    WHERE UserID = @UserID;
END
