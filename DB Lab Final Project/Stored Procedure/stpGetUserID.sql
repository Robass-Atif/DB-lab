CREATE PROCEDURE stpGetUserID
    @Username NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserID INT;

    -- Get the UserID based on the Username
    SELECT @UserID = UserID
    FROM [User]
    WHERE Username = @Username;

    -- Return the UserID
    SELECT @UserID AS UserID;
END
