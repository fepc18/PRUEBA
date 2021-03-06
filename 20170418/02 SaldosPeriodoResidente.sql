/*
   martes, 18 de abril de 201705:14:24 p.m.
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
CREATE TABLE dbo.SaldosPeriodoResidente
	(
	SaldosPeriodoResidenteId int NOT NULL IDENTITY (1, 1),
	PeriodoId int NOT NULL,
	BodegaId int NOT NULL,
	PacienteId int NOT NULL,
	ProductoId int NOT NULL,
	LoteId int NOT NULL,
	Anterior float(53) NOT NULL,
	Entradas float(53) NOT NULL,
	Salidas float(53) NOT NULL,
	ValorAnterior money NOT NULL,
	ValorEntradas money NOT NULL,
	ValorSalidas money NOT NULL,
	Stock float(53) NOT NULL,
	ValorStock money NOT NULL,
	Costo money NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.SaldosPeriodoResidente ADD CONSTRAINT
	PK_SaldosPeriodoResidente PRIMARY KEY CLUSTERED 
	(
	SaldosPeriodoResidenteId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SaldosPeriodoResidente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SaldosPeriodoResidente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SaldosPeriodoResidente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SaldosPeriodoResidente', 'Object', 'CONTROL') as Contr_Per 