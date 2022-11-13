param location string = resourceGroup().location
param sqlServerAdmin string
param sqlServerAdminSid string
param administratorLogin string
param tenantId string

var appName = 'glitchio'

resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: '${appName}-sql-server'
  location: location
  properties: {
    administratorLogin: administratorLogin
    administrators: {
      administratorType: 'ActiveDirectory'
      azureADOnlyAuthentication: true
      login: sqlServerAdmin
      principalType: 'User'
      sid: sqlServerAdminSid
      tenantId: tenantId
    }
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
    restrictOutboundNetworkAccess: 'Disabled'
    version: '12.0'
  }
}

resource sqlServerAdministrator 'Microsoft.Sql/servers/administrators@2022-05-01-preview' = {
  name: 'ActiveDirectory'
  parent: sqlServer
  properties: {
    administratorType: 'ActiveDirectory'
    login: sqlServerAdmin
    sid: sqlServerAdminSid
    tenantId: tenantId
  }
}

resource profileDb 'Microsoft.Sql/servers/databases@2022-05-01-preview' = {
  name: '${appName}-profile-db'
  location: location
  sku: {
    capacity: 1
    family: 'Gen5'
    name: 'GP_S_Gen5'
    tier: 'GeneralPurpose'
  }
  parent: sqlServer
  properties: {
    autoPauseDelay: 60
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    isLedgerOn: false
    maxSizeBytes: 1073741824
    minCapacity: 1
    readScale: 'Disabled'
    requestedBackupStorageRedundancy: 'Local'
    zoneRedundant: false
  }
}
