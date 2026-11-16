IF DB_ID(N'ShoesStoreDb') IS NULL CREATE DATABASE ShoesStoreDb;
GO
USE ShoesStoreDb;
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;

CREATE TABLE [roles] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [name] NVARCHAR(20) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_roles_name] UNIQUE ([name]));

CREATE TABLE [users] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [full_name] NVARCHAR(255) NOT NULL,
  [login] NVARCHAR(255) NOT NULL,
  [password] NVARCHAR(255) NOT NULL,
  [role_id] BIGINT NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_users_login] UNIQUE ([login]),
  CONSTRAINT [fk_users_roles1]
    FOREIGN KEY ([role_id])
    REFERENCES [roles] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE [units] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [name] NVARCHAR(10) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_units_name] UNIQUE ([name]));

CREATE TABLE [suppliers] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [name] NVARCHAR(50) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_suppliers_name] UNIQUE ([name]));

CREATE TABLE [manufacturers] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [name] NVARCHAR(50) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_manufacturers_name] UNIQUE ([name]));

CREATE TABLE [categories] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [name] NVARCHAR(50) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_categories_name] UNIQUE ([name]));

CREATE TABLE [products] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [article] NVARCHAR(6) NOT NULL,
  [name] NVARCHAR(50) NOT NULL,
  [description] NVARCHAR(255) NOT NULL,
  [quantity] INT NOT NULL DEFAULT 0 CHECK ([quantity] >= 0),
  [discount_percent] SMALLINT NOT NULL DEFAULT 0 CHECK ([discount_percent] BETWEEN 0 AND 100),
  [price] DECIMAL(18,2) NOT NULL CHECK ([price] >= 0),
  [photo_file_name] NVARCHAR(255) NULL,
  [category_id] BIGINT NOT NULL,
  [manufacturer_id] BIGINT NOT NULL,
  [unit_id] BIGINT NOT NULL,
  [supplier_id] BIGINT NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_products_article] UNIQUE ([article]),
  CONSTRAINT [fk_products_categories]
    FOREIGN KEY ([category_id])
    REFERENCES [categories] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_products_manufacturers1]
    FOREIGN KEY ([manufacturer_id])
    REFERENCES [manufacturers] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_products_units1]
    FOREIGN KEY ([unit_id])
    REFERENCES [units] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_products_suppliers1]
    FOREIGN KEY ([supplier_id])
    REFERENCES [suppliers] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE [statuses] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [name] NVARCHAR(25) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_statuses_name] UNIQUE ([name]));

CREATE TABLE [orders] (
  [id] BIGINT IDENTITY(1,1) NOT NULL,
  [creation_date] DATETIME2(0) NOT NULL DEFAULT CURRENT_TIMESTAMP,
  [delivery_date] DATETIME2(0) NOT NULL,
  [code] SMALLINT NOT NULL,
  [user_id] BIGINT NOT NULL,
  [status_id] BIGINT NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [UQ_orders_code] UNIQUE ([code]),
  CONSTRAINT [fk_orders_users1]
    FOREIGN KEY ([user_id])
    REFERENCES [users] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_orders_statuses1]
    FOREIGN KEY ([status_id])
    REFERENCES [statuses] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE [order_item] (
  [product_id] BIGINT NOT NULL,
  [order_id] BIGINT NOT NULL,
  [quantity] INT NOT NULL CHECK ([quantity] > 0),
  PRIMARY KEY ([product_id], [order_id]),
  CONSTRAINT [fk_order_item_products1]
    FOREIGN KEY ([product_id])
    REFERENCES [products] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_order_item_orders1]
    FOREIGN KEY ([order_id])
    REFERENCES [orders] ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

SET IDENTITY_INSERT dbo.[roles] ON;

INSERT INTO dbo.[roles] ([id], [name]) VALUES

    (1, N'Администратор'),
    (2, N'Менеджер'),
    (3, N'Клиент');

SET IDENTITY_INSERT dbo.[roles] OFF;

SET IDENTITY_INSERT dbo.[users] ON;

INSERT INTO dbo.[users] ([id], [full_name], [login], [password], [role_id]) VALUES

    (1, N'Никифорова Весения Николаевна', N'94d5ous@gmail.com', N'uzWC67', 1),
    (2, N'Сазонов Руслан Германович', N'uth4iz@mail.com', N'2L6KZG', 1),
    (3, N'Одинцов Серафим Артёмович', N'yzls62@outlook.com', N'JlFRCZ', 1),
    (4, N'Степанов Михаил Артёмович', N'1diph5e@tutanota.com', N'8ntwUp', 2),
    (5, N'Ворсин Петр Евгеньевич', N'tjde7c@yahoo.com', N'YOyhfR', 2),
    (6, N'Старикова Елена Павловна', N'wpmrc3do@tutanota.com', N'RSbvHv', 2),
    (7, N'Михайлюк Анна Вячеславовна', N'5d4zbu@tutanota.com', N'rwVDh9', 3),
    (8, N'Ситдикова Елена Анатольевна', N'ptec8ym@yahoo.com', N'LdNyos', 3),
    (9, N'Ворсин Петр Евгеньевич', N'1qz4kw@mail.com', N'gynQMT', 3),
    (10, N'Старикова Елена Павловна', N'4np6se@mail.com', N'AtnDjr', 3);

