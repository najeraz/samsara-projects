/*
   sábado, 14 de abril de 201201:36:54 p.m.
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
ALTER TABLE Configuration.FormConfigurationGridColumns
	DROP CONSTRAINT FK_FormConfigurationGridColumns_TextFormats
GO
ALTER TABLE Framework.TextFormats SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Framework.TextFormats', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Framework.TextFormats', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Framework.TextFormats', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Configuration.FormConfigurationGridColumns
	DROP CONSTRAINT FK_GridColumnConfigurations_GridConfigurations
GO
ALTER TABLE Configuration.FormConfigurationGrids SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Configuration.FormConfigurationGrids', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Configuration.FormConfigurationGrids', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Configuration.FormConfigurationGrids', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE Configuration.Tmp_FormConfigurationGridColumns
	(
	FormConfigurationGridColumnId int NOT NULL IDENTITY (1, 1),
	FormConfigurationGridId int NOT NULL,
	ColumnName varchar(255) NOT NULL,
	BandKey varchar(255) NULL,
	Visible bit NOT NULL,
	ColumnEndUserName varchar(255) NOT NULL,
	TextFormatId int NULL,
	Width int NULL,
	CreatedOn datetime NULL,
	CreatedBy int NULL,
	Activated bit NULL,
	Deleted bit NULL,
	UpdatedOn datetime NULL,
	UpdatedBy int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Configuration.Tmp_FormConfigurationGridColumns SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT Configuration.Tmp_FormConfigurationGridColumns ON
GO
IF EXISTS(SELECT * FROM Configuration.FormConfigurationGridColumns)
	 EXEC('INSERT INTO Configuration.Tmp_FormConfigurationGridColumns (FormConfigurationGridColumnId, FormConfigurationGridId, ColumnName, BandKey, Visible, ColumnEndUserName, TextFormatId, CreatedOn, CreatedBy, Activated, Deleted, UpdatedOn, UpdatedBy)
		SELECT FormConfigurationGridColumnId, FormConfigurationGridId, ColumnName, BandKey, Visible, ColumnEndUserName, TextFormatId, CreatedOn, CreatedBy, Activated, Deleted, UpdatedOn, UpdatedBy FROM Configuration.FormConfigurationGridColumns WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT Configuration.Tmp_FormConfigurationGridColumns OFF
GO
DROP TABLE Configuration.FormConfigurationGridColumns
GO
EXECUTE sp_rename N'Configuration.Tmp_FormConfigurationGridColumns', N'FormConfigurationGridColumns', 'OBJECT' 
GO
ALTER TABLE Configuration.FormConfigurationGridColumns ADD CONSTRAINT
	PK_GridColumnConfigurations PRIMARY KEY CLUSTERED 
	(
	FormConfigurationGridColumnId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Configuration.FormConfigurationGridColumns ADD CONSTRAINT
	FK_GridColumnConfigurations_GridConfigurations FOREIGN KEY
	(
	FormConfigurationGridId
	) REFERENCES Configuration.FormConfigurationGrids
	(
	FormConfigurationGridId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Configuration.FormConfigurationGridColumns ADD CONSTRAINT
	FK_FormConfigurationGridColumns_TextFormats FOREIGN KEY
	(
	TextFormatId
	) REFERENCES Framework.TextFormats
	(
	TextFormatId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'Configuration.FormConfigurationGridColumns', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Configuration.FormConfigurationGridColumns', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Configuration.FormConfigurationGridColumns', 'Object', 'CONTROL') as Contr_Per 