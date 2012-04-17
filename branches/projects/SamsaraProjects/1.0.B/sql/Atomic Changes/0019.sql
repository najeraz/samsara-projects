/*
   lunes, 16 de abril de 201210:11:18 a.m.
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
CREATE TABLE CustomerContext.Tmp_Customers
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
ALTER TABLE CustomerContext.Tmp_Customers SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM CustomerContext.Customers)
	 EXEC('INSERT INTO CustomerContext.Tmp_Customers (CustomerId, Name, ComercialName, CustomerInfrastructureId, BusinessTypeId, StaffId, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
		SELECT CustomerId, Name, ComercialName, CustomerInfrastructureId, BusinessTypeId, StaffId, Activated, Deleted, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy FROM CustomerContext.Customers WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE CustomerContext.Customers
GO
EXECUTE sp_rename N'CustomerContext.Tmp_Customers', N'Customers', 'OBJECT' 
GO
ALTER TABLE CustomerContext.Customers ADD CONSTRAINT
	PK_ERPCustomers PRIMARY KEY CLUSTERED 
	(
	CustomerId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.Customers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.Customers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.Customers', 'Object', 'CONTROL') as Contr_Per 