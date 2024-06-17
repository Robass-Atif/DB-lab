CREATE PROCEDURE stpUpdateUserCountry
    @UserID INT,
    @Country NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE UserDemographics
    SET Country = @Country
    WHERE UserID = @UserID;
END
