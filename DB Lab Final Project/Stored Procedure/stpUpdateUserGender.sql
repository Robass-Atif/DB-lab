CREATE PROCEDURE stpUpdateUserGender
    @UserID INT,
    @Gender NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE UserDemographics
    SET UserDemographics.Gender = @Gender
    WHERE UserID = @UserID;
END
