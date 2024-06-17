CREATE PROCEDURE stpUpdateUserEmail
    @UserID INT,
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Users
    SET Email = @Email
    WHERE UserID = @UserID;
END
