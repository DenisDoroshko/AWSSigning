$domain = "axs"
$domainOwner = "971217900852"
$region = "us-west-2"
$source = "https://$domain-$domainOwner.d.codeartifact.$region.amazonaws.com/nuget/nuget/v3/index.json"
$sourceName = "axs/nuget"

# get codeartifact nuget password
$authToken = aws codeartifact get-authorization-token --domain $domain --domain-owner $domainOwner --query authorizationToken --output text

# set\update CodeArtifact nuget password
dotnet nuget remove source $sourceName
dotnet nuget add source $source --name $sourceName --username aws --password $authToken --store-password-in-clear-text
