CREATE TABLE [_DbVersion] (
	 [Id] INT PRIMARY KEY IDENTITY (1,1)
		CONSTRAINT [_DbVersion_OneRowGuard] CHECK(Id = 1)
	,[Name] VARCHAR(32)
	,[Value] VARCHAR(16)
)
GO

INSERT [_DbVersion] ([Name], [Value])
VALUES ('Version', '0.0.0')
GO
