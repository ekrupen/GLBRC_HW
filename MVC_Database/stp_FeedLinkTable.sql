CREATE PROCEDURE [dbo].[stp_FeedLinkTable]

	
AS
	declare @cnt int

	select @cnt = count(*) from tblLink

	if @cnt =0

BEGIN

INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('CNN','cnn.com', 1)
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Microsoft','microsoft.com', 1)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Code Academy','codeacademy.com', 0)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Google','Google.com', 1)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('nextflix','nextflix.com', 0)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Cnet','cnet.com', 0)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Yahoo','yahoo.com', 0)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Amazon','Amazon.com', 0)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('Udemy','Udemy.com', 0) 
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('NewEgg','newegg.com', 0)  
INSERT INTO [dbo].[tblLink]([LinkName],[LinkURL],[isDefault])   VALUES('UW','wisc.edu', 0)

END
RETURN 0
