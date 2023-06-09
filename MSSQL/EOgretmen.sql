USE [EOgretmen]
GO
/****** Object:  Table [dbo].[Table_Öğrenci]    Script Date: 31.05.2023 11:50:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Öğrenci](
	[Ögrİd] [smallint] IDENTITY(1,1) NOT NULL,
	[Ögrİsim] [varchar](20) NULL,
	[ÖgrSoyadı] [varchar](20) NULL,
	[ÖgrNo] [smallint] NULL,
	[ÖgrŞube] [varchar](5) NULL,
	[ÖgrNot1] [smallint] NULL,
	[ÖgrNot2] [smallint] NULL,
	[ÖgrProje] [smallint] NULL,
	[ÖgrOrtalaması] [smallint] NULL,
 CONSTRAINT [PK_Table_Öğrenci] PRIMARY KEY CLUSTERED 
(
	[Ögrİd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Öğretmen]    Script Date: 31.05.2023 11:50:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Öğretmen](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Öğretmenİsim] [varchar](12) NULL,
	[ÖğretmenSoyad] [varchar](20) NULL,
	[ÖğretmenTc] [varchar](12) NULL,
	[ÖğretmenSifre] [int] NULL,
 CONSTRAINT [PK_Table_Öğretmen] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Table_Öğretmen] ON 

INSERT [dbo].[Table_Öğretmen] ([id], [Öğretmenİsim], [ÖğretmenSoyad], [ÖğretmenTc], [ÖğretmenSifre]) VALUES (1, N'Mert', N'AL', N'1', 2)
INSERT [dbo].[Table_Öğretmen] ([id], [Öğretmenİsim], [ÖğretmenSoyad], [ÖğretmenTc], [ÖğretmenSifre]) VALUES (2, N'D', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Table_Öğretmen] OFF
GO
