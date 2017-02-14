
/****** Object:  Table [dbo].[NotaPosibleCliente]    Script Date: 14/02/2017 03:46:21 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[NotaPosibleCliente](
	[NotaPosibleClienteId] [int] IDENTITY(1,1) NOT NULL,
	[PosibleClienteId] [int] NOT NULL,
	[Titulo] [varchar](200) NOT NULL,
	[Descripcion] [varchar](1000) NOT NULL,
	[UsuarioPropietario] [varchar](50) NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NotaPosibleCliente] PRIMARY KEY CLUSTERED 
(
	[NotaPosibleClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


