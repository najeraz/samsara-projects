/*
   sábado, 14 de abril de 201209:56:21 a.m.
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
ALTER TABLE CustomerContext.CustomerInfrastructures
	DROP CONSTRAINT FK_CustomerInfrastructures_Customers
GO
ALTER TABLE CustomerContext.Customers SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.Customers', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.Customers', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.Customers', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.CustomerInfrastructures SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructures', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructures', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructures', 'Object', 'CONTROL') as Contr_Per 