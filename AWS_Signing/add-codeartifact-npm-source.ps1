param(
    [string]$domain,
    [string]$domainOwner,
    [string]$profile
)

aws codeartifact login --tool npm --repository npm --domain $domain --domain-owner $domainOwner --profile $profile