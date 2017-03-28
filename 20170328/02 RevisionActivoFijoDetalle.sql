USE [FlujosMotorDecision]
GO

/****** Object:  Table [dbo].[RevisionActivoFijoDetalle]    Script Date: 28/03/2017 02:34:56 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RevisionActivoFijoDetalle](
	[RevisionActivoFijoDetalleId] [int] IDENTITY(1,1) NOT NULL,
	[RevisionActivoFijoId] [int] NOT NULL,
	[ActivoFijoId] [int] NOT NULL,
	[EstadoActivoFijo] [int] NOT NULL,
	[TerceroId] [int] NOT NULL,
	[DescripcionEstado] [varchar](2000) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
 CONSTRAINT [PK_RevisionActivoFijoDetalle] PRIMARY KEY CLUSTERED 
(
	[RevisionActivoFijoDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


