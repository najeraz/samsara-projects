/*
   sábado, 14 de abril de 201209:49:34 a.m.
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
ALTER TABLE CustomerContext.CustomerInfrastructures SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructures', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructures', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructures', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.BusinessTypes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.BusinessTypes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.BusinessTypes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.BusinessTypes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE AlleatoERP.ERPCustomers
	DROP CONSTRAINT FK_ERPCustomers_Staffs
GO
ALTER TABLE AlleatoERP.Staffs SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'AlleatoERP.Staffs', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'AlleatoERP.Staffs', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'AlleatoERP.Staffs', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE AlleatoERP.Tmp_ERPCustomers
	(
	CustomerId int NOT NULL,
	Name varchar(255) NULL,
	ComercialName varchar(255) NULL,
	CustomerInfrastructureId int NULL,
	BusinessTypeId int NULL,
	StaffId int NOT NULL,
	Activated bit NOT NULL,
	Deleted bit NOT NULL,
	CreatedOn datetime NOT NULL,
	CreatedBy int NOT NULL,
	UpdatedOn datetime NULL,
	UpdatedBy int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE AlleatoERP.Tmp_ERPCustomers SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM AlleatoERP.ERPCustomers)
	 EXEC('INSERT INTO AlleatoERP.Tmp_ERPCustomers (CustomerId, Name, ComercialName, StaffId, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
		SELECT ERPCustomerId, Name, ComercialName, StaffId, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy FROM AlleatoERP.ERPCustomers WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE AlleatoERP.ERPCustomers
GO
EXECUTE sp_rename N'AlleatoERP.Tmp_ERPCustomers', N'ERPCustomers', 'OBJECT' 
GO
ALTER TABLE AlleatoERP.ERPCustomers ADD CONSTRAINT
	PK_ERPCustomers PRIMARY KEY CLUSTERED 
	(
	CustomerId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE AlleatoERP.ERPCustomers ADD CONSTRAINT
	FK_ERPCustomers_Staffs FOREIGN KEY
	(
	StaffId
	) REFERENCES AlleatoERP.Staffs
	(
	StaffId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE AlleatoERP.ERPCustomers ADD CONSTRAINT
	FK_ERPCustomers_BusinessTypes FOREIGN KEY
	(
	BusinessTypeId
	) REFERENCES CustomerContext.BusinessTypes
	(
	BusinessTypeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE AlleatoERP.ERPCustomers ADD CONSTRAINT
	FK_ERPCustomers_CustomerInfrastructures FOREIGN KEY
	(
	CustomerInfrastructureId
	) REFERENCES CustomerContext.CustomerInfrastructures
	(
	CustomerInfrastructureId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'AlleatoERP.ERPCustomers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'AlleatoERP.ERPCustomers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'AlleatoERP.ERPCustomers', 'Object', 'CONTROL') as Contr_Per 