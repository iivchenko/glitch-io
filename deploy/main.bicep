param location string = resourceGroup().location
param sqlAdmin string
param sqlAdminPass string

@allowed(['dev', 'prd'])
param env string  = 'prd'

var appName = 'glitchio'

resource sqlServer 'Microsoft.Sql/servers@2014-04-01' ={
  name: '${appName}-sql-server'
  location: location
  properties: {
    administratorLogin: sqlAdmin
    administratorLoginPassword: sqlAdminPass
  }
}

resource sqlServerFirewalRule 'Microsoft.Sql/servers/firewallRules@2022-05-01-preview' = {
  parent: sqlServer
  name: 'AllowAllWindowsAzureIps'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
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
    name: 'B1'
    capacity: 1
  }
}

resource profileApp 'Microsoft.Web/sites@2021-01-15' = {
  name: '${appName}-profile-service'
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings:[
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: env
        }
      ]
      connectionStrings: [
        {
          name: 'DefaultConnection'
          type: 'SQLAzure'
          connectionString: 'Server=tcp:${sqlServer.name}${environment().suffixes.sqlServerHostname},1433;Initial Catalog=${profileDb.name};Persist Security Info=False;User ID=${sqlAdmin};Password=${sqlAdminPass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
        }
      ]
    }
  }
}

resource clietnWebApp 'Microsoft.Web/sites@2021-01-15' = {
  name: '${appName}-client-webapp'
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings:[
        {
          // Blazor WASM has a but with env variables so that soluton will not work for now.
          // https://github.com/dotnet/aspnetcore/issues/28573
          name: 'ASPNETCORE_ENVIRONMENT'
          value: env
        }
      ]
    }
  }
}
