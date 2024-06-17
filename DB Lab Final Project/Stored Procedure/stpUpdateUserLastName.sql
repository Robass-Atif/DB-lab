CREATE PROCEDURE stpUpdateUserLastName
    @UserID INT,
    @LastName NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET LastName = @LastName
    WHERE UserID = @UserID;
END
