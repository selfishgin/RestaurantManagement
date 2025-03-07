Create Table RefreshTokens(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Token] NVARCHAR(100) NOT NULL,
[UserId] INT NOT NULL,
[ExpirationDate] DATETIME2 NOT NULL,
)