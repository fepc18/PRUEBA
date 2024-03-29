/*
   jueves, 09 de marzo de 201705:42:25 p.m.
   Usuario: adm
   Servidor: co1p8s\dev_02
   Base de datos: FlujosMotorDecision
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.ActivoFijo
	(
	ActivoFijoId int NOT NULL IDENTITY (1, 1),
	Codigo varchar(50) NOT NULL,
	NumeroSerie varchar(50) NOT NULL,
	Marca varchar(50) NOT NULL,
	Modelo varchar(50) NOT NULL,
	Color varchar(50) NOT NULL,
	UbicacionDestinoId int NOT NULL,
	EstadoActivoFijoId int NOT NULL,
	TipoIngreso int NOT NULL,
	FechaAdquisicion date NOT NULL,
	FechaAlta date NOT NULL,
	ValorUnitario money NOT NULL,
	GrupoActivoId int NOT NULL,
	NumeroFactura varchar(50) NOT NULL,
	PeriodoIngreso varchar(50) NOT NULL,
	DescripcionEstado varchar(500) NOT NULL,
	MenorCuantia bit NOT NULL,
	EstadoIngreso int NOT NULL,
	FechaOperacion datetime NOT NULL,
	Usuario varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ActivoFijo ADD CONSTRAINT
	PK_ActivoFijo PRIMARY KEY CLUSTERED 
	(
	ActivoFijoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ActivoFijo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ActivoFijo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ActivoFijo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ActivoFijo', 'Object', 'CONTROL') as Contr_Per 