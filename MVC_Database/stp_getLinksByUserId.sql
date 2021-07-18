CREATE PROCEDURE [dbo].[stp_getLinksByUserId]	

	 @UserId  int =0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	

	begin
	-- get links user registed for
	select  L.LinkId, L.LinkName, L.LinkURL,  1 as 'isDefault'
	from tblLink L join  [dbo].[tblPersonLink] PL
	 on L.LinkId = PL.LinkId
	 where PL.PersonId = @UserId

	 union
	 -- get links user  NOT registed for
	 select   [LinkId], [LinkName], [LinkURL],  0 as IsDefault
	from [dbo].[tblLink] 
	where [LinkId] Not in( select [LinkId] from [dbo].[tblPersonLink] where PersonId = @UserId)

	
	 

	end

END
RETURN 0

