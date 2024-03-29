/*
   lunes, 06 de febrero de 201705:46:37 p.m.
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
CREATE TABLE dbo.VisitaResidente
	(
	VisitaResidenteId int NOT NULL,
	FechaVisita datetime NOT NULL,
	PacienteId int NOT NULL,
	NombreVisitante varchar(200) NOT NULL,
	EPSVisitante varchar(200) NOT NULL,
	TelefonoVisitante varchar(20) NOT NULL,
	Observaciones varchar(1000) NOT NULL,
	FechaOperacion datetime NOT NULL,
	Usuario varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.VisitaResidente ADD CONSTRAINT
	PK_VisitaResidente PRIMARY KEY CLUSTERED 
	(
	VisitaResidenteId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.VisitaResidente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.VisitaResidente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.VisitaResidente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.VisitaResidente', 'Object', 'CONTROL') as Contr_Per 