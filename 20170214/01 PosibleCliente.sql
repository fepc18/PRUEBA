/*
   martes, 14 de febrero de 201703:13:48 p.m.
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
CREATE TABLE dbo.PosibleCliente
	(
	PosibleClienteId int NOT NULL IDENTITY (1, 1),
	UsuarioPropietario varchar(50) NOT NULL,
	Empresa varchar(300) NOT NULL,
	Nombres varchar(200) NOT NULL,
	Apellidos varchar(200) NOT NULL,
	Titulo varchar(100) NOT NULL,
	CorreoElectronico varchar(200) NOT NULL,
	Direccion varchar(200) NOT NULL,
	Telefono varchar(20) NOT NULL,
	Fax varchar(20) NOT NULL,
	Celular varchar(20) NOT NULL,
	SitioWeb varchar(200) NOT NULL,
	FuentePosibleClienteId int NOT NULL,
	EstadoPosibleClienteId int NOT NULL,
	SectorPosibleClienteId int NOT NULL,
	CantidadEmpleados int NOT NULL,
	IngresosAnuales money NOT NULL,
	CalificacionPosibleClienteId int NOT NULL,
	Skype varchar(20) NOT NULL,
	Twiter varchar(20) NOT NULL,
	CiudadId int NOT NULL,
	Descripcion varchar(1000) NOT NULL,
	FechaOperacion datetime NOT NULL,
	Usuario varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.PosibleCliente ADD CONSTRAINT
	PK_PosibleCliente PRIMARY KEY CLUSTERED 
	(
	PosibleClienteId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.PosibleCliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.PosibleCliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.PosibleCliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.PosibleCliente', 'Object', 'CONTROL') as Contr_Per 