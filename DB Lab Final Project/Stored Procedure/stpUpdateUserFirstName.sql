CREATE PROCEDURE stpUpdateUserFirstName
    @UserID INT,
    @FirstName NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET FirstName = @FirstName
    WHERE UserID = @UserID;
END
