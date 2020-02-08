CREATE TABLE [dbo].[Performances]
(
	[Id] INT NOT NULL , 
    [Performer_Id] INT FOREIGN KEY REFERENCES [Performers](Id) NOT NULL, 
    [Stage_Id] INT FOREIGN KEY REFERENCES [Stages](Id) NOT NULL, 
    [Start_Datetime] DATETIME NOT NULL, 
    [End_Datetime] DATETIME NOT NULL, 
    PRIMARY KEY ([Id])

)
