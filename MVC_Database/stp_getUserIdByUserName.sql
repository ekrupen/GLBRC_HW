CREATE PROCEDURE [dbo].[stp_getUserIdByUserName]

	 @UserName nvarchar(50)='Anonymous'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @UserId int
	declare @cnt int

	-- if user does not exist then insert the user
	select @cnt = count(*)  from dbo.tblPerson
	where PersonName = @UserName

	

	-- insert user if it is new user either with name or Anonymous
	if @cnt =0
	Begin
	--insert new user
	Insert Into [dbo].[tblPerson](PersonName)
	values(@UserName)

	-- get new user Id
	select @UserId = PersonId from tblPerson
	where PersonName = @UserName

	-- insert defaul settings for new user
	insert into [dbo].[tblPersonLink](PersonId,LinkId)
	select @UserId, LinkId from [dbo].tblLink
	where isDefault =1

	
	END
	ELSE 
	BEGIN
	if @UserName ='Anonymous'
		BEGIN
	-- clean data for existing Anoninouse user. Set defaults.

	select @UserId = PersonId from tblPerson
	where PersonName = @UserName

	delete [dbo].[tblPersonLink]
	where PersonId = @UserId

	-- insert defaul settings for Anonymous
	insert into [dbo].[tblPersonLink](PersonId,LinkId)
	select @UserId, LinkId from [dbo].tblLink
	where isDefault =1

	

	END
	Else
	select @UserId = PersonId from tblPerson
	where PersonName = @UserName

	---
	END

	End
	select    @UserId