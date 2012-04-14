/*
   viernes, 13 de abril de 201205:46:39 p.m.
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
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkSwitchs
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkSwitchs_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkRouters
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkRouters_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkFirewalls
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkFirewalls_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkCablings
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkCablings_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkCommutators
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkCommutators_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworks
	DROP CONSTRAINT FK_CustomerInfrastructureNetworks_CustomerInfrastructures
GO
ALTER TABLE CustomerContext.CustomerInfrastructures
	DROP CONSTRAINT FK_CustomerInfrastructures_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkWifis
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkWifis_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworks
	DROP CONSTRAINT FK_CustomerInfrastructureNetworks_CustomerInfrastructureNetworkWifis
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkSites
	DROP CONSTRAINT FK_CustomerInfrastructureNetworkSites_CustomerInfrastructureNetworks
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworks SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructureNetworks', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructureNetworks', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructureNetworks', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkSites ADD CONSTRAINT
	FK_CustomerInfrastructureNetworkSites_CustomerInfrastructureNetworks FOREIGN KEY
	(
	CustomerInfrastructureNetworkId
	) REFERENCES CustomerContext.CustomerInfrastructureNetworks
	(
	CustomerInfrastructureNetworkId
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkSites SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructureNetworkSites', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructureNetworkSites', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'CustomerContext.CustomerInfrastructureNetworkSites', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworkWifis ADD CONSTRAINT
	FK_CustomerInfrastructureNetworkWifis_CustomerInfrastructureNetworks FOREIGN KEY
	(
	CustomerInfrastructureNetworkId
	) REFERENCES CustomerContext.CustomerInfrastructureNetworks
	(
	CustomerInfrastructureNetworkId
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE CustomerContext.CustomerInfrastructureNetworks ADD CONSTRAINT
	FK_CustomerInfrastructureNetworks_CustomerInfrastructureNetworkWifis FOREIGN KEY
	(
	CustomerInfrastructureNetworkWifiId
	) REFERENCES CustomerContext.CustomerInfrastructureNetworkWifis
	(
	CustomerInfrastructureNetworkWifiId
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO
COMMIT
