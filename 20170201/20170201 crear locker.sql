/****** Object:  Table [dbo].[Locker]    Script Date: 06/02/2017 04:33:09 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Locker](
	[LockerId] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[EstadoLockerId] [int] NOT NULL,
	[SedeId] [int] NOT NULL,
 CONSTRAINT [PK_Locker] PRIMARY KEY CLUSTERED 
(
	[LockerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


