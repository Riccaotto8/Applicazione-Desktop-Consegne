/****** Object:  Table [dbo].[Carrello]    Script Date: 24/06/2022 18:19:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrello](
	[IDMenu] [int] NOT NULL,
	[QuantitaOrdinata] [int] NOT NULL,
 CONSTRAINT [PK_Carrello] PRIMARY KEY CLUSTERED 
(
	[IDMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 24/06/2022 18:19:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IDMenu] [int] IDENTITY(1,1) NOT NULL,
	[NomeProdotto] [nvarchar](50) NOT NULL,
	[PrezzoProdotto] [decimal](4, 2) NOT NULL,
	[ImmagineProdotto] [image] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[IDMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordine]    Script Date: 24/06/2022 18:19:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordine](
	[IDOrdine] [int] IDENTITY(1,1) NOT NULL,
	[Destinazione] [nvarchar](50) NOT NULL,
	[ImportoTotale] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Ordine] PRIMARY KEY CLUSTERED 
(
	[IDOrdine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdottosuOrdine]    Script Date: 24/06/2022 18:19:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdottosuOrdine](
	[IDOrdine] [int] NOT NULL,
	[IDMenu] [int] NOT NULL,
	[QuantitaOrdinata] [int] NOT NULL,
 CONSTRAINT [PK_ProdottosuOrdine_1] PRIMARY KEY CLUSTERED 
(
	[IDOrdine] ASC,
	[IDMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrello] ADD  CONSTRAINT [DF_Carrello_QuantitaOrdinata]  DEFAULT ((1)) FOR [QuantitaOrdinata]
GO
ALTER TABLE [dbo].[Carrello]  WITH CHECK ADD  CONSTRAINT [FK_Carrello_Menu] FOREIGN KEY([IDMenu])
REFERENCES [dbo].[Menu] ([IDMenu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carrello] CHECK CONSTRAINT [FK_Carrello_Menu]
GO
USE [master]
GO
ALTER DATABASE [Pizzeria] SET  READ_WRITE 
GO