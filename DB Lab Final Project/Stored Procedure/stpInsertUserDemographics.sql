Create PROCEDURE stpInsertUserDemographics
    @UserID INT,
    @City NVARCHAR(255),
    @Country NVARCHAR(255),
    @Age INT,
    @Gender NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AgeCategory INT;

    -- Determine the age category based on the age
    IF @Age BETWEEN 0 AND 14
        SET @AgeCategory = 1; -- Children
    ELSE IF @Age BETWEEN 15 AND 24
        SET @AgeCategory = 2; -- Young Adults
    ELSE IF @Age BETWEEN 25 AND 64
        SET @AgeCategory = 3; -- Adults
    ELSE IF @Age >= 65
        SET @AgeCategory = 4; -- Seniors
    ELSE
        SET @AgeCategory = NULL; -- Handle other cases

    -- Insert statement for procedure here
    INSERT INTO UserDemographics (UserID, City, Country, Age, Gender, AgeCategory)
    VALUES (@UserID, @City, @Country, @Age, @Gender, @AgeCategory)
END
