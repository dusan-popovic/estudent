CREATE DATABASE [estudentDB]
--USE [estudentDB]
GO

USE [estudentDB]
GO

--/****** Object:  Table [dbo].[Ispiti]    Script Date: 08.10.2017. 14:38:18 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
CREATE TABLE [dbo].[Ispiti](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BI] [nvarchar](max) NOT NULL,
	[Predmet] [nvarchar](max) NOT NULL,
	[Ocena] [int] NOT NULL,
PRIMARY KEY CLUSTERED(	[ID] ASC)
--WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
-- ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Studenti]    Script Date: 08.10.2017. 14:38:18 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
CREATE TABLE [dbo].[Studenti](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BI] [nvarchar](max) NOT NULL,
	[Ime] [nvarchar](max) NOT NULL,
	[Prezime] [nvarchar](max) NOT NULL,
	[Adresa] [nvarchar](max) NOT NULL,
	[Grad] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED(	[ID] ASC)
--WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) --ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
