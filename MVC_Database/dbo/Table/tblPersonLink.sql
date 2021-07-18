CREATE TABLE [dbo].[tblPersonLink]
(
	[PersonLinkId] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [PersonId] INT NOT NULL, 
    [LinkId] INT NOT NULL
)
