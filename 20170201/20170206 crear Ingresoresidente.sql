/*
   lunes, 06 de febrero de 201704:49:13 p.m.
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
CREATE TABLE dbo.IngresoResidente
	(
	IngresoResidenteId int NOT NULL IDENTITY (1, 1),
	SedeId int NOT NULL,
	FechaIngreso datetime NOT NULL,
	PacienteId int NOT NULL,
	TipoSustanciaId int NOT NULL,
	RecibidoTratamientoTerapeutico bit NOT NULL,
	InstitucionTratamientoTerapeutico varchar(500) NOT NULL,
	RecibidoTratamientoPsiquiatrico bit NOT NULL,
	InstitucionTratamientoPsiquiatrico varchar(500) NOT NULL,
	AcudienteResidenteId int NOT NULL,
	NombreFamiliaAmigo varchar(200) NOT NULL,
	DireccionFamiliaAmigo varchar(200) NOT NULL,
	TelefonoFamiliaAmigo varchar(20) NOT NULL,
	CelularFamiliaAmigo varchar(20) NOT NULL,
	EstadoResidente int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.IngresoResidente ADD CONSTRAINT
	PK_IngresoResidente PRIMARY KEY CLUSTERED 
	(
	IngresoResidenteId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.IngresoResidente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.IngresoResidente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.IngresoResidente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.IngresoResidente', 'Object', 'CONTROL') as Contr_Per 