SET IDENTITY_INSERT dbo.[users] OFF;

SET IDENTITY_INSERT dbo.[units] ON;

INSERT INTO dbo.[units] ([id], [name]) VALUES

    (1, N'шт.');

SET IDENTITY_INSERT dbo.[units] OFF;

SET IDENTITY_INSERT dbo.[suppliers] ON;

INSERT INTO dbo.[suppliers] ([id], [name]) VALUES

    (1, N'Kari'),
    (2, N'Обувь для вас');

SET IDENTITY_INSERT dbo.[suppliers] OFF;

SET IDENTITY_INSERT dbo.[manufacturers] ON;

INSERT INTO dbo.[manufacturers] ([id], [name]) VALUES

    (1, N'Kari'),
    (2, N'Marco Tozzi'),
    (3, N'Рос'),
    (4, N'Rieker'),
    (5, N'Alessio Nesca'),
    (6, N'CROSBY');

SET IDENTITY_INSERT dbo.[manufacturers] OFF;

SET IDENTITY_INSERT dbo.[categories] ON;

INSERT INTO dbo.[categories] ([id], [name]) VALUES

    (1, N'Женская обувь'),
    (2, N'Мужская обувь');

SET IDENTITY_INSERT dbo.[categories] OFF;

SET IDENTITY_INSERT dbo.[products] ON;

INSERT INTO dbo.[products] ([id], [article], [name], [description], [quantity], [discount_percent], [price], [photo_file_name], [category_id], [manufacturer_id], [unit_id], [supplier_id]) VALUES

    (1, N'А112Т4', N'Ботинки', N'Женские Ботинки демисезонные kari', 6, 3, 4990.00, N'1.jpg', 1, 1, 1, 1),
    (2, N'F635R4', N'Ботинки', N'Ботинки Marco Tozzi женские демисезонные, размер 39, цвет бежевый', 13, 2, 3244.00, N'2.jpg', 1, 2, 1, 2),
    (3, N'H782T5', N'Туфли', N'Туфли kari мужские классика MYZ21AW-450A, размер 43, цвет: черный', 5, 5, 4499.00, N'3.jpg', 2, 1, 1, 1),
    (4, N'G783F5', N'Ботинки', N'Мужские ботинки Рос-Обувь кожаные с натуральным мехом', 8, 2, 5900.00, N'4.jpg', 2, 3, 1, 1),
    (5, N'J384T6', N'Ботинки', N'B3430/14 Полуботинки мужские Rieker', 16, 0, 3800.00, N'5.jpg', 2, 4, 1, 2),
    (6, N'D572U8', N'Кроссовки', N'129615-4 Кроссовки мужские', 0, 3, 4100.00, N'6.jpg', 2, 3, 1, 2),
    (7, N'F572H7', N'Туфли', N'Туфли Marco Tozzi женские летние, размер 39, цвет черный', 14, 2, 2700.00, N'7.jpg', 1, 2, 1, 1),
    (8, N'D329H3', N'Полуботинки', N'Полуботинки Alessio Nesca женские 3-30797-47, размер 37, цвет: бордовый', 4, 0, 1890.00, N'8.jpg', 1, 5, 1, 2),
    (9, N'B320R5', N'Туфли', N'Туфли Rieker женские демисезонные, размер 41, цвет коричневый', 6, 2, 4300.00, N'9.jpg', 1, 4, 1, 1),
    (10, N'G432E4', N'Туфли', N'Туфли kari женские TR-YR-413017, размер 37, цвет: черный', 15, 0, 2800.00, N'10.jpg', 1, 1, 1, 1),
    (11, N'S213E3', N'Полуботинки', N'407700/01-01 Полуботинки мужские CROSBY', 6, 0, 2156.00, NULL, 2, 6, 1, 2),
    (12, N'E482R4', N'Полуботинки', N'Полуботинки kari женские MYZ20S-149, размер 41, цвет: черный', 14, 2, 1800.00, NULL, 1, 1, 1, 1),
    (13, N'S634B5', N'Кеды', N'Кеды Caprice мужские демисезонные, размер 42, цвет черный', 0, 3, 5500.00, NULL, 2, 6, 1, 2),
    (14, N'K345R4', N'Полуботинки', N'407700/01-02 Полуботинки мужские CROSBY', 3, 2, 2100.00, NULL, 2, 6, 1, 2),
    (15, N'O754F4', N'Туфли', N'Туфли женские демисезонные Rieker артикул 55073-68/37', 18, 4, 5400.00, NULL, 1, 4, 1, 2),
    (16, N'G531F4', N'Ботинки', N'Ботинки женские зимние ROMER арт. 893167-01 Черный', 9, 0, 6600.00, NULL, 1, 1, 1, 1),
    (17, N'J542F5', N'Тапочки', N'Тапочки мужские Арт.70701-55-67', 0, 0, 500.00, NULL, 2, 1, 1, 1),
    (18, N'B431R5', N'Ботинки', N'Мужские кожаные ботинки/мужские ботинки', 5, 2, 2700.00, NULL, 2, 4, 1, 2),
    (19, N'P764G4', N'Туфли', N'Туфли женские, ARGO', 15, 10, 6800.00, NULL, 1, 6, 1, 1),
    (20, N'C436G5', N'Ботинки', N'Ботинки женские, ARGO, размер 40', 0, 0, 10200.00, NULL, 1, 5, 1, 1),
    (21, N'F427R5', N'Ботинки', N'Ботинки на молнии с декоративной пряжкой FRAU', 0, 15, 11800.00, NULL, 1, 4, 1, 2),
    (22, N'N457T5', N'Полуботинки', N'Полуботинки Ботинки черные зимние, мех', 13, 3, 4600.00, NULL, 1, 6, 1, 1),
    (23, N'D364R4', N'Туфли', N'Туфли Luiza Belly женские Kate-lazo черные из натуральной замши', 5, 0, 12400.00, NULL, 1, 1, 1, 1),
    (24, N'S326R5', N'Тапочки', N'Мужские кожаные тапочки "Профиль С.Дали"', 15, 3, 9900.00, NULL, 2, 6, 1, 2),
    (25, N'L754R4', N'Полуботинки', N'Полуботинки kari женские WB2020SS-26, размер 38, цвет: черный', 7, 2, 1700.00, NULL, 1, 1, 1, 1),
    (26, N'M542T5', N'Кроссовки', N'Кроссовки мужские TOFA', 3, 20, 2800.00, NULL, 2, 4, 1, 2),
    (27, N'D268G5', N'Туфли', N'Туфли Rieker женские демисезонные, размер 36, цвет коричневый', 12, 0, 4399.00, NULL, 1, 4, 1, 2),
    (28, N'T324F5', N'Сапоги', N'Сапоги замша Цвет: синий', 5, 2, 4699.00, NULL, 1, 6, 1, 1),
    (29, N'K358H6', N'Тапочки', N'Тапочки мужские син р.41', 2, 20, 599.00, NULL, 2, 4, 1, 1),
    (30, N'H535R5', N'Ботинки', N'Женские Ботинки демисезонные', 7, 0, 2300.00, NULL, 1, 4, 1, 2);

