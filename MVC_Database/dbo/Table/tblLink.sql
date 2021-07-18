﻿CREATE TABLE [dbo].[tblLink]
(
	[LinkId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [LinkName] NVARCHAR(50) NOT NULL, 
    [LinkURL] NVARCHAR(MAX) NOT NULL, 
    [isDefault] BIT NOT NULL
)
