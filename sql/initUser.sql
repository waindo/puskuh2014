USE [sde]
GO

/****** Object:  Table [sde].[CODES]    Script Date: 05/29/2014 19:22:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sde].[CODES]') AND type in (N'U'))
DROP TABLE [sde].[CODES]
GO

USE [sde]
GO

/****** Object:  Table [sde].[CODES]    Script Date: 05/29/2014 19:22:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [sde].[CODES](
	[codesHead] [varchar](50) NOT NULL,
	[codesCodes] [varchar](50) NOT NULL,
	[codesDesc] [varchar](50) NOT NULL
) ON [PRIMARY]

GO



USE [sde]
GO

/****** Object:  Table [sde].[userlist]    Script Date: 05/29/2014 19:23:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sde].[userlist]') AND type in (N'U'))
DROP TABLE [sde].[userlist]
GO

USE [sde]
GO

/****** Object:  Table [sde].[userlist]    Script Date: 05/29/2014 19:23:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [sde].[userlist](
	[username] [varchar](50) NOT NULL,
	[unit] [varchar](50) NULL,
	[pwd] [varchar](100) NULL,
	[firstname] [varchar](100) NULL,
	[lastname] [varchar](100) NULL,
 CONSTRAINT [PK_userlist] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO sde.CODES
SELECT '100',	'1',	'Administrator'

INSERT INTO sde.CODES
SELECT '100',	'2',	'User'

INSERT INTO sde.userlist
SELECT 'admin',	'1',	'admin',	'admin',	'puskuh'