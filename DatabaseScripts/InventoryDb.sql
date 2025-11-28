USE [InventoryDB]
GO
/****** Object:  Table [dbo].[AccountMaster]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountMaster](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[AccountCode] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMaster](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NOT NULL,
	[Mobile] [nvarchar](15) NULL,
	[Email] [nvarchar](200) NULL,
	[Address] [nvarchar](max) NULL,
	[AccountId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](200) NOT NULL,
	[Stock] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledger](
	[LedgerId] [int] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime2](7) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Reference] [nvarchar](200) NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentHeader]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentHeader](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](500) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseHeader]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseHeader](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[PurchaseDate] [datetime2](7) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseItem]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseItem](
	[PurchaseItemId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Amount]  AS ([Quantity]*[UnitPrice]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[PurchaseItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptHeader]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptHeader](
	[ReceiptId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ReceiptDate] [datetime2](7) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](500) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleHeader]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleHeader](
	[SaleId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[SaleDate] [datetime2](7) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaleItem]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleItem](
	[SaleItemId] [int] IDENTITY(1,1) NOT NULL,
	[SaleId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierMaster]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierMaster](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](200) NOT NULL,
	[AccountId] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerMaster] ADD  DEFAULT (sysdatetime()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ItemMaster] ADD  DEFAULT ((0)) FOR [Stock]
GO
ALTER TABLE [dbo].[ItemMaster] ADD  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[ItemMaster] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Ledger] ADD  DEFAULT (sysutcdatetime()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[Ledger] ADD  DEFAULT ((0)) FOR [Debit]
GO
ALTER TABLE [dbo].[Ledger] ADD  DEFAULT ((0)) FOR [Credit]
GO
ALTER TABLE [dbo].[PaymentHeader] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[PurchaseHeader] ADD  DEFAULT (sysutcdatetime()) FOR [PurchaseDate]
GO
ALTER TABLE [dbo].[ReceiptHeader] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[SupplierMaster] ADD  DEFAULT (sysutcdatetime()) FOR [CreatedAt]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateCustomer]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateCustomer]
    @CustomerName NVARCHAR(200),
    @Mobile NVARCHAR(15),
    @Email NVARCHAR(200),
    @Address NVARCHAR(MAX),
    @AccountId INT,
    @CustomerId INT OUTPUT
AS
BEGIN
    INSERT INTO CustomerMaster (CustomerName, Mobile, Email, Address, AccountId)
    VALUES (@CustomerName, @Mobile, @Email, @Address, @AccountId);

    SET @CustomerId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CreatePayment]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreatePayment]
    @SupplierId INT,
    @PaymentDate DATETIME2,
    @Amount DECIMAL(18,2),
    @Remarks NVARCHAR(500),
    @PaymentId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO PaymentHeader (SupplierId, PaymentDate, Amount, Remarks)
    VALUES (@SupplierId, @PaymentDate, @Amount, @Remarks);

    SET @PaymentId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CreatePurchaseHeader]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreatePurchaseHeader]
    @SupplierId INT,
    @PurchaseDate DATETIME2,
    @TotalAmount DECIMAL(18,2),
    @Remarks NVARCHAR(500),
    @PurchaseId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO PurchaseHeader (SupplierId, PurchaseDate, TotalAmount, Remarks)
    VALUES (@SupplierId, @PurchaseDate, @TotalAmount, @Remarks);

    SET @PurchaseId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CreatePurchaseItem]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreatePurchaseItem]
    @PurchaseId INT,
    @ItemId INT,
    @Quantity DECIMAL(18,2),
    @UnitPrice DECIMAL(18,2),
    @PurchaseItemId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO PurchaseItem (PurchaseId, ItemId, Quantity, UnitPrice)
    VALUES (@PurchaseId, @ItemId, @Quantity, @UnitPrice);

    SET @PurchaseItemId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateReceipt]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateReceipt]
    @CustomerId INT,
    @ReceiptDate DATETIME2,
    @Amount DECIMAL(18,2),
    @Remarks NVARCHAR(500),
    @ReceiptId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ReceiptHeader (CustomerId, ReceiptDate, Amount, Remarks)
    VALUES (@CustomerId, @ReceiptDate, @Amount, @Remarks);

    SET @ReceiptId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateSaleHeader]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateSaleHeader]
    @CustomerId INT,
    @SaleDate DATETIME2,
    @TotalAmount DECIMAL(18,2),
    @Remarks NVARCHAR(500),
    @SaleId INT OUTPUT
AS
BEGIN
    INSERT INTO SaleHeader (CustomerId, SaleDate, TotalAmount, Remarks)
    VALUES (@CustomerId, @SaleDate, @TotalAmount, @Remarks);

    SET @SaleId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateSaleItem]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateSaleItem]
    @SaleId INT,
    @ItemId INT,
    @Quantity DECIMAL(18,2),
    @UnitPrice DECIMAL(18,2),
    @SaleItemId INT OUTPUT
AS
BEGIN
    INSERT INTO SaleItem (SaleId, ItemId, Quantity, UnitPrice)
    VALUES (@SaleId, @ItemId, @Quantity, @UnitPrice);

    SET @SaleItemId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAccountLedger]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAccountLedger]
    @AccountId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        LedgerId,
        EntryDate,
        Reference,
        Debit,
        Credit,
        SUM(Debit - Credit) 
            OVER (ORDER BY EntryDate, LedgerId 
                  ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningBalance
    FROM Ledger
    WHERE AccountId = @AccountId
    ORDER BY EntryDate, LedgerId;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetItemById]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetItemById]
    @ItemId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ItemId, ItemName, Stock, UnitPrice
    FROM ItemMaster
    WHERE ItemId = @ItemId;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertLedgerEntry]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertLedgerEntry]
    @EntryDate DATETIME2,
    @AccountId INT,
    @Reference NVARCHAR(200),
    @Debit DECIMAL(18,2),
    @Credit DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Ledger (EntryDate, AccountId, Reference, Debit, Credit)
    VALUES (@EntryDate, @AccountId, @Reference, @Debit, @Credit);
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateItemStock]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateItemStock]
    @ItemId INT,
    @DeltaQty DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ItemMaster
    SET Stock = Stock + @DeltaQty
    WHERE ItemId = @ItemId;

   -- SELECT ItemId, Stock FROM ItemMaster WHERE ItemId = @ItemId;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateItemStockSale]    Script Date: 27-11-2025 22:50:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateItemStockSale]
    @ItemId INT,
    @DeltaQty DECIMAL(18,2)
AS
BEGIN
    UPDATE ItemMaster
    SET Stock = Stock - @DeltaQty
    WHERE ItemId = @ItemId;

    SELECT ItemId, Stock FROM ItemMaster WHERE ItemId = @ItemId;
END
GO
