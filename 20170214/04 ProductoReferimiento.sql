/*
   martes, 14 de febrero de 201703:27:41 p.m.
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
CREATE TABLE dbo.ProductoReferimiento
	(
	ProductoReferimientoId int NOT NULL IDENTITY (1, 1),
	Codigo varchar(20) NOT NULL,
	Nombre varchar(20) NOT NULL,
	Descripcion varchar(1000) NOT NULL,
	Activo bit NOT NULL,
	FechaInicioVentas date NOT NULL,
	FechaFinalVentas date NOT NULL,
	PrecioUnidad money NOT NULL,
	Comision money NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ProductoReferimiento ADD CONSTRAINT
	PK_ProductoReferimiento PRIMARY KEY CLUSTERED 
	(
	ProductoReferimientoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ProductoReferimiento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ProductoReferimiento', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ProductoReferimiento', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ProductoReferimiento', 'Object', 'CONTROL') as Contr_Per 