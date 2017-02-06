/*
   lunes, 06 de febrero de 201705:43:28 p.m.
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
CREATE TABLE dbo.LlamadaAutorizada
	(
	LlamadaAutorizadaId int NOT NULL IDENTITY (1, 1),
	PacienteId int NOT NULL,
	NombreAutorizado varchar(200) NOT NULL,
	IdentificacionAutorizado varchar(20) NOT NULL,
	Telefono varchar(20) NOT NULL,
	Observacion varchar(1000) NOT NULL,
	FechaOperacion datetime NOT NULL,
	Usuario varchar(20) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.LlamadaAutorizada ADD CONSTRAINT
	PK_LlamadaAutorizada PRIMARY KEY CLUSTERED 
	(
	LlamadaAutorizadaId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.LlamadaAutorizada SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.LlamadaAutorizada', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.LlamadaAutorizada', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.LlamadaAutorizada', 'Object', 'CONTROL') as Contr_Per 