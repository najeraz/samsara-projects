/*
   miércoles, 11 de abril de 201206:59:42 p.m.
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
ALTER TABLE TIConsulting.ServerConsulting
	DROP COLUMN BrandPreference
GO
ALTER TABLE TIConsulting.ServerConsulting SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'TIConsulting.ServerConsulting', 'Object', 'CONTROL') as Contr_Per 