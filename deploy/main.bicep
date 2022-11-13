param location string = resourceGroup().location
param sqlAdmin string
param sqlAdminPass string

var appName = 'glitchio'

resource sqlServer 'Microsoft.Sql/servers@2014-04-01' ={
  name: '${appName}-sql-server'
  location: location
  properties: {
    administratorLogin: sqlAdmin
    administratorLoginPassword: sqlAdminPass
  }
}

resource profileDb 'Microsoft.Sql/servers/databases@2014-04-01' = {
  parent: sqlServer
  name: '${appName}-profile-db'
  location: location
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    edition: 'Basic'
    maxSizeBytes: '1073741824'
    requestedServiceObjectiveName: 'Basic'
  }
}

resource appServicePlan 'Microsoft.Web/serverfarms@2020-12-01' = {
  name: '${appName}-plan'
  location: location
  kind: 'linux'
  sku: {    
    name: 'F1'
    capacity: 1
  }
}

resource profileApp 'Microsoft.Web/sites@2021-01-15' = {
  name: '${appName}-profile-service'
  location: location
  properties: {
    serverFarmId: appServicePlan.id
  }
}

resource clientWebApp 'Microsoft.Web/staticSites@2021-01-01' = {
  name: '${appName}-client-web'
  location: location
  sku:{
    name: 'Free'
    tier: 'Free'
  }
  properties: {
    stagingEnvironmentPolicy: 'Enabled'
    allowConfigFileUpdates: true
  }
}