SET IDENTITY_INSERT dbo.[products] OFF;

SET IDENTITY_INSERT dbo.[statuses] ON;

INSERT INTO dbo.[statuses] ([id], [name]) VALUES

    (1, N'Новый'),
    (2, N'Завершен');

SET IDENTITY_INSERT dbo.[statuses] OFF;

SET IDENTITY_INSERT dbo.[orders] ON;

INSERT INTO dbo.[orders] ([id], [creation_date], [delivery_date], [code], [user_id], [status_id]) VALUES

    (1, N'2025-02-27 00:00:00', N'2025-04-20 00:00:00', 901, 4, 2),
    (2, N'2022-09-28 00:00:00', N'2025-04-21 00:00:00', 902, 1, 2),
    (3, N'2025-03-21 00:00:00', N'2025-04-22 00:00:00', 903, 2, 2),
    (4, N'2025-02-20 00:00:00', N'2025-04-23 00:00:00', 904, 3, 2),
    (5, N'2025-03-17 00:00:00', N'2025-04-24 00:00:00', 905, 4, 2),
    (6, N'2025-03-01 00:00:00', N'2025-04-25 00:00:00', 906, 1, 2),
    (7, N'2025-02-28 00:00:00', N'2025-04-26 00:00:00', 907, 2, 2),
    (8, N'2025-03-31 00:00:00', N'2025-04-27 00:00:00', 908, 3, 1),
    (9, N'2025-04-02 00:00:00', N'2025-04-28 00:00:00', 909, 4, 1),
    (10, N'2025-04-03 00:00:00', N'2025-04-29 00:00:00', 910, 4, 1);

SET IDENTITY_INSERT dbo.[orders] OFF;

INSERT INTO dbo.[order_item] ([product_id], [order_id], [quantity]) VALUES

    (1, 1, 2),
    (2, 1, 2),
    (3, 2, 1),
    (5, 3, 10),
    (7, 4, 5),
    (8, 4, 4),
    (4, 4, 1),
    (1, 5, 2),
    (2, 5, 2),
    (3, 6, 1),
    (4, 6, 1),
    (5, 7, 3),
    (6, 7, 10),
    (7, 8, 5),
    (8, 8, 4),
    (9, 9, 5),
    (10, 9, 1),
    (6, 9, 1),
    (11, 10, 5);

COMMIT;
