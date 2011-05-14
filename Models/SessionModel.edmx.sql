
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/13/2011 19:28:52
-- Generated from EDMX file: C:\Dev\TechEd2011\Server\Models\SessionModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TechEdDemo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SessionTimeslot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sessions] DROP CONSTRAINT [FK_SessionTimeslot];
GO
IF OBJECT_ID(N'[dbo].[FK_SpeakerSession_Speaker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpeakerSession] DROP CONSTRAINT [FK_SpeakerSession_Speaker];
GO
IF OBJECT_ID(N'[dbo].[FK_SpeakerSession_Session]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpeakerSession] DROP CONSTRAINT [FK_SpeakerSession_Session];
GO
IF OBJECT_ID(N'[dbo].[FK_SpeakerSession1_Speaker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpeakerSession1] DROP CONSTRAINT [FK_SpeakerSession1_Speaker];
GO
IF OBJECT_ID(N'[dbo].[FK_SpeakerSession1_Session]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpeakerSession1] DROP CONSTRAINT [FK_SpeakerSession1_Session];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sessions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sessions];
GO
IF OBJECT_ID(N'[dbo].[Timeslots]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Timeslots];
GO
IF OBJECT_ID(N'[dbo].[Speakers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Speakers];
GO
IF OBJECT_ID(N'[dbo].[SpeakerSession]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpeakerSession];
GO
IF OBJECT_ID(N'[dbo].[SpeakerSession1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpeakerSession1];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NULL,
    [Room] nvarchar(max)  NULL,
    [Hash] nvarchar(max)  NULL,
    [Timeslot_Id] int  NOT NULL
);
GO

-- Creating table 'Timeslots'
CREATE TABLE [dbo].[Timeslots] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Start] datetime  NULL,
    [End] datetime  NULL
);
GO

-- Creating table 'Speakers'
CREATE TABLE [dbo].[Speakers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'SpeakerSession'
CREATE TABLE [dbo].[SpeakerSession] (
    [PrimarySpeakers_Id] int  NOT NULL,
    [Sessions_Id] int  NOT NULL
);
GO

-- Creating table 'SpeakerSession1'
CREATE TABLE [dbo].[SpeakerSession1] (
    [AssistantSpeakers_Id] int  NOT NULL,
    [SessionsAssistingWith_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [PK_Sessions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Timeslots'
ALTER TABLE [dbo].[Timeslots]
ADD CONSTRAINT [PK_Timeslots]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Speakers'
ALTER TABLE [dbo].[Speakers]
ADD CONSTRAINT [PK_Speakers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PrimarySpeakers_Id], [Sessions_Id] in table 'SpeakerSession'
ALTER TABLE [dbo].[SpeakerSession]
ADD CONSTRAINT [PK_SpeakerSession]
    PRIMARY KEY NONCLUSTERED ([PrimarySpeakers_Id], [Sessions_Id] ASC);
GO

-- Creating primary key on [AssistantSpeakers_Id], [SessionsAssistingWith_Id] in table 'SpeakerSession1'
ALTER TABLE [dbo].[SpeakerSession1]
ADD CONSTRAINT [PK_SpeakerSession1]
    PRIMARY KEY NONCLUSTERED ([AssistantSpeakers_Id], [SessionsAssistingWith_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Timeslot_Id] in table 'Sessions'
ALTER TABLE [dbo].[Sessions]
ADD CONSTRAINT [FK_SessionTimeslot]
    FOREIGN KEY ([Timeslot_Id])
    REFERENCES [dbo].[Timeslots]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionTimeslot'
CREATE INDEX [IX_FK_SessionTimeslot]
ON [dbo].[Sessions]
    ([Timeslot_Id]);
GO

-- Creating foreign key on [PrimarySpeakers_Id] in table 'SpeakerSession'
ALTER TABLE [dbo].[SpeakerSession]
ADD CONSTRAINT [FK_SpeakerSession_Speaker]
    FOREIGN KEY ([PrimarySpeakers_Id])
    REFERENCES [dbo].[Speakers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Sessions_Id] in table 'SpeakerSession'
ALTER TABLE [dbo].[SpeakerSession]
ADD CONSTRAINT [FK_SpeakerSession_Session]
    FOREIGN KEY ([Sessions_Id])
    REFERENCES [dbo].[Sessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SpeakerSession_Session'
CREATE INDEX [IX_FK_SpeakerSession_Session]
ON [dbo].[SpeakerSession]
    ([Sessions_Id]);
GO

-- Creating foreign key on [AssistantSpeakers_Id] in table 'SpeakerSession1'
ALTER TABLE [dbo].[SpeakerSession1]
ADD CONSTRAINT [FK_SpeakerSession1_Speaker]
    FOREIGN KEY ([AssistantSpeakers_Id])
    REFERENCES [dbo].[Speakers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SessionsAssistingWith_Id] in table 'SpeakerSession1'
ALTER TABLE [dbo].[SpeakerSession1]
ADD CONSTRAINT [FK_SpeakerSession1_Session]
    FOREIGN KEY ([SessionsAssistingWith_Id])
    REFERENCES [dbo].[Sessions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SpeakerSession1_Session'
CREATE INDEX [IX_FK_SpeakerSession1_Session]
ON [dbo].[SpeakerSession1]
    ([SessionsAssistingWith_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------