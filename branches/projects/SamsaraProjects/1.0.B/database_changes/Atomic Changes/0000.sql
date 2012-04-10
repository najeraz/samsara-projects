/*
   martes, 10 de abril de 201210:27:27 a.m.
   Usuario: sa
   Servidor: (local)
   Base de datos: SamsaraProjects
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
ALTER TABLE CustomerContext.RackTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.RackTypes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.RackTypes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.RackTypes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.ServerComputerTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.ServerComputerTypes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.ServerComputerTypes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.ServerComputerTypes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.OperativeSystems SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.OperativeSystems', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.OperativeSystems', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.OperativeSystems', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.ComputerBrands SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.ComputerBrands', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.ComputerBrands', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.ComputerBrands', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers
	DROP CONSTRAINT FK_ServerConsultingOldServerComputers_ServerConsulting
GO
ALTER TABLE TIConsulting.ServerConsulting SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE TIConsulting.Tmp_ServerConsultingOldServerComputers
	(
	ServerConsultingOldServerComputerId int NOT NULL IDENTITY (1, 1),
	ServerConsultingId int NULL,
	ServerComputerTypeId int NULL,
	ComputerBrandId int NULL,
	OperativeSystemId int NULL,
	RackTypeId int NULL,
	ServerModel varchar(255) NULL,
	ServerSpecs varchar(MAX) NULL,
	Activated bit NOT NULL,
	Deleted bit NOT NULL,
	CreatedOn datetime NULL,
	CreatedBy int NULL,
	UpdatedOn datetime NULL,
	UpdatedBy int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE TIConsulting.Tmp_ServerConsultingOldServerComputers SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT TIConsulting.Tmp_ServerConsultingOldServerComputers ON
GO
IF EXISTS(SELECT * FROM TIConsulting.ServerConsultingOldServerComputers)
	 EXEC('INSERT INTO TIConsulting.Tmp_ServerConsultingOldServerComputers (ServerConsultingOldServerComputerId, ServerConsultingId, ServerModel, ServerSpecs, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
		SELECT ServerConsultingOldServerComputerId, ServerConsultingId, ServerModel, ServerSpecs, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy FROM TIConsulting.ServerConsultingOldServerComputers WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT TIConsulting.Tmp_ServerConsultingOldServerComputers OFF
GO
DROP TABLE TIConsulting.ServerConsultingOldServerComputers
GO
EXECUTE sp_rename N'TIConsulting.Tmp_ServerConsultingOldServerComputers', N'ServerConsultingOldServerComputers', 'OBJECT' 
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers ADD CONSTRAINT
	PK_ServerConsultingOldServerComputers PRIMARY KEY CLUSTERED 
	(
	ServerConsultingOldServerComputerId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers ADD CONSTRAINT
	FK_ServerConsultingOldServerComputers_ServerConsulting FOREIGN KEY
	(
	ServerConsultingId
	) REFERENCES TIConsulting.ServerConsulting
	(
	ServerConsultingId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers ADD CONSTRAINT
	FK_ServerConsultingOldServerComputers_ComputerBrands FOREIGN KEY
	(
	ComputerBrandId
	) REFERENCES CustomerContext.ComputerBrands
	(
	ComputerBrandId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers ADD CONSTRAINT
	FK_ServerConsultingOldServerComputers_OperativeSystems FOREIGN KEY
	(
	OperativeSystemId
	) REFERENCES CustomerContext.OperativeSystems
	(
	OperativeSystemId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers ADD CONSTRAINT
	FK_ServerConsultingOldServerComputers_ServerComputerTypes FOREIGN KEY
	(
	ServerComputerTypeId
	) REFERENCES CustomerContext.ServerComputerTypes
	(
	ServerComputerTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers ADD CONSTRAINT
	FK_ServerConsultingOldServerComputers_RackTypes FOREIGN KEY
	(
	RackTypeId
	) REFERENCES CustomerContext.RackTypes
	(
	RackTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'TIConsulting.ServerConsultingOldServerComputers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsultingOldServerComputers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsultingOldServerComputers', 'Object', 'CONTROL') as Contr_Per 