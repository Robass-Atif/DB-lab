

CREATE PROCEDURE stpUpdateUserAge
    @UserID INT,
    @Age NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE UserDemographics
    SET Age = @Age
    WHERE UserID = @UserID;
END
