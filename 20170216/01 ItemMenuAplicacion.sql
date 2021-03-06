/*
   jueves, 16 de febrero de 201705:44:29 p.m.
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
CREATE TABLE dbo.ItemMenuAplicacion
	(
	ItemMenuAplicacionId int NOT NULL,
	Opcion varchar(200) NOT NULL,
	TipoItemMenuId int NOT NULL,
	AplicacionId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.ItemMenuAplicacion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.ItemMenuAplicacion', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.ItemMenuAplicacion', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.ItemMenuAplicacion', 'Object', 'CONTROL') as Contr_Per 