CREATE PROCEDURE stpGetUserIDByEmail
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserID INT;

    -- Get the UserID based on the Email
    SELECT @UserID = UserID
    FROM [Users]
    WHERE Email = @Email;

    -- Return the UserID
    SELECT @UserID AS UserID;
END
