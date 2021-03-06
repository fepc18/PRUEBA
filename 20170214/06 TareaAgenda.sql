/*
   martes, 14 de febrero de 201704:28:48 p.m.
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
CREATE TABLE dbo.TareaAgenda
	(
	TareaAgendaId int NOT NULL IDENTITY (1, 1),
	UsuarioPropietario varchar(50) NOT NULL,
	FechaInicio date NOT NULL,
	HoraInicio time(7) NOT NULL,
	FechaFin date NOT NULL,
	HoraFin time(7) NOT NULL,
	Asunto varchar(200) NOT NULL,
	Descripcion varchar(1000) NOT NULL,
	ReunionId int NOT NULL,
	Ubicacion varchar(200) NOT NULL,
	esReunion nchar(10) NOT NULL,
	EstadoTareaAgendaId int NOT NULL,
	FechaOperacion datetime NOT NULL,
	Usuario varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TareaAgenda ADD CONSTRAINT
	PK_TareaAgenda PRIMARY KEY CLUSTERED 
	(
	TareaAgendaId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TareaAgenda SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TareaAgenda', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TareaAgenda', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TareaAgenda', 'Object', 'CONTROL') as Contr_Per 