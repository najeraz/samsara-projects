/*
   miércoles, 11 de abril de 201205:59:14 p.m.
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
ALTER TABLE Framework.AbstractQuantities SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Framework.AbstractQuantities', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Framework.AbstractQuantities', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Framework.AbstractQuantities', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE TIConsulting.ServerConsulting
	DROP CONSTRAINT FK_ServerConsulting_ServerComputerTypes
GO
ALTER TABLE CustomerContext.ServerComputerTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.ServerComputerTypes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.ServerComputerTypes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.ServerComputerTypes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE TIConsulting.ServerConsulting
	DROP CONSTRAINT FK_ServerConsulting_RackTypes
GO
ALTER TABLE CustomerContext.RackTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.RackTypes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.RackTypes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.RackTypes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE TIConsulting.Tmp_ServerConsulting
	(
	ServerConsultingId int NOT NULL IDENTITY (1, 1),
	OrganizationName varchar(255) NOT NULL,
	Contact varchar(255) NULL,
	PhoneNumber varchar(255) NULL,
	ExtensionNumber varchar(255) NULL,
	Email varchar(255) NULL,
	AbstractQuantityId int NULL,
	FirstServer bit NULL,
	ServerUsage varchar(MAX) NULL,
	CurrentProblem varchar(MAX) NULL,
	NumberOfUsers int NULL,
	NumberOfUsersWillGrow bit NULL,
	FutureNumberOfUsers int NULL,
	CurrentStorageVolume decimal(10, 4) NULL,
	FutureStorageVolume decimal(10, 4) NULL,
	BrandPreference varchar(255) NULL,
	FullServerUptimeRequired bit NOT NULL,
	RedundantPowerSupply bit NULL,
	DataMigration bit NOT NULL,
	DataBackup bit NOT NULL,
	ArrayDisks varchar(MAX) NULL,
	Budget decimal(18, 4) NULL,
	HaveSite bit NOT NULL,
	OtherServerComputerTypePreference varchar(MAX) NULL,
	ServerComputerTypeId int NULL,
	RackTypeId int NULL,
	Activated bit NOT NULL,
	Deleted bit NOT NULL,
	CreatedOn datetime NOT NULL,
	CreatedBy int NOT NULL,
	UpdatedOn datetime NULL,
	UpdatedBy int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE TIConsulting.Tmp_ServerConsulting SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT TIConsulting.Tmp_ServerConsulting ON
GO
IF EXISTS(SELECT * FROM TIConsulting.ServerConsulting)
	 EXEC('INSERT INTO TIConsulting.Tmp_ServerConsulting (ServerConsultingId, OrganizationName, Contact, PhoneNumber, ExtensionNumber, Email, FirstServer, ServerUsage, CurrentProblem, NumberOfUsers, NumberOfUsersWillGrow, FutureNumberOfUsers, CurrentStorageVolume, FutureStorageVolume, BrandPreference, FullServerUptimeRequired, RedundantPowerSupply, DataMigration, DataBackup, ArrayDisks, Budget, HaveSite, OtherServerComputerTypePreference, ServerComputerTypeId, RackTypeId, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
		SELECT ServerConsultingId, OrganizationName, Contact, PhoneNumber, ExtensionNumber, Email, FirstServer, ServerUsage, CurrentProblem, NumberOfUsers, NumberOfUsersWillGrow, FutureNumberOfUsers, CurrentStorageVolume, FutureStorageVolume, BrandPreference, FullServerUptimeRequired, RedundantPowerSupply, DataMigration, DataBackup, ArrayDisks, Budget, HaveSite, OtherServerComputerTypePreference, ServerComputerTypeId, RackTypeId, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy FROM TIConsulting.ServerConsulting WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT TIConsulting.Tmp_ServerConsulting OFF
GO
ALTER TABLE TIConsulting.ServerConsulting
	DROP CONSTRAINT FK_ServerConsulting_ServerConsulting
GO
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers
	DROP CONSTRAINT FK_ServerConsultingOldServerComputers_ServerConsulting
GO
DROP TABLE TIConsulting.ServerConsulting
GO
EXECUTE sp_rename N'TIConsulting.Tmp_ServerConsulting', N'ServerConsulting', 'OBJECT' 
GO
ALTER TABLE TIConsulting.ServerConsulting ADD CONSTRAINT
	PK_ServerConsultings PRIMARY KEY CLUSTERED 
	(
	ServerConsultingId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE TIConsulting.ServerConsulting ADD CONSTRAINT
	FK_ServerConsulting_RackTypes FOREIGN KEY
	(
	RackTypeId
	) REFERENCES CustomerContext.RackTypes
	(
	RackTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsulting ADD CONSTRAINT
	FK_ServerConsulting_ServerComputerTypes FOREIGN KEY
	(
	ServerComputerTypeId
	) REFERENCES CustomerContext.ServerComputerTypes
	(
	ServerComputerTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsulting ADD CONSTRAINT
	FK_ServerConsulting_ServerConsulting FOREIGN KEY
	(
	ServerConsultingId
	) REFERENCES TIConsulting.ServerConsulting
	(
	ServerConsultingId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE TIConsulting.ServerConsulting ADD CONSTRAINT
	FK_ServerConsulting_AbstractQuantities FOREIGN KEY
	(
	AbstractQuantityId
	) REFERENCES Framework.AbstractQuantities
	(
	AbstractQuantityId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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
ALTER TABLE TIConsulting.ServerConsultingOldServerComputers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'TIConsulting.ServerConsultingOldServerComputers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsultingOldServerComputers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsultingOldServerComputers', 'Object', 'CONTROL') as Contr_Per 