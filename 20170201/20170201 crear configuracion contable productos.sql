/****** Object:  Table [dbo].[ConfiguracionContableGrupo]    Script Date: 01/02/2017 09:05:42 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConfiguracionContableGrupo](
	[ConfiguracionContableGrupoId] [int] IDENTITY(1,1) NOT NULL,
	[GrupoInventarioId] [int] NOT NULL,
	[CuentaContableActivo] [bigint] NOT NULL,
	[CuentaContableGasto] [bigint] NOT NULL,
	[CuentaContableCosto] [bigint] NOT NULL,
	[CuentaContableIngreso] [bigint] NOT NULL,
 CONSTRAINT [PK_ConfiguracionContableGrupo] PRIMARY KEY CLUSTERED 
(
	[ConfiguracionContableGrupoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


