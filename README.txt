đầu tiên cần chạy file script này vào sql :
------------------------------------------------------------------------------
CREATE DATABASE webaccgame;
USE [webaccgame]
GO
/****** Object:  Table [dbo].[acc]    Script Date: 18/04/2024 11:32:22 SA ******/
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
	[rank] [nvarchar](50) NULL,
	[matuong] [nvarchar](max) NULL,
 CONSTRAINT [PK_acc] PRIMARY KEY CLUSTERED 
(
	[id_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 18/04/2024 11:32:22 SA ******/
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
	[taikhoan] [nvarchar](50) NULL,
	[pass] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cartid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 18/04/2024 11:32:22 SA ******/
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
/****** Object:  Table [dbo].[mbbank]    Script Date: 18/04/2024 11:32:22 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mbbank](
	[id_mbbank] [int] IDENTITY(1,1) NOT NULL,
	[magd] [nvarchar](255) NULL,
	[sodu] [decimal](18, 0) NULL,
	[noidung] [nvarchar](255) NULL,
	[ngaytao] [datetime] NULL,
	[trangthai] [nvarchar](255) NULL,
	[taikhoan] [nvarchar](255) NULL,
 CONSTRAINT [PK_mbbank] PRIMARY KEY CLUSTERED 
(
	[id_mbbank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tuong]    Script Date: 18/04/2024 11:32:22 SA ******/
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
/****** Object:  Table [dbo].[thecao]    Script Date: 18/04/2024 11:32:22 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thecao](
	[idthecao] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[menhgia] [int] NOT NULL,
	[seri] [nvarchar](max) NULL,
	[pin] [nvarchar](max) NULL,
	[APIKey] [nvarchar](255) NOT NULL,
	[callback] [nvarchar](255) NOT NULL,
	[content] [nvarchar](255) NOT NULL,
	[NgayTao] [datetime] NULL,
	[tenuser] [nvarchar](255) NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_thecao] PRIMARY KEY CLUSTERED 
(
	[idthecao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/04/2024 11:32:22 SA ******/
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
	[status] [int] NULL,
 CONSTRAINT [PK_Users1] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[acc] ON 

INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1045, N'trum12aaa', N'quivip', 2, 167, 242, CAST(234.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da ban', N'lol', NULL, CAST(234.00 AS Decimal(10, 2)), N'cao thủ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1046, N'acctest1', N'acctest1', 2, 167, 243, CAST(12.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(12.00 AS Decimal(10, 2)), N'c', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1047, N'acctest2', N'acctest2', 32, 167, 456, CAST(8374.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(8374.00 AS Decimal(10, 2)), N'bạch kim', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1048, N'acctest3', N'acctest3', 45, 139, 54, CAST(4256.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(4256.00 AS Decimal(10, 2)), N'cao thủ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1049, N'acctest4', N'acctest4', 32, 79, 567, CAST(5461.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(5461.00 AS Decimal(10, 2)), N'không', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1050, N'acctest5', N'acctest5', 42, 142, 341, CAST(34523.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da up', N'lol', NULL, CAST(34523.00 AS Decimal(10, 2)), N'cao ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1051, N'acctest6', N'acctest6', 32, 104, 252, CAST(24352.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(24352.00 AS Decimal(10, 2)), N'cao thủ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1052, N'acctest7', N'acctest7', 34, 104, 83, CAST(3252.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(3252.00 AS Decimal(10, 2)), N'cao thủ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1053, N'acctest8', N'acctest8', 234, 104, 452, CAST(3452.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(3452.00 AS Decimal(10, 2)), N'bạch kim', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1054, N'acctest9', N'acctest9', 24, 167, 435, CAST(26255.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(26255.00 AS Decimal(10, 2)), N'thách đấu ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1055, N'acctest10', N'acctest10', 241, 154, 341, CAST(39531.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(39531.00 AS Decimal(10, 2)), N'kim cương', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1056, N'acctest11', N'acctest11', 46, 154, 358, CAST(45436.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da up', N'lol', NULL, CAST(45436.00 AS Decimal(10, 2)), N'vàng ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1057, N'acctest12', N'acctest12', 56, 167, 765, CAST(9724.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(9724.00 AS Decimal(10, 2)), N'kim cương', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1058, N'acctest13', N'acctest13', 35, 167, 467, CAST(72842.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(72842.00 AS Decimal(10, 2)), N'kim cương', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1059, N'acctest14', N'acctest14', 183, 167, 983, CAST(97835.00 AS Decimal(10, 2)), N'/Content/images/acc2.jpg', N'da up', N'lol', NULL, CAST(97835.00 AS Decimal(10, 2)), N'thách đấu ', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
INSERT [dbo].[acc] ([id_acc], [account], [password], [so_mau_mat], [so_tuong], [so_skin], [gia], [imageURL], [status], [theloai], [khuyenmai], [giasaukhuyenmai], [rank], [matuong]) VALUES (1060, N'acctestvip1', N'acctestvip1', 42, 167, 43, CAST(9282.00 AS Decimal(10, 2)), N'/Content/images/acc1.jpg', N'da up', N'lol', NULL, CAST(9282.00 AS Decimal(10, 2)), N'kim cương', N'1-Annie|2-Olaf|3-Galio|4-Twisted Fate|5-Xin Zhao|6-Urgot|7-LeBlanc|8-Vladimir|9-Fiddlesticks|10-Kayle|11-Master Yi|12-Alistar|13-Ryze|14-Sion|15-Sivir|16-Soraka|17-Teemo|18-Tristana|19-Warwick|20-Nunu & Willump|21-Miss Fortune|22-Ashe|23-Tryndamere|24-Jax|25-Morgana|26-Zilean|27-Singed|28-Evelynn|29-Twitch|30-Karthus|31-Cho''Gath|32-Amumu|33-Rammus|34-Anivia|35-Shaco|36-Dr. Mundo|37-Sona|38-Kassadin|39-Irelia|40-Janna|41-Gangplank|42-Corki|43-Karma|44-Taric|45-Veigar|48-Trundle|50-Swain|51-Caitlyn|53-Blitzcrank|54-Malphite|55-Katarina|56-Nocturne|57-Maokai|58-Renekton|59-Jarvan IV|60-Elise|61-Orianna|62-Ngộ Không|63-Brand|64-Lee Sin|67-Vayne|68-Rumble|69-Cassiopeia|72-Skarner|74-Heimerdinger|75-Nasus|76-Nidalee|77-Udyr|78-Poppy|79-Gragas|80-Pantheon|81-Ezreal|82-Mordekaiser|83-Yorick|84-Akali|85-Kennen|86-Garen|89-Leona|90-Malzahar|91-Talon|92-Riven|96-Kog''Maw|98-Shen|99-Lux|101-Xerath|102-Shyvana|103-Ahri|104-Graves|105-Fizz|106-Volibear|107-Rengar|110-Varus|111-Nautilus|112-Viktor|113-Sejuani|114-Fiora|115-Ziggs|117-Lulu|119-Draven|120-Hecarim|121-Kha''Zix|122-Darius|126-Jayce|127-Lissandra|131-Diana|133-Quinn|134-Syndra|136-Aurelion Sol|141-Kayn|142-Zoe|143-Zyra|145-Kai''Sa|147-Seraphine|150-Gnar|154-Zac|157-Yasuo|161-Vel''Koz|163-Taliyah|164-Camille|166-Akshan|200-Bel''Veth|201-Braum|202-Jhin|203-Kindred|221-Zeri|222-Jinx|223-Tahm Kench|233-Briar|234-Viego|235-Senna|236-Lucian|238-Zed|240-Kled|245-Ekko|246-Qiyana|254-Vi|266-Aatrox|267-Nami|268-Azir|350-Yuumi|360-Samira|412-Thresh|420-Illaoi|421-Rek''Sai|427-Ivern|429-Kalista|432-Bard|497-Rakan|498-Xayah|516-Ornn|517-Sylas|518-Neeko|523-Aphelios|526-Rell|555-Pyke|711-Vex|777-Yone|875-Sett|876-Lillia|887-Gwen|888-Renata Glasc|895-Nilah|897-K''Sante|901-Smolder|902-Milio|910-Hwei|950-Naafiri')
SET IDENTITY_INSERT [dbo].[acc] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([cartid], [date], [idacc], [priceacc], [sotien], [userName], [taikhoan], [pass]) VALUES (31, CAST(N'2024-04-15T21:38:16.690' AS DateTime), 1045, CAST(234.00 AS Decimal(10, 2)), CAST(4111.00 AS Decimal(10, 2)), N'testhoailuon', N'trum12aaa', N'quivip')
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([id_giohang], [idnick], [gianick], [image], [Total], [userN], [acc_count], [pass_word]) VALUES (42, 1045, CAST(234.00 AS Decimal(18, 2)), N'/Content/images/acc2.jpg', CAST(234.00 AS Decimal(18, 2)), N'testhoailuon', N'trum12aaa', N'quivip')
INSERT [dbo].[GioHang] ([id_giohang], [idnick], [gianick], [image], [Total], [userN], [acc_count], [pass_word]) VALUES (43, 1046, CAST(12.00 AS Decimal(18, 2)), N'/Content/images/acc2.jpg', CAST(12.00 AS Decimal(18, 2)), N'toilauser', N'acctest1', N'acctest1')
SET IDENTITY_INSERT [dbo].[GioHang] OFF
GO
SET IDENTITY_INSERT [dbo].[mbbank] ON 

INSERT [dbo].[mbbank] ([id_mbbank], [magd], [sodu], [noidung], [ngaytao], [trangthai], [taikhoan]) VALUES (6, N'FT24106310287836\BNK', CAST(10000 AS Decimal(18, 0)), N'CUSTOMER toilauser - Ma giao dich/ Trace7033 50 Trace 703350', CAST(N'2024-04-14T20:08:35.427' AS DateTime), N'Thành công', NULL)
INSERT [dbo].[mbbank] ([id_mbbank], [magd], [sodu], [noidung], [ngaytao], [trangthai], [taikhoan]) VALUES (7, N'FT24106272916196\BNK', CAST(10000 AS Decimal(18, 0)), N'CUSTOMER vtquine - Ma giao dich/ Trace891861  Trace 891861', CAST(N'2024-04-14T22:26:06.220' AS DateTime), N'Thành công', NULL)
SET IDENTITY_INSERT [dbo].[mbbank] OFF
GO
SET IDENTITY_INSERT [dbo].[Tuong] ON 

INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (1, N'1-Annie', N'Annie.png', N'Annie', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (2, N'2-Olaf', N'Olaf.png', N'Olaf', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (3, N'3-Galio', N'Galio.png', N'Galio', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (4, N'4-Twisted Fate', N'Twisted.png', N'Twisted Fate', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (5, N'5-Xin Zhao', N'Xin Zhao.png', N'Xin Zhao', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (6, N'6-Urgot', N'Urgot.png', N'Urgot', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (7, N'7-LeBlanc', N'LeBlanc.png', N'LeBlanc', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (8, N'8-Vladimir', N'Vladimir.png', N'Vladimir', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (9, N'9-Fiddlesticks', N'Fiddlesticks.png', N'Fiddlesticks', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (10, N'10-Kayle', N'Kayle.png', N'Kayle', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (11, N'11-Master Yi', N'Master Yi.png', N'Master Yi', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (12, N'12-Alistar', N'Alistar.png', N'Alistar', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (13, N'13-Ryze', N'Ryze.png', N'Ryze', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (14, N'14-Sion', N'Sion.png', N'Sion', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (15, N'15-Sivir', N'Sivir.png', N'Sivir', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (16, N'16-Soraka', N'Soraka.png', N'Soraka', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (17, N'17-Teemo', N'Teemo.png', N'Teemo', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (18, N'18-Tristana', N'Tristana.png', N'Tristana', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (19, N'19-Warwick', N'Warwick.png', N'Warwick', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (20, N'20-Nunu & Willump', N'Nunu & Willump.png', N'Nunu & Willump', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (21, N'21-Miss Fortune', N'Miss Fortune.png', N'Miss Fortune', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (22, N'22-Ashe', N'Ashe.png', N'Ashe', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (23, N'23-Tryndamere', N'Tryndamere.png', N'Tryndamere', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (24, N'24-Jax', N'Jax.png', N'Jax', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (25, N'25-Morgana', N'Morgana.png', N'Morgana', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (26, N'26-Zilean', N'Zilean.png', N'Zilean', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (27, N'27-Singed', N'Singed.png', N'Singed', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (28, N'28-Evelynn', N'Evelynn.png', N'Evelynn', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (29, N'29-Twitch', N'Twitch.png', N'Twitch', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (30, N'30-Karthus', N'Karthus.png', N'Karthus', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (31, N'31-Cho''Gath', N'Cho''Gath.png', N'Cho''Gath', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (32, N'32-Amumu', N'Amumu.png', N'Amumu', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (33, N'33-Rammus', N'Rammus.png', N'Rammus', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (34, N'34-Anivia', N'Anivia.png', N'Anivia', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (35, N'35-Shaco', N'Shaco.png', N'Shaco', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (36, N'36-Dr. Mundo', N'Dr. Mundo.png', N'Dr. Mundo', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (37, N'37-Sona', N'Sona.png', N'Sona', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (38, N'38-Kassadin', N'Kassadin.png', N'Kassadin', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (39, N'39-Irelia', N'Irelia.png', N'Irelia', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (40, N'40-Janna', N'Janna.png', N'Janna', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (41, N'41-Gangplank', N'Gangplank.png', N'Gangplank', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (42, N'42-Corki', N'Corki.png', N'Corki', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (43, N'43-Karma', N'Karma.png', N'Karma', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (44, N'44-Taric', N'Taric.png', N'Taric', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (45, N'45-Veigar', N'Veigar.png', N'Veigar', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (46, N'48-Trundle', N'Trundle.png', N'Trundle', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (47, N'50-Swain', N'Swain.png', N'Swain', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (48, N'51-Caitlyn', N'Caitlyn.png', N'Caitlyn', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (49, N'53-Blitzcrank', N'Blitzcrank.png', N'Blitzcrank', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (50, N'54-Malphite', N'Malphite.png', N'Malphite', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (51, N'55-Katarina', N'Katarina.png', N'Katarina', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (52, N'56-Nocturne', N'Nocturne.png', N'Nocturne', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (53, N'57-Maokai', N'Maokai.png', N'Maokai', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (54, N'58-Renekton', N'Renekton.png', N'Renekton', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (55, N'59-Jarvan IV', N'Jarvan IV.png', N'Jarvan IV', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (56, N'60-Elise', N'Elise.png', N'Elise', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (57, N'61-Orianna', N'Orianna.png', N'Orianna', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (58, N'62-Ngộ Không', N'Ngộ Không.png', N'Ngộ Không', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (59, N'63-Brand', N'Brand.png', N'Brand', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (60, N'64-Lee Sin', N'Lee Sin.png', N'Lee Sin', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (61, N'67-Vayne', N'Vayne.png', N'Vayne', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (62, N'68-Rumble', N'Rumble.png', N'Rumble', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (63, N'69-Cassiopeia', N'Cassiopeia.png', N'Cassiopeia', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (64, N'72-Skarner', N'Skarner.png', N'Skarner', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (65, N'74-Heimerdinger', N'Heimerdinger.png', N'Heimerdinger', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (66, N'75-Nasus', N'Nasus.png', N'Nasus', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (67, N'76-Nidalee', N'Nidalee.png', N'Nidalee', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (68, N'77-Udyr', N'Udyr.png', N'Udyr', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (69, N'78-Poppy', N'Poppy.png', N'Poppy', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (70, N'79-Gragas', N'Gragas.png', N'Gragas', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (71, N'80-Pantheon', N'Pantheon.png', N'Pantheon', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (72, N'81-Ezreal', N'Ezreal.png', N'Ezreal', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (73, N'82-Mordekaiser', N'Mordekaiser.png', N'Mordekaiser', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (74, N'83-Yorick', N'Yorick.png', N'Yorick', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (75, N'84-Akali', N'Akali.png', N'Akali', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (76, N'85-Kennen', N'Kennen.png', N'Kennen', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (77, N'86-Garen', N'Garen.png', N'Garen', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (78, N'89-Leona', N'Leona.png', N'Leona', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (79, N'90-Malzahar', N'Malzahar.png', N'Malzahar', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (80, N'91-Talon', N'Talon.png', N'Talon', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (81, N'92-Riven', N'Riven.png', N'Riven', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (82, N'96-Kog''Maw', N'Kog''Maw.png', N'Kog''Maw', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (83, N'98-Shen', N'Shen.png', N'Shen', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (84, N'99-Lux', N'Lux.png', N'Lux', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (85, N'101-Xerath', N'Xerath.png', N'Xerath', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (86, N'102-Shyvana', N'Shyvana.png', N'Shyvana', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (87, N'103-Ahri', N'Ahri.png', N'Ahri', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (88, N'104-Graves', N'Graves.png', N'Graves', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (89, N'105-Fizz', N'Fizz.png', N'Fizz', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (90, N'106-Volibear', N'Volibear.png', N'Volibear', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (91, N'107-Rengar', N'Rengar.png', N'Rengar', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (92, N'110-Varus', N'Varus.png', N'Varus', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (93, N'111-Nautilus', N'Nautilus.png', N'Nautilus', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (94, N'112-Viktor', N'Viktor.png', N'Viktor', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (95, N'113-Sejuani', N'Sejuani.png', N'Sejuani', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (96, N'114-Fiora', N'Fiora.png', N'Fiora', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (97, N'115-Ziggs', N'Ziggs.png', N'Ziggs', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (98, N'117-Lulu', N'Lulu.png', N'Lulu', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (99, N'119-Draven', N'Draven.png', N'Draven', NULL)
GO
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (100, N'120-Hecarim', N'Hecarim.png', N'Hecarim', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (101, N'121-Kha''Zix', N'Kha''Zix.png', N'Kha''Zix', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (102, N'122-Darius', N'Darius.png', N'Darius', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (103, N'126-Jayce', N'Jayce.png', N'Jayce', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (104, N'127-Lissandra', N'Lissandra.png', N'Lissandra', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (105, N'131-Diana', N'Diana.png', N'Diana', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (106, N'133-Quinn', N'Quinn.png', N'Quinn', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (107, N'134-Syndra', N'Syndra.png', N'Syndra', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (108, N'136-Aurelion Sol', N'Aurelion Sol.png', N'Aurelion Sol', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (109, N'141-Kayn', N'Kayn.png', N'Kayn', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (110, N'142-Zoe', N'Zoe.png', N'Zoe', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (111, N'143-Zyra', N'Zyra.png', N'Zyra', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (112, N'145-Kai''Sa', N'Kai''Sa.png', N'Kai''Sa', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (113, N'147-Seraphine', N'Seraphine.png', N'Seraphine', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (114, N'150-Gnar', N'Gnar.png', N'Gnar', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (115, N'154-Zac', N'Zac.png', N'Zac', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (116, N'157-Yasuo', N'Yasuo.png', N'Yasuo', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (117, N'161-Vel''Koz', N'Vel''Koz.png', N'Vel''Koz', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (118, N'163-Taliyah', N'Taliyah.png', N'Taliyah', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (119, N'164-Camille', N'Camille.png', N'Camille', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (120, N'166-Akshan', N'Akshan.png', N'Akshan', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (121, N'200-Bel''Veth', N'Bel''Veth.png', N'Bel''Veth', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (122, N'201-Braum', N'Braum.png', N'Braum', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (123, N'202-Jhin', N'Jhin.png', N'Jhin', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (124, N'203-Kindred', N'Kindred.png', N'Kindred', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (125, N'221-Zeri', N'Zeri.png', N'Zeri', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (126, N'222-Jinx', N'Jinx.png', N'Jinx', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (127, N'223-Tahm Kench', N'Tahm Kench.png', N'Tahm Kench', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (128, N'233-Briar', N'Briar.png', N'Briar', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (129, N'234-Viego', N'Viego.png', N'Viego', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (130, N'235-Senna', N'Senna.png', N'Senna', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (131, N'236-Lucian', N'Lucian.png', N'Lucian', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (132, N'238-Zed', N'Zed.png', N'Zed', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (133, N'240-Kled', N'Kled.png', N'Kled', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (134, N'245-Ekko', N'Ekko.png', N'Ekko', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (135, N'246-Qiyana', N'Qiyana.png', N'Qiyana', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (136, N'254-Vi', N'Vi.png', N'Vi', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (137, N'266-Aatrox', N'Aatrox.png', N'Aatrox', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (138, N'267-Nami', N'Nami.png', N'Nami', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (139, N'268-Azir', N'Azir.png', N'Azir', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (140, N'350-Yuumi', N'Yuumi.png', N'Yuumi', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (141, N'360-Samira', N'Samira.png', N'Samira', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (142, N'412-Thresh', N'Thresh.png', N'Thresh', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (143, N'420-Illaoi', N'Illaoi.png', N'Illaoi', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (144, N'421-Rek''Sai', N'Rek''Sai.png', N'Rek''Sai', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (145, N'427-Ivern', N'Ivern.png', N'Ivern', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (146, N'429-Kalista', N'Kalista.png', N'Kalista', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (147, N'432-Bard', N'Bard.png', N'Bard', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (148, N'497-Rakan', N'Rakan.png', N'Rakan', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (149, N'498-Xayah', N'Xayah.png', N'Xayah', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (150, N'516-Ornn', N'Ornn.png', N'Ornn', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (151, N'517-Sylas', N'Sylas.png', N'Sylas', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (152, N'518-Neeko', N'Neeko.png', N'Neeko', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (153, N'523-Aphelios', N'Aphelios.png', N'Aphelios', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (154, N'526-Rell', N'Rell.png', N'Rell', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (155, N'555-Pyke', N'Pyke.png', N'Pyke', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (156, N'711-Vex', N'Vex.png', N'Vex', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (157, N'777-Yone', N'Yone.png', N'Yone', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (158, N'875-Sett', N'Sett.png', N'Sett', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (159, N'876-Lillia', N'Lillia.png', N'Lillia', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (160, N'887-Gwen', N'Gwen.png', N'Gwen', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (161, N'888-Renata Glasc', N'Renata Glasc.png', N'Renata Glasc', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (162, N'895-Nilah', N'Nilah.png', N'Nilah', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (163, N'897-K''Sante', N'K''Sante.png', N'K''Sante', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (164, N'901-Smolder', N'Smolder.png', N'Smolder', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (165, N'902-Milio', N'Milio.png', N'Milio', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (166, N'910-Hwei', N'Hwei.png', N'Hwei', NULL)
INSERT [dbo].[Tuong] ([id_tuong], [ma_tuong], [imageURLtuong], [name_tuong], [id_acc]) VALUES (167, N'950-Naafiri', N'Naafiri.png', N'Naafiri', NULL)
SET IDENTITY_INSERT [dbo].[Tuong] OFF
GO
SET IDENTITY_INSERT [dbo].[thecao] ON 

INSERT [dbo].[thecao] ([idthecao], [type], [menhgia], [seri], [pin], [APIKey], [callback], [content], [NgayTao], [tenuser], [status]) VALUES (40, N'VINAPHONE', 10000, N'59000024934897', N'85672621367283', N'SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT', N'https://localhost:44311/Home/Index', N'NHANTHECAO_vtquine', CAST(N'2024-04-06T22:45:15.103' AS DateTime), N'toilauser', N'thanh cong')
INSERT [dbo].[thecao] ([idthecao], [type], [menhgia], [seri], [pin], [APIKey], [callback], [content], [NgayTao], [tenuser], [status]) VALUES (41, N'VINAPHONE', 10000, N'59000024803426', N'04295986090740', N'SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT', N'https://localhost:44311/Home/Index', N'NHANTHECAO_vtquine', CAST(N'2024-04-06T22:55:48.967' AS DateTime), N'toilauser', N'thanh cong')
INSERT [dbo].[thecao] ([idthecao], [type], [menhgia], [seri], [pin], [APIKey], [callback], [content], [NgayTao], [tenuser], [status]) VALUES (42, N'VIETTEL', 10000, N'21342134213', N'123423421', N'SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT', N'https://localhost:44311/Home/Index', N'NHANTHECAO_vtquine', CAST(N'2024-04-07T19:39:39.433' AS DateTime), N'toilauser', N'that bai')
INSERT [dbo].[thecao] ([idthecao], [type], [menhgia], [seri], [pin], [APIKey], [callback], [content], [NgayTao], [tenuser], [status]) VALUES (43, N'VIETTEL', 10000, N'3425345324', N'2345324532', N'SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT', N'https://localhost:44311/Home/Index', N'NHANTHECAO_vtquine', CAST(N'2024-04-07T19:49:44.493' AS DateTime), N'toilauser', N'that bai')
INSERT [dbo].[thecao] ([idthecao], [type], [menhgia], [seri], [pin], [APIKey], [callback], [content], [NgayTao], [tenuser], [status]) VALUES (44, N'VIETTEL', 10000, N'13242134', N'132412342134', N'SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT', N'https://localhost:44311/Home/Index', N'NHANTHECAO_vtquine', CAST(N'2024-04-07T19:53:33.913' AS DateTime), N'toilauser', N'that bai')
INSERT [dbo].[thecao] ([idthecao], [type], [menhgia], [seri], [pin], [APIKey], [callback], [content], [NgayTao], [tenuser], [status]) VALUES (45, N'VIETTEL', 10000, N'23412541435', N'13242134234', N'SHQItaDmVwAqPcEWnkgZzNUMhlYFiyJRvuorBbdLKjGOXxespCfT', N'https://localhost:44311/Home/Index', N'NHANTHECAO_vtquine', CAST(N'2024-04-10T23:03:50.023' AS DateTime), N'toilauser', N'that bai')
SET IDENTITY_INSERT [dbo].[thecao] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail], [status]) VALUES (22, N'testhoailuon', N'cNSqTsGBb1L7yFwgyQucLSp0Z1ndAfldlyrc0ssl2Js=', 1, CAST(4111 AS Decimal(10, 0)), N'testhoailuon@gmail.com', 0)
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail], [status]) VALUES (24, N'congtacvien', N'XbN01JHu25vQZ8HCscyPiPrFiMgRW9iY5NFbqayF5Qw=', 2, CAST(0 AS Decimal(10, 0)), N'congtacvien@gmail.com', 0)
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail], [status]) VALUES (26, N'toilauser', N'tpVbjd7cSrgqMx0bmKgHTT7t+r71Y7CVSOU6S7weVOY=', 0, CAST(40049 AS Decimal(10, 0)), N'toilauser@gmail.com', 0)
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail], [status]) VALUES (27, N'votanqui', N'kShMCiyU97eZCsP10aAOy96zglmh5VQqOH+nQxBAfTQ=', 3, CAST(0 AS Decimal(10, 0)), N'votanqui@gmail.com', 0)
INSERT [dbo].[Users] ([id_user], [username], [password], [roles], [price], [gmail], [status]) VALUES (28, N'vtquine', N'kShMCiyU97eZCsP10aAOy96zglmh5VQqOH+nQxBAfTQ=', 0, CAST(10000 AS Decimal(10, 0)), N'votanquiaa@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[thecao] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users1_roles]  DEFAULT ((0)) FOR [roles]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([idacc])
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
