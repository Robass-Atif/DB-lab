CREATE PROCEDURE stpUpdateUserRegistrationDate
    @UserID INT,
    @RegistrationDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET RegistrationDate = @RegistrationDate
    WHERE UserID = @UserID;
END
