USE [Dostavka]
GO
/****** Object:  Table [dbo].[Analytics]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Analytics](
	[ID_analytic] [int] IDENTITY(1,1) NOT NULL,
	[Metric_type] [nvarchar](50) NULL,
	[Value] [decimal](10, 2) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_Analytics] PRIMARY KEY CLUSTERED 
(
	[ID_analytic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery_Routes]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Routes](
	[ID_Route] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NULL,
	[ID_Driver] [int] NULL,
	[Route_data] [nvarchar](max) NULL,
 CONSTRAINT [PK_Delivery_Routes] PRIMARY KEY CLUSTERED 
(
	[ID_Route] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver_Status]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver_Status](
	[ID_status] [int] IDENTITY(1,1) NOT NULL,
	[ID_Driver] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Last_update] [datetime] NULL,
 CONSTRAINT [PK_Driver_Status] PRIMARY KEY CLUSTERED 
(
	[ID_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[ID_Notification] [int] IDENTITY(1,1) NOT NULL,
	[ID_User] [int] NULL,
	[ID_Order] [int] NULL,
	[Message] [nvarchar](500) NULL,
	[Time_of_sending] [datetime] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[ID_Notification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Items]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Items](
	[ID_item] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NULL,
	[ID_Product] [int] NULL,
	[Quantity_product] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Order_Items] PRIMARY KEY CLUSTERED 
(
	[ID_item] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID_Order] [int] IDENTITY(1,1) NOT NULL,
	[ID_Customer] [int] NULL,
	[ID_Driver] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Total_price] [int] NULL,
	[Payment_method] [nvarchar](50) NULL,
	[Delivery_address] [nvarchar](50) NULL,
	[Delivery_time] [datetime] NULL,
	[Created_order] [datetime] NULL,
	[Updated_order] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_Transactions]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_Transactions](
	[ID_Transaction] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NULL,
	[Amount] [int] NULL,
	[Payment_method] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_Payment_Transactions] PRIMARY KEY CLUSTERED 
(
	[ID_Transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID_Product] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
	[Category] [nvarchar](50) NULL,
	[Price] [int] NULL,
	[Image] [image] NULL,
	[Quantity_Sklad] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[ID_Review] [int] IDENTITY(1,1) NOT NULL,
	[ID_Customer] [int] NULL,
	[ID_Product] [int] NULL,
	[ID_Order] [int] NULL,
	[Rating] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[Created_Review] [datetime] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ID_Review] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Preferences]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Preferences](
	[ID_Preference] [int] IDENTITY(1,1) NOT NULL,
	[ID_Customer] [int] NULL,
	[ID_preference_Product] [int] NULL,
 CONSTRAINT [PK_User_Preferences] PRIMARY KEY CLUSTERED 
(
	[ID_Preference] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.12.2024 22:08:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [int] NULL,
	[Hire_date] [date] NULL,
	[Adress_customer] [nvarchar](50) NULL,
	[Password_hash] [nvarchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order_Items] ON 

INSERT [dbo].[Order_Items] ([ID_item], [ID_Order], [ID_Product], [Quantity_product], [Price]) VALUES (1, 3, 1, 1, 100)
INSERT [dbo].[Order_Items] ([ID_item], [ID_Order], [ID_Product], [Quantity_product], [Price]) VALUES (2, 3, 1, 1, 100)
INSERT [dbo].[Order_Items] ([ID_item], [ID_Order], [ID_Product], [Quantity_product], [Price]) VALUES (3, 4, 2, 1, 200)
INSERT [dbo].[Order_Items] ([ID_item], [ID_Order], [ID_Product], [Quantity_product], [Price]) VALUES (4, 5, 1, 1, 100)
SET IDENTITY_INSERT [dbo].[Order_Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID_Order], [ID_Customer], [ID_Driver], [Status], [Total_price], [Payment_method], [Delivery_address], [Delivery_time], [Created_order], [Updated_order]) VALUES (0, NULL, 3, N'Доставлен', 100, N'Банковская карта', NULL, CAST(N'2024-12-07T03:39:54.877' AS DateTime), CAST(N'2024-12-07T02:39:54.877' AS DateTime), NULL)
INSERT [dbo].[Orders] ([ID_Order], [ID_Customer], [ID_Driver], [Status], [Total_price], [Payment_method], [Delivery_address], [Delivery_time], [Created_order], [Updated_order]) VALUES (1, NULL, 3, N'Обработка', 100, N'Банковская карта', NULL, CAST(N'2024-12-07T14:50:34.273' AS DateTime), CAST(N'2024-12-07T11:22:32.803' AS DateTime), NULL)
INSERT [dbo].[Orders] ([ID_Order], [ID_Customer], [ID_Driver], [Status], [Total_price], [Payment_method], [Delivery_address], [Delivery_time], [Created_order], [Updated_order]) VALUES (2, NULL, 3, N'Доставлен', 300, N'Банковская карта', N'Бари Галеева 3', CAST(N'2024-12-07T15:01:30.997' AS DateTime), CAST(N'2024-12-07T11:58:53.113' AS DateTime), NULL)
INSERT [dbo].[Orders] ([ID_Order], [ID_Customer], [ID_Driver], [Status], [Total_price], [Payment_method], [Delivery_address], [Delivery_time], [Created_order], [Updated_order]) VALUES (3, NULL, 3, N'Обработка', 200, N'Банковская карта', N'Бари Галеева 3', CAST(N'2024-12-07T14:15:22.733' AS DateTime), CAST(N'2024-12-07T13:15:22.733' AS DateTime), NULL)
INSERT [dbo].[Orders] ([ID_Order], [ID_Customer], [ID_Driver], [Status], [Total_price], [Payment_method], [Delivery_address], [Delivery_time], [Created_order], [Updated_order]) VALUES (4, NULL, 3, N'Доставлен', 200, N'Банковская карта', N'Бари Галеева 3', CAST(N'2024-12-07T16:41:25.880' AS DateTime), CAST(N'2024-12-07T14:27:45.070' AS DateTime), NULL)
INSERT [dbo].[Orders] ([ID_Order], [ID_Customer], [ID_Driver], [Status], [Total_price], [Payment_method], [Delivery_address], [Delivery_time], [Created_order], [Updated_order]) VALUES (5, NULL, 3, N'Обработка', 100, N'Банковская карта', N'Бари Галеева 3', CAST(N'2024-12-07T15:40:04.457' AS DateTime), CAST(N'2024-12-07T14:40:04.457' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID_Product], [Name], [Description], [Category], [Price], [Image], [Quantity_Sklad]) VALUES (1, N'Банан', N'вкусни', N'Фрукты', 100, NULL, NULL)
INSERT [dbo].[Products] ([ID_Product], [Name], [Description], [Category], [Price], [Image], [Quantity_Sklad]) VALUES (2, N'Колбаса', N'соссиски', N'Овощи', 200, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([ID_Review], [ID_Customer], [ID_Product], [ID_Order], [Rating], [Comment], [Created_Review]) VALUES (3, NULL, NULL, 1, 4, N'qwerqwer', CAST(N'2024-12-07T11:54:41.573' AS DateTime))
INSERT [dbo].[Reviews] ([ID_Review], [ID_Customer], [ID_Product], [ID_Order], [Rating], [Comment], [Created_Review]) VALUES (4, NULL, NULL, 1, 5, N'qwe', CAST(N'2024-12-07T14:40:26.350' AS DateTime))
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID_User], [Role], [Name], [Email], [Phone], [Hire_date], [Adress_customer], [Password_hash]) VALUES (1, N'Client', N'fen4yara', N'@fen4yara', NULL, CAST(N'2024-12-07' AS Date), NULL, N'489cd5dbc708c7e541de4d7cd91ce6d0f1613573b7fc5b40d3942ccb9555cf35')
INSERT [dbo].[Users] ([ID_User], [Role], [Name], [Email], [Phone], [Hire_date], [Adress_customer], [Password_hash]) VALUES (2, N'Client', N'qe', N'fen4yara', 572341363, CAST(N'2024-12-07' AS Date), NULL, N'489cd5dbc708c7e541de4d7cd91ce6d0f1613573b7fc5b40d3942ccb9555cf35')
INSERT [dbo].[Users] ([ID_User], [Role], [Name], [Email], [Phone], [Hire_date], [Adress_customer], [Password_hash]) VALUES (3, N'Courier', N'кура', N's_ultanchik', 716901028, CAST(N'2024-12-07' AS Date), NULL, N'489cd5dbc708c7e541de4d7cd91ce6d0f1613573b7fc5b40d3942ccb9555cf35')
INSERT [dbo].[Users] ([ID_User], [Role], [Name], [Email], [Phone], [Hire_date], [Adress_customer], [Password_hash]) VALUES (4, N'Courier', N'Имя', N'Телеграм', NULL, CAST(N'2024-12-07' AS Date), NULL, N'cb1a2074b3a027ffa7d7d9c54682c3835fffc7f6d620d8a38532f075cc2f17a0')
INSERT [dbo].[Users] ([ID_User], [Role], [Name], [Email], [Phone], [Hire_date], [Adress_customer], [Password_hash]) VALUES (5, N'Courier', N'курьер', N's_ultanchik', NULL, CAST(N'2024-12-07' AS Date), NULL, N'489cd5dbc708c7e541de4d7cd91ce6d0f1613573b7fc5b40d3942ccb9555cf35')
INSERT [dbo].[Users] ([ID_User], [Role], [Name], [Email], [Phone], [Hire_date], [Adress_customer], [Password_hash]) VALUES (6, N'Client', N'рияз', N'RIYAZ_YA', 774820424, CAST(N'2024-12-07' AS Date), NULL, N'41e5c285822f1c0702dcea6969221914c8a6887bec55f36ebe84a63b33827027')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Delivery_Routes]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Routes_Orders] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[Delivery_Routes] CHECK CONSTRAINT [FK_Delivery_Routes_Orders]
GO
ALTER TABLE [dbo].[Delivery_Routes]  WITH CHECK ADD  CONSTRAINT [FK_Delivery_Routes_Users] FOREIGN KEY([ID_Driver])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Delivery_Routes] CHECK CONSTRAINT [FK_Delivery_Routes_Users]
GO
ALTER TABLE [dbo].[Driver_Status]  WITH CHECK ADD  CONSTRAINT [FK_Driver_Status_Users] FOREIGN KEY([ID_Driver])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Driver_Status] CHECK CONSTRAINT [FK_Driver_Status_Users]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Orders] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Orders]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Users] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Users]
GO
ALTER TABLE [dbo].[Order_Items]  WITH CHECK ADD  CONSTRAINT [FK_Order_Items_Orders] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[Order_Items] CHECK CONSTRAINT [FK_Order_Items_Orders]
GO
ALTER TABLE [dbo].[Order_Items]  WITH CHECK ADD  CONSTRAINT [FK_Order_Items_Products] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Products] ([ID_Product])
GO
ALTER TABLE [dbo].[Order_Items] CHECK CONSTRAINT [FK_Order_Items_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users1] FOREIGN KEY([ID_Driver])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users1]
GO
ALTER TABLE [dbo].[Payment_Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Transactions_Orders] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[Payment_Transactions] CHECK CONSTRAINT [FK_Payment_Transactions_Orders]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Orders] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Orders]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Products] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Products] ([ID_Product])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Products]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
ALTER TABLE [dbo].[User_Preferences]  WITH CHECK ADD  CONSTRAINT [FK_User_Preferences_Products] FOREIGN KEY([ID_preference_Product])
REFERENCES [dbo].[Products] ([ID_Product])
GO
ALTER TABLE [dbo].[User_Preferences] CHECK CONSTRAINT [FK_User_Preferences_Products]
GO
ALTER TABLE [dbo].[User_Preferences]  WITH CHECK ADD  CONSTRAINT [FK_User_Preferences_Users] FOREIGN KEY([ID_Customer])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[User_Preferences] CHECK CONSTRAINT [FK_User_Preferences_Users]
GO
ALTER TABLE [dbo].[Analytics]  WITH CHECK ADD  CONSTRAINT [CK_Analytics] CHECK  (([Metric_type]='Delivery_efficientcy' OR [Metric_type]='Product_popularity' OR [Metric_type]='Orders' OR [Metric_type]='Sales'))
GO
ALTER TABLE [dbo].[Analytics] CHECK CONSTRAINT [CK_Analytics]
GO
ALTER TABLE [dbo].[Driver_Status]  WITH CHECK ADD  CONSTRAINT [CK_Driver_Status] CHECK  (([Status]='Offline' OR [Status]='Busy' OR [Status]='Avaliable'))
GO
ALTER TABLE [dbo].[Driver_Status] CHECK CONSTRAINT [CK_Driver_Status]
GO
ALTER TABLE [dbo].[Payment_Transactions]  WITH CHECK ADD  CONSTRAINT [CK_Payment_Transactions] CHECK  (([Payment_method]='E-wallet' OR [Payment_method]='Card' OR [Payment_method]='Cash'))
GO
ALTER TABLE [dbo].[Payment_Transactions] CHECK CONSTRAINT [CK_Payment_Transactions]
GO
ALTER TABLE [dbo].[Payment_Transactions]  WITH CHECK ADD  CONSTRAINT [CK_Payment_Transactions_1] CHECK  (([Status]='Failed' OR [Status]='Completed' OR [Status]='Pending'))
GO
ALTER TABLE [dbo].[Payment_Transactions] CHECK CONSTRAINT [CK_Payment_Transactions_1]
GO
