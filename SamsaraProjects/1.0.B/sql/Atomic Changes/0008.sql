/*
   jueves, 12 de abril de 201201:37:49 p.m.
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
CREATE TABLE Commissions.Tmp_CommissionPayments
	(
	CommissionPaymentId int NOT NULL IDENTITY (1, 1),
	ExternalPaymentId int NULL,
	Amount decimal(18, 4) NOT NULL,
	Comments varchar(255) NULL,
	Month int NOT NULL,
	Year int NOT NULL,
	IsSalesRetail bit NOT NULL,
	StaffNames varchar(MAX) NOT NULL,
	CreatedBy int NOT NULL,
	UpdatedBy int NULL,
	CreatedOn datetime NOT NULL,
	UpdatedOn datetime NULL,
	Activated bit NOT NULL,
	Deleted bit NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE Commissions.Tmp_CommissionPayments SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT Commissions.Tmp_CommissionPayments ON
GO
IF EXISTS(SELECT * FROM Commissions.CommissionPayments)
	 EXEC('INSERT INTO Commissions.Tmp_CommissionPayments (CommissionPaymentId, Amount, Comments, Month, Year, IsSalesRetail, StaffNames, CreatedBy, UpdatedBy, CreatedOn, UpdatedOn, Activated, Deleted)
		SELECT CommissionPaymentId, Amount, Comments, Month, Year, IsSalesRetail, StaffNames, CreatedBy, UpdatedBy, CreatedOn, UpdatedOn, Activated, Deleted FROM Commissions.CommissionPayments WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT Commissions.Tmp_CommissionPayments OFF
GO
ALTER TABLE Commissions.CommissionPaymentStaffs
	DROP CONSTRAINT FK_CommissionPaymentStaffs_CommissionPayments
GO
DROP TABLE Commissions.CommissionPayments
GO
EXECUTE sp_rename N'Commissions.Tmp_CommissionPayments', N'CommissionPayments', 'OBJECT' 
GO
ALTER TABLE Commissions.CommissionPayments ADD CONSTRAINT
	PK_CommissionPayments PRIMARY KEY CLUSTERED 
	(
	CommissionPaymentId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_CommissionPayments ON Commissions.CommissionPayments
	(
	ExternalPaymentId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
COMMIT
select Has_Perms_By_Name(N'Commissions.CommissionPayments', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Commissions.CommissionPayments', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Commissions.CommissionPayments', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE Commissions.CommissionPaymentStaffs ADD CONSTRAINT
	FK_CommissionPaymentStaffs_CommissionPayments FOREIGN KEY
	(
	CommissionPaymentId
	) REFERENCES Commissions.CommissionPayments
	(
	CommissionPaymentId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Commissions.CommissionPaymentStaffs SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'Commissions.CommissionPaymentStaffs', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'Commissions.CommissionPaymentStaffs', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'Commissions.CommissionPaymentStaffs', 'Object', 'CONTROL') as Contr_Per 