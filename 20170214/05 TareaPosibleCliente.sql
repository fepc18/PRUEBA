/*
   martes, 14 de febrero de 201703:38:54 p.m.
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
CREATE TABLE dbo.TareaPosibleCliente
	(
	TareaPosibleClienteI int NOT NULL IDENTITY (1, 1),
	PosibleClienteId int NOT NULL,
	Asunto varchar(200) NOT NULL,
	Descripcion varchar(1000) NOT NULL,
	FechaVencimiento datetime NOT NULL,
	PrioridadTareaId int NOT NULL,
	PropositoTareaId int NOT NULL,
	EstadoTareaId int NOT NULL,
	UsuarioPropietario varchar(50) NOT NULL,
	FechaOperacion datetime NOT NULL,
	Usuario varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TareaPosibleCliente ADD CONSTRAINT
	PK_TareaPosibleCliente PRIMARY KEY CLUSTERED 
	(
	TareaPosibleClienteI
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TareaPosibleCliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TareaPosibleCliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TareaPosibleCliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TareaPosibleCliente', 'Object', 'CONTROL') as Contr_Per 