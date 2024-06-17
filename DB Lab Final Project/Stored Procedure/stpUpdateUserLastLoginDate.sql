CREATE PROCEDURE stpUpdateUserLastLoginDate
    @UserID INT,
    @LastLoginDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET LastLoginDate = @LastLoginDate
    WHERE UserID = @UserID;
END
