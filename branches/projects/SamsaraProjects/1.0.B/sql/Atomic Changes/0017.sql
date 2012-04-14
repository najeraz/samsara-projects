

UPDATE Configuration.FormConfigurationGrids
SET GridName = 'grdPrincipal'
WHERE FormConfigurationId = 43 AND GridName = 'grdSchSearch'

UPDATE Configuration.FormConfigurations
SET FormEndUserName = 'Clientes'
WHERE FormConfigurationId = 43 