/*
   viernes, 13 de abril de 201211:48:32 a.m.
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
ALTER TABLE ProjectsAndTendering.TenderLines
	DROP CONSTRAINT FK_TenderLines_Competitors
GO
ALTER TABLE ProjectsAndTendering.Competitors SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.Competitors', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Competitors', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Competitors', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLines
	DROP CONSTRAINT FK_TenderLines_Tenders
GO
ALTER TABLE ProjectsAndTendering.Tenders SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.Tenders', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Tenders', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Tenders', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLines
	DROP CONSTRAINT FK_TenderLines_Products
GO
ALTER TABLE AlleatoERP.Products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'AlleatoERP.Products', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'AlleatoERP.Products', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'AlleatoERP.Products', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLines
	DROP CONSTRAINT FK_TenderLines_Wholesalers
GO
ALTER TABLE ProjectsAndTendering.Wholesalers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.Wholesalers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Wholesalers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Wholesalers', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLines
	DROP CONSTRAINT FK_TenderLines_Manufacturers
GO
ALTER TABLE ProjectsAndTendering.Manufacturers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.Manufacturers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Manufacturers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.Manufacturers', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLines
	DROP CONSTRAINT FK_TenderLines_TenderLineStatuses
GO
ALTER TABLE ProjectsAndTendering.TenderLineStatuses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineStatuses', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineStatuses', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineStatuses', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE ProjectsAndTendering.Tmp_TenderLines
	(
	TenderLineId int NOT NULL IDENTITY (1, 1),
	TenderId int NULL,
	TenderLineStatusId int NULL,
	ProductId int NULL,
	CompetitorWonId int NULL,
	TenderLineNumber int NULL,
	Name nvarchar(255) NULL,
	Quantity decimal(19, 4) NULL,
	Concept text NULL,
	Description text NULL,
	ManufacturerId int NULL,
	WholesalerId int NULL,
	PricingStrategyId int NULL,
	Deleted bit NOT NULL,
	Activated bit NOT NULL,
	CreatedOn datetime NULL,
	CreatedBy int NULL,
	UpdatedOn datetime NULL,
	UpdatedBy int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE ProjectsAndTendering.Tmp_TenderLines SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT ProjectsAndTendering.Tmp_TenderLines ON
GO
IF EXISTS(SELECT * FROM ProjectsAndTendering.TenderLines)
	 EXEC('INSERT INTO ProjectsAndTendering.Tmp_TenderLines (TenderLineId, TenderId, TenderLineStatusId, ProductId, CompetitorWonId, Name, Quantity, Concept, Description, ManufacturerId, WholesalerId, PricingStrategyId, Deleted, Activated, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy)
		SELECT TenderLineId, TenderId, TenderLineStatusId, ProductId, CompetitorWonId, Name, Quantity, Concept, Description, ManufacturerId, WholesalerId, PricingStrategyId, Deleted, Activated, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy FROM ProjectsAndTendering.TenderLines WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT ProjectsAndTendering.Tmp_TenderLines OFF
GO
ALTER TABLE ProjectsAndTendering.TenderLineWholesalers
	DROP CONSTRAINT FK_TenderLinesWholesalers_TenderLines
GO
ALTER TABLE ProjectsAndTendering.TenderLineManufacturers
	DROP CONSTRAINT FK_TenderLinesManufacturers_TenderLines
GO
ALTER TABLE ProjectsAndTendering.TenderLineExtraCosts
	DROP CONSTRAINT FK_TenderLineExtraCosts_TenderLines
GO
ALTER TABLE ProjectsAndTendering.TenderLineCompetitors
	DROP CONSTRAINT FK_TenderLinesCompetitors_TenderLines
GO
DROP TABLE ProjectsAndTendering.TenderLines
GO
EXECUTE sp_rename N'ProjectsAndTendering.Tmp_TenderLines', N'TenderLines', 'OBJECT' 
GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	PK__TenderLines__15A53433 PRIMARY KEY CLUSTERED 
	(
	TenderLineId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	FK_TenderLines_TenderLineStatuses FOREIGN KEY
	(
	TenderLineStatusId
	) REFERENCES ProjectsAndTendering.TenderLineStatuses
	(
	TenderLineStatusId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	FK_TenderLines_Manufacturers FOREIGN KEY
	(
	ManufacturerId
	) REFERENCES ProjectsAndTendering.Manufacturers
	(
	ManufacturerId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	FK_TenderLines_Wholesalers FOREIGN KEY
	(
	WholesalerId
	) REFERENCES ProjectsAndTendering.Wholesalers
	(
	WholesalerId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	FK_TenderLines_Products FOREIGN KEY
	(
	ProductId
	) REFERENCES AlleatoERP.Products
	(
	ProductId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	FK_TenderLines_Tenders FOREIGN KEY
	(
	TenderId
	) REFERENCES ProjectsAndTendering.Tenders
	(
	TenderId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLines ADD CONSTRAINT
	FK_TenderLines_Competitors FOREIGN KEY
	(
	CompetitorWonId
	) REFERENCES ProjectsAndTendering.Competitors
	(
	CompetitorId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.TenderLines', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLines', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLines', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLineCompetitors ADD CONSTRAINT
	FK_TenderLinesCompetitors_TenderLines FOREIGN KEY
	(
	TenderLineId
	) REFERENCES ProjectsAndTendering.TenderLines
	(
	TenderLineId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLineCompetitors SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineCompetitors', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineCompetitors', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineCompetitors', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLineExtraCosts ADD CONSTRAINT
	FK_TenderLineExtraCosts_TenderLines FOREIGN KEY
	(
	TenderLineId
	) REFERENCES ProjectsAndTendering.TenderLines
	(
	TenderLineId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLineExtraCosts SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineExtraCosts', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineExtraCosts', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineExtraCosts', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLineManufacturers ADD CONSTRAINT
	FK_TenderLinesManufacturers_TenderLines FOREIGN KEY
	(
	TenderLineId
	) REFERENCES ProjectsAndTendering.TenderLines
	(
	TenderLineId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLineManufacturers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineManufacturers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineManufacturers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineManufacturers', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE ProjectsAndTendering.TenderLineWholesalers ADD CONSTRAINT
	FK_TenderLinesWholesalers_TenderLines FOREIGN KEY
	(
	TenderLineId
	) REFERENCES ProjectsAndTendering.TenderLines
	(
	TenderLineId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ProjectsAndTendering.TenderLineWholesalers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineWholesalers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineWholesalers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'ProjectsAndTendering.TenderLineWholesalers', 'Object', 'CONTROL') as Contr_Per 