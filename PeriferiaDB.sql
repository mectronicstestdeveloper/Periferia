/****** Object:  Schema [Book]    Script Date: 6/2/2020 4:44:23 PM ******/
CREATE SCHEMA [Book]
GO
/****** Object:  Schema [DataMaster]    Script Date: 6/2/2020 4:44:23 PM ******/
CREATE SCHEMA [DataMaster]
GO
/****** Object:  Table [Book].[Book]    Script Date: 6/2/2020 4:44:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Book].[Book](
	[BookID] [uniqueidentifier] NOT NULL,
	[BookName] [nvarchar](80) NOT NULL,
	[BookReleaseDate] [datetime] NOT NULL,
	[BookPrice] [money] NOT NULL,
	[EditorialID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Book].[BookCategory]    Script Date: 6/2/2020 4:44:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Book].[BookCategory](
	[BookCategoryID] [uniqueidentifier] NOT NULL,
	[BookID] [uniqueidentifier] NOT NULL,
	[CategoryID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[BookCategoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataMaster].[Category]    Script Date: 6/2/2020 4:44:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataMaster].[Category](
	[CategoryID] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [DataMaster].[Editorial]    Script Date: 6/2/2020 4:44:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DataMaster].[Editorial](
	[EditorialID] [uniqueidentifier] NOT NULL,
	[EditorialName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Editorial] PRIMARY KEY CLUSTERED 
(
	[EditorialID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Book].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Editorial] FOREIGN KEY([EditorialID])
REFERENCES [DataMaster].[Editorial] ([EditorialID])
GO
ALTER TABLE [Book].[Book] CHECK CONSTRAINT [FK_Book_Editorial]
GO
ALTER TABLE [Book].[BookCategory]  WITH CHECK ADD  CONSTRAINT [FK_BookCategory_Book] FOREIGN KEY([BookID])
REFERENCES [Book].[Book] ([BookID])
GO
ALTER TABLE [Book].[BookCategory] CHECK CONSTRAINT [FK_BookCategory_Book]
GO
ALTER TABLE [Book].[BookCategory]  WITH CHECK ADD  CONSTRAINT [FK_BookCategory_Category] FOREIGN KEY([CategoryID])
REFERENCES [DataMaster].[Category] ([CategoryID])
GO
ALTER TABLE [Book].[BookCategory] CHECK CONSTRAINT [FK_BookCategory_Category]
GO
