USE [MobileStore]
GO
SET IDENTITY_INSERT [dbo].[Manufacturers] ON 

INSERT [dbo].[Manufacturers] ([ID], [Name]) VALUES (1, N'Samsung')
INSERT [dbo].[Manufacturers] ([ID], [Name]) VALUES (2, N'Sony')
INSERT [dbo].[Manufacturers] ([ID], [Name]) VALUES (3, N'Apple')
INSERT [dbo].[Manufacturers] ([ID], [Name]) VALUES (1002, N'Nokia')
SET IDENTITY_INSERT [dbo].[Manufacturers] OFF
SET IDENTITY_INSERT [dbo].[MobilePhones] ON 

INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (1, 1, N'20', N'20', N'20x20', N'2gzh', N'500gb', N'2gb', N'android', 200.0000, N'Samsung s8')
INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (2, 2, N'22', N'22', N'22x22', N'1gzh', N'200gb', N'1gb', N'ios', 150.0000, N'Sony')
INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (4, 3, N'33', N'33', N'33x33', N'3gzh', N'1tb', N'6gb', N'android', 560.0000, N'IPhone')
INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (1002, 1002, N'20', N'20', N'15x15', N'0.5gzh', N'100mb', N'500mb', N'android', 50.0000, N'Nokia')
INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (1003, 1, N'33', N'22', N'30x30', N'3 gzh', N'2gb', N'2mb', N'ios', 30.0000, N'Samsung s10')
INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (1004, 1, N'22', N'11', N'11x11', N'3gzh', N'2gb', N'5gb', N'android', 1500.0000, N'Samsung s9')
INSERT [dbo].[MobilePhones] ([ID], [ManufacturerID], [Size], [Weight], [DisplayResolution], [Processor], [Memory], [Ram], [OS], [Price], [Name]) VALUES (1005, 3, N'10', N'10', N'10x10', N'2gzh', N'2gb', N'2gb', N'ios', 1000.0000, N'Iphone 8')
SET IDENTITY_INSERT [dbo].[MobilePhones] OFF
SET IDENTITY_INSERT [dbo].[Visuals] ON 

INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (9, N'Visuals/nokiaThumbnail.jpg', 1002)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1004, N'Visuals/41VE1x1z5vLThumbnail.jpg', 1)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1005, N'Visuals/iphoneThumbnail.jpg', 4)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1007, N'Visuals/samsung_s8_1.jpg', 1)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1008, N'Visuals/iphoneThumbnail.jpg', 1005)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1009, N'Visuals/samsung_s8_1.jpg', 1003)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1010, N'Visuals/samsung_s8_1.jpg', 1004)
INSERT [dbo].[Visuals] ([ID], [Path], [MobilePhoneID]) VALUES (1011, N'Visuals/samsung_s8_1.jpg', 2)
SET IDENTITY_INSERT [dbo].[Visuals] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190904204549_Initial', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190906174839_Specified column name for prprty NAM', N'2.2.6-servicing-10079')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190909163837_migration2', N'2.2.6-servicing-10079')
