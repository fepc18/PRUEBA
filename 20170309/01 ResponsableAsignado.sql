/*
   jueves, 09 de marzo de 201705:28:02 p.m.
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
CREATE TABLE dbo.ResponsableAsignado
	(
	ResponsableAsignadoId int NOT NULL IDENTITY (1, 1),
	ActivoFijoId int NOT NULL,
	TerceroId int NOT NULL,
	FechaAsignacion datetime NOT NULL,
	FechaRetiro datetime NOT NULL,
	Vigente bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ResponsableAsignado ADD CONSTRAINT
	PK_ResponsableAsignado PRIMARY KEY CLUSTERED 
	(
	ResponsableAsignadoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ResponsableAsignado SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ResponsableAsignado', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ResponsableAsignado', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ResponsableAsignado', 'Object', 'CONTROL') as Contr_Per 