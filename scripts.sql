USE [master]
GO
/****** Object:  Database [ToDoApp]    Script Date: 4/18/2016 3:28:28 PM ******/
CREATE DATABASE [ToDoApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
GO
ALTER DATABASE [ToDoApp] SET COMPATIBILITY_LEVEL = 120
GO
USE [ToDoApp]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 4/18/2016 3:28:28 PM ******/
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Done] [bit] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([ItemId], [Description], [Done]) VALUES (1, N'Learn C#', 0)
INSERT [dbo].[Items] ([ItemId], [Description], [Done]) VALUES (2, N'Learn .NET', 0)
INSERT [dbo].[Items] ([ItemId], [Description], [Done]) VALUES (3, N'Conquer the internet', 0)
INSERT [dbo].[Items] ([ItemId], [Description], [Done]) VALUES (4, N'Make to do list', 0)
INSERT [dbo].[Items] ([ItemId], [Description], [Done]) VALUES (5, N'Walk the dog please', 0)
SET IDENTITY_INSERT [dbo].[Items] OFF
ALTER TABLE [dbo].[Items] ADD  DEFAULT ((0)) FOR [Done]
GO
USE [master]
GO
ALTER DATABASE [ToDoApp] SET  READ_WRITE 
GO
