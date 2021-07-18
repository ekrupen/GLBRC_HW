CREATE PROCEDURE [dbo].[stp_TruncateTables]
	
AS
	Truncate Table dbo.Person
	Truncate Table dbo.PersonLink
RETURN 0
