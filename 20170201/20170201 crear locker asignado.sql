/****** Object:  Table [dbo].[LockerAsignado]    Script Date: 06/02/2017 04:33:39 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LockerAsignado](
	[LockerAsignadoId] [int] IDENTITY(1,1) NOT NULL,
	[LockerId] [int] NOT NULL,
	[PacienteId] [bigint] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
	[FechaRetiro] [datetime] NOT NULL,
	[Vigente] [bit] NOT NULL,
 CONSTRAINT [PK_LockerAsignado] PRIMARY KEY CLUSTERED 
(
	[LockerAsignadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


