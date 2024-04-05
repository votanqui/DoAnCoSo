đầu tiên cần chạy file script này vào sql :
------------------------------------------------------------------------------
USE [webaccgame]
GO
/****** Object:  Table [dbo].[acc]    Script Date: 25/03/2024 6:44:08 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[acc](
	[id_acc] [int] IDENTITY(1,1) NOT NULL,
	[account] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[so_mau_mat] [int] NULL,
	[so_tuong] [int] NULL,
	[so_skin] [int] NULL,
	[gia] [decimal](10, 2) NULL,
	[imageURL] [varchar](255) NULL,
 CONSTRAINT [PK_acc] PRIMARY KEY CLUSTERED 
(
	[id_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25/03/2024 6:44:09 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[roles] [int] NULL,
	[price] [decimal](10, 0) NULL,
	[gmail] [varchar](50) NULL,
 CONSTRAINT [PK_Users1] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[acc] ON 

INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL]) VALUES (1, N'trum12a4', N'kkk', 1, 2, 3, CAST(4000.00 AS Decimal(10, 2)), N'acc1.jpg')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL]) VALUES (2, N'kakak', N'akakak', 382, 938, 383, CAST(40000.00 AS Decimal(10, 2)), N'acc1.jpg')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL]) VALUES (3, N'kakak', N'i48k', 1, 34, 423, CAST(29313.00 AS Decimal(10, 2)), N'acc1.jpg')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL]) VALUES (8, N'trum12aaa', N'admin', 111, 123, 413, CAST(23432.00 AS Decimal(10, 2)), N'acc1.jpg')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL]) VALUES (9, N'trum12aaa222', N'aaaa', 234, 123, 1234, CAST(3242.00 AS Decimal(10, 2)), N'acc1.jpg')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL]) VALUES (10, N'trum12bbb', N'34234', 13, 123, 123, CAST(1312123.00 AS Decimal(10, 2)), N'acc1.jpg')
SET IDENTITY_INSERT [dbo].[acc] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (1, N'admin', N'admin', 1, CAST(1234 AS Decimal(10, 0)), N'aaa@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (2, N'a', N'a', 0, CAST(0 AS Decimal(10, 0)), N'a')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (6, N'vtquineeee', N'12345678', 0, CAST(0 AS Decimal(10, 0)), N'qui@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (7, N'1233456', N'234234asdf', 0, CAST(0 AS Decimal(10, 0)), N'catve167@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (8, N'votanqui', N'939922', 0, CAST(0 AS Decimal(10, 0)), N'votanqui29052003@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (9, N'vtquine', N'asdfasdf', 0, CAST(0 AS Decimal(10, 0)), N'qui@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (11, N'aaanek2', N'a1234567', 0, CAST(0 AS Decimal(10, 0)), N'catve167@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users1_roles]  DEFAULT ((0)) FOR [roles]
GO
-----------------------------------------------------------------------
sau khi cài đặt xong sẽ mở file trong visual studio bấm view -> server explorer -> sau đó add database mà vừa cài đặt xong.
tiếp theo vào web.config sửa lại đường dẫn tới database 
nếu các controller có lỗi ngay DataClasses1DataContext hãy để chuột ngay DataClasses1DataContext và sửa lỗi theo hướng dẫn sau đó vào DataClasses1.designer.cs trong Models , nếu như bấm sửa lỗi theo hướng dẫn ngay 
DataClasses1DataContext thì trong mục DataClasses1.designer.cs sẽ có dấu chấm đó báo lỗi , hãy xóa nó đi và thêm vào   public DataClasses1DataContext():
      base(global::System.Configuration.ConfigurationManager.ConnectionStrings["webaccgameConnectionString"].ConnectionString, mappingSource)
  {
      OnCreated();
  }
và ,lỗi này có thể lập đi lập lại vài lần nên cứ làm theo cho đến khi hết .
xong hết rồi thì run project.
