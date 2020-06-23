CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL
);

GO
CREATE TABLE [dbo].[Answer] (
    [AnswerId]     INT            IDENTITY (1, 1) NOT NULL,
    [AnswerDetail] NVARCHAR (MAX) NULL,
    [UpVotes]      INT            NOT NULL,
    [DownVotes]    INT            NOT NULL,
    [QuestionId]   INT            NOT NULL,
    [UserId]       INT            NOT NULL,
    [Vote]         INT            DEFAULT ((0)) NOT NULL
);

GO
CREATE TABLE [dbo].[LikeDislike] (
    [LikeDislikeId] INT IDENTITY (1, 1) NOT NULL,
    [AnswerId]      INT NOT NULL,
    [UserId]        INT NOT NULL,
    [Vote]          INT DEFAULT ((0)) NOT NULL
);

GO
CREATE TABLE [dbo].[Question] (
    [QuestionId]  INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [UserId]      INT            NOT NULL,
    [TagList]     NVARCHAR (MAX) NULL,
    [ImageUrl]    NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[User] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [Email]     NVARCHAR (MAX) NOT NULL,
    [Password]  NVARCHAR (MAX) NOT NULL,
    [ImageUrl]  NVARCHAR (MAX) NULL
);

GO
ALTER TABLE [dbo].[Answer]
    ADD CONSTRAINT [FK_dbo.Answer_dbo.Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([QuestionId]);

GO
ALTER TABLE [dbo].[Answer]
    ADD CONSTRAINT [FK_dbo.Answer_dbo.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]);

GO
ALTER TABLE [dbo].[Question]
    ADD CONSTRAINT [FK_dbo.Question_dbo.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]);

GO
ALTER TABLE [dbo].[__MigrationHistory]
    ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC);

GO
ALTER TABLE [dbo].[Answer]
    ADD CONSTRAINT [PK_dbo.Answer] PRIMARY KEY CLUSTERED ([AnswerId] ASC);

GO
ALTER TABLE [dbo].[LikeDislike]
    ADD CONSTRAINT [PK_dbo.LikeDislike] PRIMARY KEY CLUSTERED ([LikeDislikeId] ASC);

GO
ALTER TABLE [dbo].[Question]
    ADD CONSTRAINT [PK_dbo.Question] PRIMARY KEY CLUSTERED ([QuestionId] ASC);

GO
ALTER TABLE [dbo].[User]
    ADD CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_QuestionId]
    ON [dbo].[Answer]([QuestionId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Answer]([UserId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Question]([UserId] ASC);

GO
