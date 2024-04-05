đầu tiên cần chạy file script này vào sql :
------------------------------------------------------------------------------
USE [webaccgame]
GO
/****** Object:  Table [dbo].[acc]    Script Date: 05/04/2024 2:07:18 CH ******/
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
	[status] [varchar](50) NULL,
	[theloai] [varchar](50) NULL,
	[khuyenmai] [int] NULL,
	[giasaukhuyenmai] [decimal](10, 2) NULL,
 CONSTRAINT [PK_acc] PRIMARY KEY CLUSTERED 
(
	[id_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 05/04/2024 2:07:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[cartid] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NULL,
	[idacc] [int] NULL,
	[priceacc] [decimal](10, 2) NULL,
	[sotien] [decimal](10, 2) NULL,
	[userName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cartid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 05/04/2024 2:07:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[id_giohang] [int] IDENTITY(1,1) NOT NULL,
	[idnick] [int] NULL,
	[gianick] [decimal](18, 2) NULL,
	[image] [nvarchar](255) NULL,
	[Total] [decimal](18, 2) NULL,
	[userN] [nvarchar](255) NULL,
	[acc_count] [nvarchar](255) NULL,
	[pass_word] [nvarchar](255) NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[id_giohang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tuong]    Script Date: 05/04/2024 2:07:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tuong](
	[id_tuong] [int] IDENTITY(1,1) NOT NULL,
	[ma_tuong] [nvarchar](50) NULL,
	[imageURLtuong] [nvarchar](50) NULL,
	[name_tuong] [nvarchar](50) NULL,
	[id_acc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/04/2024 2:07:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NULL,
	[roles] [int] NULL,
	[price] [decimal](10, 0) NULL,
	[gmail] [varchar](50) NULL,
 CONSTRAINT [PK_Users1] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[acc] ON 

INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (1, N'trum12a4', N'kkk', 1, 2, 3, CAST(4000.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da up', NULL, NULL, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (3, N'kakak', N'i48k', 1, 34, 423, CAST(29313.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da up', NULL, NULL, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (8, N'trum12aaa', N'admin', 111, 123, 413, CAST(10086.68 AS Decimal(10, 2)), N'/Content/images/Annie.png', N'da ban', NULL, 10, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (9, N'trum12aaa222', N'aaaa', 234, 123, 1234, CAST(3242.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da up', NULL, NULL, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (10, N'trum12bbb', N'34234', 13, 123, 123, CAST(131.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da ban', NULL, NULL, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (11, N'trum12bbbaa', N'1231', 123, 12, 123, CAST(1.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da ban', NULL, NULL, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (17, N'acctest2', N'acctest2', 2, 2, 2, CAST(131.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da ban', NULL, NULL, NULL)
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (20, N'trum12aaa', N'aa', 213, 123, 231, CAST(23432.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da ban', N'lol', 0, CAST(23432.00 AS Decimal(10, 2)))
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (21, N'acctest4', N'acctest4', 12, 52, 63, CAST(98123.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da ban', N'lol', 10, CAST(88310.70 AS Decimal(10, 2)))
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (1021, N'acctest1', N'taaa', 1, 3, 4, CAST(29389.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da ban', N'lol', NULL, CAST(29389.00 AS Decimal(10, 2)))
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (1022, N'acctesst4', N'aa', 4, 3, 4, CAST(2.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da ban', N'lol', NULL, CAST(2.00 AS Decimal(10, 2)))
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai]) VALUES (1023, N'test1', N'test1', 1, 1, 1, CAST(1000.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da ban', N'lol', NULL, CAST(5.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[acc] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([cartid], [date], [idacc], [priceacc], [sotien], [userName]) VALUES (18, CAST(N'2024-04-05T11:37:55.460' AS DateTime), 1022, CAST(2.00 AS Decimal(10, 2)), CAST(8990.00 AS Decimal(10, 2)), N'testhoailuon')
INSERT [dbo].[Cart] ([cartid], [date], [idacc], [priceacc], [sotien], [userName]) VALUES (19, CAST(N'2024-04-05T11:57:18.850' AS DateTime), 1022, CAST(2.00 AS Decimal(10, 2)), CAST(8988.00 AS Decimal(10, 2)), N'testhoailuon')
INSERT [dbo].[Cart] ([cartid], [date], [idacc], [priceacc], [sotien], [userName]) VALUES (20, CAST(N'2024-04-05T12:08:18.713' AS DateTime), 1023, CAST(1000.00 AS Decimal(10, 2)), CAST(7990.00 AS Decimal(10, 2)), N'testhoailuon')
INSERT [dbo].[Cart] ([cartid], [date], [idacc], [priceacc], [sotien], [userName]) VALUES (21, CAST(N'2024-04-05T12:16:39.437' AS DateTime), 1023, CAST(1000.00 AS Decimal(10, 2)), CAST(6990.00 AS Decimal(10, 2)), N'testhoailuon')
INSERT [dbo].[Cart] ([cartid], [date], [idacc], [priceacc], [sotien], [userName]) VALUES (22, CAST(N'2024-04-05T12:17:06.527' AS DateTime), 1022, CAST(2.00 AS Decimal(10, 2)), CAST(6988.00 AS Decimal(10, 2)), N'testhoailuon')
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Tuong] ON 

INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (1, N'1-Annie', N'Annie.png', N'Annie', NULL)
SET IDENTITY_INSERT [dbo].[Tuong] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (1, N'admin', N'quivip', 1, CAST(669560 AS Decimal(10, 0)), N'aaa@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (15, N'testmd5', N'7a8b67849a68368dbf05b998971eed21', 0, CAST(0 AS Decimal(10, 0)), N'trum12a411@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (16, N'adminn', N'25d55ad283aa400af464c76d713c07ad', 0, CAST(0 AS Decimal(10, 0)), N'nhom8vippro@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (17, N'test1nek', N'9054b84fca7d9e43cd0e8ae633de73a9', 0, CAST(0 AS Decimal(10, 0)), N'test1ka@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (18, N'testmd6', N'122622283234e0eab3cd395624c65ba9', 0, CAST(9000 AS Decimal(10, 0)), N'testmd6@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (20, N'adminnek2', N'$2a$10$MriOEGoT1hiFp5QBMX9.Du7giihO/W0YESbkxlRJ5cO8nBo7EwOlO', 0, CAST(0 AS Decimal(10, 0)), N'adminnek2@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (21, N'khongranh', N'khongranh', 0, CAST(0 AS Decimal(10, 0)), N'khongranh@gmail.com')
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail]) VALUES (22, N'testhoailuon', N'cNSqTsGBb1L7yFwgyQucLSp0Z1ndAfldlyrc0ssl2Js=', 1, CAST(6988 AS Decimal(10, 0)), N'testhoailuon@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users1_roles]  DEFAULT ((0)) FOR [roles]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([idacc])
REFERENCES [dbo].[acc] ([id_acc])
GO
ALTER TABLE [dbo].[Tuong]  WITH CHECK ADD FOREIGN KEY([id_acc])
REFERENCES [dbo].[acc] ([id_acc])
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
