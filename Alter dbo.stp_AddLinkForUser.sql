USE [MVC_Database]
GO

/****** Object: SqlProcedure [dbo].[stp_AddLinkForUser] Script Date: 7/17/2021 6:28:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[stp_AddLinkForUser] 
	
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
