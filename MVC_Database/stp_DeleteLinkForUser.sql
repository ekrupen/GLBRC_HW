CREATE PROCEDURE  [dbo].[stp_DeleteLinkForUser] 
	
	@LinkId int,
	@PersonID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 Delete from   tblPersonLink
 where PersonId = @PersonID and LinkId = @LinkId
END
RETURN 0
