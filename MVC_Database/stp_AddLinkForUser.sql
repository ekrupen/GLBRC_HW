CREATE PROCEDURE  [dbo].[stp_AddLinkForUser] 
	
	
	
	@LinkId int,
	@PersonID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @cnt int

	select @cnt = count(*) from tblPersonLink
	where PersonId = @PersonID and 
	LinkId = @LinkId

	if @cnt =0
	begin
 Insert Into  tblPersonLink(PersonId, LinkId)
 Values(@PersonID, @LinkId)
 end
END
RETURN 0

