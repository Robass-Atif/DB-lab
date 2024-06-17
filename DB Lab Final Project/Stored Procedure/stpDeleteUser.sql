CREATE PROCEDURE stpDeleteUser
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Start a transaction
        BEGIN TRANSACTION;

        -- Delete records from the UserDemographics table
        DELETE FROM UserDemographics
        WHERE UserID = @UserID;
        -- Delete records from the SessionPage table
        DELETE FROM SessionPages
        WHERE SessionID IN (SELECT SessionID FROM Sessions WHERE UserID = @UserID);
        -- Delete records from the Sessions table
        DELETE FROM Sessions
        WHERE UserID = @UserID;
        -- Delete records from the User table
        DELETE FROM Users
        WHERE UserID = @UserID;

        -- Commit the transaction if all deletes are successful
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- If an error occurs, rollback the transaction to maintain data integrity
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        -- Rethrow the error
        THROW;
    END CATCH;
END;
