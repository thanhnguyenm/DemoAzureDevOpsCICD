//az apim create --name myapim --resource-group myResourceGroup --publisher-name Contoso --publisher-email admin@contoso.com --no-wait
//az apim show --name myapim --resource-group myResourceGroup --output table
//az resource list --resource-group exampleRG

param apimName string = 'devopsdemoapim'
param publisherEmail string = 'nguyenminhthanhitc@outlook.com'
param publisherName string = 'nguyenminhthanhitc'

@allowed([
  'Developer'
  'Standard'
  'Premium'
])
param sku string = 'Developer'

@allowed([
  1
  2
])
param skuCount int = 1

param location string = resourceGroup().location

resource apimService 'Microsoft.ApiManagement/service@2021-08-01' = {
  name: apimName
  location: location
  sku: {
    capacity: skuCount
    name: sku
  }
  properties: {
    publisherEmail: publisherEmail 
    publisherName: publisherName
  }
}
