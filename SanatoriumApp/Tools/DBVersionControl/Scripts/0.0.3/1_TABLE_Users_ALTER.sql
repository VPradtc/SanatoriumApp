IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Salary'
          AND Object_ID = Object_ID(N'dbo.Users'))
BEGIN
	ALTER TABLE Users
	ADD Salary DECIMAL DEFAULT(0)
END
